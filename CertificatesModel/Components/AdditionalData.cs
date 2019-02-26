using System.Collections.Generic;

namespace CertificatesModel.Components
{
    public struct AdditionalData
    {
        /// <summary>
        /// Открывать сформированный акт
        /// </summary>
        public bool OpenAkt { get; set; }
        /// <summary>
        /// ФИО поверителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Колличество страниц
        /// </summary>
        public int[] Pages { get; set; }
        /// <summary>
        /// Свидетельства/свидетельства+протокол
        /// </summary>
        public Dictionary<int, string> Flags { get; set; }
        /// <summary>
        /// Номер акта
        /// </summary>
        public int AktNumber { get; set; }
        /// <summary>
        /// Путь сохранения созданного акта
        /// </summary>
        public string AktFolderPath { get; set; }
    }
}
