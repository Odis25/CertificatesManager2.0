using System;
using System.IO;
using System.Xml.Serialization;

namespace CertificatesModel
{
    [Serializable]
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
            try
            {               
                using (FileStream stream = new FileStream("settings.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    _instance = (Settings)serializer.Deserialize(stream);
                }
            }
            catch
            {
                _instance = new Settings();
                _instance.DataBasePath = "D:\\Test.sdf";
                _instance.CertificatesFolderPath = "";
                _instance.CertificatesZipFolderPath = "";
            }
        }

        /// <summary>
        /// Сохранить настройки в файл settings.xml
        /// </summary>
        public static void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream stream = new FileStream("settings.xml", FileMode.Create))
            {
                serializer.Serialize(stream, Instance);
            }
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
        /// Отображать свидетельства в окне предпросмотра
        /// </summary>
        public bool AutoPreviewEnabled { get; set; }
        /// <summary>
        /// Не спрашивать учетные данные пользователя при входе
        /// </summary>
        public bool SaveUserCredential { get; set; }
    }
}
