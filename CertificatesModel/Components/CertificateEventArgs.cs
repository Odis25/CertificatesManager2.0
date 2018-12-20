using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Components
{
    public class CertificateEventArgs: EventArgs
    {
        /// <summary>
        /// ID свидетельства в БД
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// Год в котором было оформлено свидетельство
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        public string ContractNumber { get; set; }
        /// <summary>
        /// Серийный номер свидетельства
        /// </summary>
        public string CertificateNumber { get; set; }
        /// <summary>
        /// Номер свидетельства в Гос.Реестра
        /// </summary>
        public string RegisterNumber { get; set; }
        /// <summary>
        /// Наименование методики поверки
        /// </summary>
        public string VerificationMethod { get; set; }
        /// <summary>
        /// Наименование организации заказчика
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// Наименование объекта эксплуатации
        /// </summary>
        public string ObjectName { get; set; }
        /// <summary>
        /// Тип средства измерения
        /// </summary>
        public string DeviceType { get; set; }
        /// <summary>
        /// Наименование средства измерения
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// Заводской номер средства измерения
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Дата поверки средства измерения
        /// </summary>
        public DateTime? CalibrationDate { get; set; }
        /// <summary>
        /// Дата истечения срока поверки средства измерения
        /// </summary>
        public DateTime? CalibrationExpireDate { get; set; }
        /// <summary>
        /// Путь к файлу свидетельства
        /// </summary>
        public string CertificatePath { get; set; }
    }
}
