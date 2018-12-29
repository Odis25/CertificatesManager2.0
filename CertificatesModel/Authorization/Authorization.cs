using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public static User CurrentUser { get; set; }

        public static void Authorizate()
        {
            var dbPath = Settings.Instance.DataBasePath;
            var certFolder = Settings.Instance.CertificatesFolderPath;
            var zipCertFolder = Settings.Instance.CertificatesZipFolderPath;

            List<string> hosts = new List<string>();

            // Проверяем, являются ли пути к базе и каталогам свидетельств сетевыми
            if (dbPath.StartsWith(@"\\"))
                hosts.Add(dbPath.TrimStart('\\').Split('\\')[0]);

            if (certFolder.StartsWith(@"\\"))
                hosts.Add(certFolder.TrimStart('\\').Split('\\')[0]);

            if (zipCertFolder.StartsWith(@"\\"))
                hosts.Add(zipCertFolder.TrimStart('\\').Split('\\')[0]);

            // Создаем подключения к хостам для всех сетевых путей

            foreach (var host in hosts.Distinct())
            {
                TryToConnect(host);
            }
        }

        private static void TryToConnect(string host)
        {
            // Получение IP адреса удаленного компьютера
            string hostIPAddress = Dns.GetHostAddresses(host)[0].ToString();
            // Получение имя удаленного компьютера
            string hostName = Dns.GetHostEntry(host).HostName.Split('.')[0];

            var cred = new NetworkCredential()
            {
                UserName = CurrentUser.Login,
                Password = CurrentUser.Password,
                Domain = "Incomsystem.ru"
            };

            // авторизация в домене по имени удаленной машины
            var connectionTry = new NetworkConnection(@"\\" + hostName, cred);
            // авторизация в домене по IP адресу удаленной машины
            var connectionTry2 = new NetworkConnection(@"\\" + hostIPAddress, cred);
        }

        // Получаем логин/пароль пользователя, если они были сохранены
        public static bool GetUserCredential()
        {
            var result = false;

            if (Settings.Instance.SaveUserCredential)
            {
                using (FileStream fs = new FileStream("credentials.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var user = (User)formatter.Deserialize(fs);
                    CurrentUser.Login = user.Login;
                    CurrentUser.Password = SecureIt.DecryptString(user.Password).ToInsecureString();
                }

                result = true;
            }

            return result;
        }
    }
}
