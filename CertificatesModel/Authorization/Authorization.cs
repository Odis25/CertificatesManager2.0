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
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesModel.Authorization
{
    public static class Authorization
    {
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

                // Проверяем, являются ли пути к базе и каталогам свидетельств сетевыми
                if (dbPath.StartsWith(@"\\") || certFolder.StartsWith(@"\\") || zipCertFolder.StartsWith(@"\\"))
                    return true;
                else
                    return false;
            }
        }

        // Пользователь авторизован
        public static bool UserLogined { get; set; }

        // Конструктор
        static Authorization()
        {
            if (HasNetworkPaths)
            {
                CurrentUser = GetUserCredential();
                try
                {
                    LogIn(CurrentUser);
                }
                catch (Exception e)
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
            // Если учетные данные пользователя не верны
            if (!valid)
            {
                UserLogined = false;
                throw new Exception("Некорректный логин или пароль");
            }
            // Сохраняем учетные данные пользователя, если он того желает
            if (Settings.Instance.SaveUserCredential)
                SaveUserCredential(user);

            // Имперсонация пользователя
            bool impersonationResult = Validate.ImpersonateUser(user.Login, user.Domain, user.Password);

            // Получаем права пользователя
            var userList = AppLocator.ModelFactory.Create<IUsersLoader>();
            user.UserRights = userList.GetUserData(user.Login).UserRights;

            CurrentUser = user;
            UserLogined = true;
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
        private static void SaveUserCredential(User user)
        {
            var userPassword = user.Password;
            var securedPassword = user.Password.ToSecureString().EncryptString();
            user.Password = securedPassword;

            using (FileStream fs = new FileStream("credentials.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, user);
            }
            user.Password = userPassword;
        }
    }
}
