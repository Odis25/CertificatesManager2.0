using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{ 
    [Serializable]
    public static class Settings
    {
        /// <summary>
        /// Путь к файлу базы данных
        /// </summary>
        public static string DataBasePath { get; set; }
        /// <summary>
        /// Путь к каталогу хранения свидетельств
        /// </summary>
        public static string CertificatesFolderPath { get; set; }
        /// <summary>
        /// Путь к каталогу резервного хранения свидетельств
        /// </summary>
        public static string CertificatesZipFolderPath { get; set; }
        /// <summary>
        /// Отображать свидетельства в окне предпросмотра
        /// </summary>
        public static bool AutoPreviewEnabled { get; set; }
    }
}
