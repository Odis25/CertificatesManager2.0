using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Authorisation
{
    public static class Authorisation
    {
        
        private static NetworkCredential _userCredential;

        public static User CurrentUser { get; set; }

        public static void Authorisate()
        {
            string ipAddress, hostName, nameOrIP;
            CurrentUser = new User();
            CurrentUser.Login = "budanovav";
            CurrentUser.Password = "narutaru";
            

            var dbPath = Settings.Instance.DataBasePath;
            var certFolder = Settings.Instance.CertificatesFolderPath;
            var zipCertFolder = Settings.Instance.CertificatesZipFolderPath;

            var paths = new string[] { dbPath, certFolder, zipCertFolder };

            foreach (var path in paths.Where(x=>x.StartsWith(@"\\")))
            {
                var hostNameOrAddress = path.TrimStart('\\').Split('\\')[0];
                var ip = Dns.GetHostAddresses(hostNameOrAddress).FirstOrDefault().ToString();
                var unc = Dns.GetHostEntry(hostNameOrAddress).HostName.Split('.').FirstOrDefault();
            }

            // Получение IP адреса или имени удаленного компьютера
            if (dbPath.StartsWith(@"\\"))
            {
                nameOrIP = dbPath.TrimStart('\\').Split('\\')[0];

                // Получение IP адреса удаленного компьютера
                ipAddress = Dns.GetHostAddresses(nameOrIP)[0].ToString();
                // Получение имя удаленного компьютера
                hostName = Dns.GetHostEntry(nameOrIP).HostName.Split('.')[0];
            }
            else
            {
                nameOrIP = "fileserver";
                // Получение IP адреса удаленного компьютера
                ipAddress = Dns.GetHostAddresses(nameOrIP)[0].ToString();
                // Получение имя удаленного компьютера
                hostName = Dns.GetHostEntry(nameOrIP).HostName.Split('.')[0];
            }

            var cred = new NetworkCredential()
            {
                UserName = CurrentUser.Login,
                Password = CurrentUser.Password,
                Domain = "Incomsystem.ru"
            };

            // авторизация в домене по имени удаленной машины
                var connectionTry = new NetworkConnection(@"\\" + hostName, cred);
            // авторизация в домене по IP адресу удаленной машины
                var connectionTry2 = new NetworkConnection(@"\\" + ipAddress, cred);
        }
    }
}
