using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Factories;
using CertificatesModel.Interfaces;
using System;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CertificatesModel.Authorization
{
    public static class Authorization
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public static User CurrentUser { get; set; }

        public static event EventHandler UserChanged = delegate { };

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

            UserChanged(new object(), EventArgs.Empty);
        }

        // Получаем логин/пароль пользователя, если они были сохранены
        private static User GetUserCredential()
        {
            User currentUser = new User();
            try
            {
                if (Settings.Instance.SaveUserCredential)
                {
                    currentUser.Login = Properties.Settings.Default.UserLogin;
                    currentUser.Password = Properties.Settings.Default.UserPassword.DecryptString().ToInsecureString();
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
            var securedPassword = user.Password.ToSecureString().EncryptString();
            Properties.Settings.Default.UserLogin = user.Login;
            Properties.Settings.Default.UserPassword = securedPassword;
            Properties.Settings.Default.Save();
        }
    }
}
