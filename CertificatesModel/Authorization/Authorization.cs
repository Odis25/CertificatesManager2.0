using CertificatesModel.Factories;
using CertificatesModel.Interfaces;
using CertificatesModel.UsersModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesModel.Authorization
{
    public static class Authorization
    {
        private static List<string> _hosts;

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public static User CurrentUser { get; set; }

        // Используются сетевые пути
        public static bool HasNetworkPaths
        {
            get
            {
                var dbPath = Settings.Instance.DataBasePath;
                var certFolder = Settings.Instance.CertificatesFolderPath;
                var zipCertFolder = Settings.Instance.CertificatesZipFolderPath;

                _hosts = new List<string>();

                // Проверяем, являются ли пути к базе и каталогам свидетельств сетевыми
                if (dbPath.StartsWith(@"\\"))
                    _hosts.Add(dbPath.TrimStart('\\').Split('\\')[0]);

                if (certFolder.StartsWith(@"\\"))
                    _hosts.Add(certFolder.TrimStart('\\').Split('\\')[0]);

                if (zipCertFolder.StartsWith(@"\\"))
                    _hosts.Add(zipCertFolder.TrimStart('\\').Split('\\')[0]);

                if (_hosts.Any())
                    return true;
                else
                    return false;
            }
        }

        // Пользователь успешно авторизован
        public static bool UserLogined { get; set; }

        static Authorization()
        {
            if (HasNetworkPaths)
            {
                CurrentUser = GetUserCredential();
                try
                {
                    LogIn(CurrentUser);
                }
                catch(Exception e)
                { }
            }
            else
            {
                CurrentUser = new User();
                UserLogined = true;
            }
        }

        // Авторизация пользователя
        public static void LogIn(User user)
        {
            // Проверяем корректность логина/пароля
            bool valid = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, user.Domain))
            {
                valid = context.ValidateCredentials(user.Login, user.Password);
            }

            // Имперсонация пользователя
            bool impersonationResult = Validate.ImpersonateUser(user.Login, user.Domain, user.Password);

            // Сохраняем учетные данные пользователя, если он того желает
            if (Settings.Instance.SaveUserCredential)
                SaveUserCredential(user);

            // Получаем права пользователя
            var userList = AppLocator.ModelFactory.Create<IUsersLoader>();
            user.UserRights = userList.GetUserData(user.Login).UserRights;

            CurrentUser = user;
            UserLogined = true;
        }

        private static void ConnectToHost(string host, User user)
        {
            // Получение IP адреса удаленного компьютера
            string hostIPAddress = Dns.GetHostAddresses(host)[0].ToString();
            // Получение имя удаленного компьютера
            string hostName = Dns.GetHostEntry(host).HostName.Split('.')[0];

            var cred = new NetworkCredential()
            {
                UserName = user.Login,
                Password = user.Password,
                Domain = user.Domain
            };

            // авторизация в домене по имени удаленной машины
            var connectionTry = new NetworkConnection(@"\\" + hostName, cred);
            // авторизация в домене по IP адресу удаленной машины
            var connectionTry2 = new NetworkConnection(@"\\" + hostIPAddress, cred);
        }

        // Получаем логин/пароль пользователя, если они были сохранены
        private static User GetUserCredential()
        {
            User currentUser = new User();
            try
            {
                if (Settings.Instance.SaveUserCredential)
                {
                    using (FileStream fs = new FileStream("credentials.dat", FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        var user = (User)formatter.Deserialize(fs);
                        currentUser.Login = user.Login;
                        currentUser.Password = user.Password.DecryptString().ToInsecureString();
                    }
                }
                return currentUser;
            }
            catch
            {
                return currentUser;
            }
        }

        // Сохраняем учетные данные пользователя
        public static void SaveUserCredential(User user)
        {
            var securedPassword = user.Password.ToSecureString().EncryptString();
            user.Password = securedPassword;

            using (FileStream fs = new FileStream("credentials.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, user);
            }
        }
    }
}
