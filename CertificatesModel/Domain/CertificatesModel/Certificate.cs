using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CertificatesModel.Validation.Attributes;
using System.IO;

namespace CertificatesModel
{
    [Table("METROLOGY")]
    public class Certificate : ICloneable
    {
        /// <summary>
        /// ID свидетельства в БД
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Год в котором было оформлено свидетельство
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать номер договора.")]
        public string ContractNumber { get; set; }
        /// <summary>
        /// Серийный номер свидетельства
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать номер свидетельства.")]
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
        [Required(ErrorMessage = "Необходимо указать группу СИ.")]
        public string DeviceType { get; set; }
        /// <summary>
        /// Наименование средства измерения
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать наименование СИ.")]
        public string DeviceName { get; set; }
        /// <summary>
        /// Заводской номер средства измерения
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Дата поверки средства измерения
        /// </summary>
        public DateTime CalibrationDate { get; set; }
        /// <summary>
        /// Дата истечения срока поверки средства измерения
        /// </summary>
        [DateLessOrEqualThan("CalibrationDate", ErrorMessage = "Дата истечения срока поверки должна быть больше даты поверки")]
        public DateTime CalibrationExpireDate { get; set; }

        /// <summary>
        /// Путь к файлу свидетельства
        /// </summary>
        public string CertificatePath { get; set; }

        [NotMapped]
        public string FullCertificatePath
        {
            get { return Path.Combine(Settings.Instance.CertificatesFolderPath, CertificatePath); }
        }

        [NotMapped]
        public string FileSize
        {
            get
            {
                if (File.Exists(FullCertificatePath))
                    return new FileInfo(FullCertificatePath).Length.ToString();
                else
                    return "---";
            }
        }

        [NotMapped]
        public string FileCreationDate
        {
            get
            {
                if (File.Exists(FullCertificatePath))
                    return new FileInfo(FullCertificatePath).CreationTime.ToString();
                else
                    return "---";
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
