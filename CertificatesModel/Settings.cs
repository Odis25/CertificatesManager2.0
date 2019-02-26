namespace CertificatesModel
{
    public class Settings
    {
        private static Settings _instance;
        /// <summary>
        /// Экземпляр класса настроек
        /// </summary>
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                return _instance;
            }
        }

        static Settings()
        {
            _instance = new Settings();
            _instance.DataBasePath = Properties.Settings.Default.DataBasePath;
            _instance.CertificatesFolderPath = Properties.Settings.Default.CertificatesFolderPath;
            _instance.CertificatesZipFolderPath = Properties.Settings.Default.CertificatesZipFolderPath;
            _instance.VerificateionMethodFolderPath = Properties.Settings.Default.VerificationMethodFolder;
            _instance.AutoPreviewEnabled = Properties.Settings.Default.AutoPreviewEnabled;
            _instance.SaveUserCredential = Properties.Settings.Default.SaveUserCredential;

        }

        /// <summary>
        /// Сохранить настройки в файл settings.xml
        /// </summary>
        public static void Serialize()
        {
            Properties.Settings.Default.DataBasePath = _instance.DataBasePath;
            Properties.Settings.Default.CertificatesFolderPath = _instance.CertificatesFolderPath;
            Properties.Settings.Default.CertificatesZipFolderPath = _instance.CertificatesZipFolderPath;
            Properties.Settings.Default.VerificationMethodFolder = _instance.VerificateionMethodFolderPath;
            Properties.Settings.Default.AutoPreviewEnabled = _instance.AutoPreviewEnabled;
            Properties.Settings.Default.SaveUserCredential = _instance.SaveUserCredential;
            Properties.Settings.Default.Save(); // Сохраняем переменные.
        }

        /// <summary>
        /// Путь к файлу базы данных
        /// </summary>
        public string DataBasePath { get; set; }
        /// <summary>
        /// Путь к каталогу хранения свидетельств
        /// </summary>
        public string CertificatesFolderPath { get; set; }
        /// <summary>
        /// Путь к каталогу резервного хранения свидетельств
        /// </summary>
        public string CertificatesZipFolderPath { get; set; }
        /// <summary>
        /// Путь к каталогу хранения методик поверки
        /// </summary>
        public string VerificateionMethodFolderPath { get; set; }
        /// <summary>
        /// Отображать свидетельства в окне предпросмотра
        /// </summary>
        public bool AutoPreviewEnabled { get; set; }
        /// <summary>
        /// Не спрашивать учетные данные пользователя при входе
        /// </summary>
        public bool SaveUserCredential { get; set; }
    }
}
