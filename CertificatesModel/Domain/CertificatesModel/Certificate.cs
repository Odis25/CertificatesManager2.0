using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CertificatesModel.Validation.Attributes;
using System.IO;

namespace CertificatesModel
{
    [Table("METROLOGY")]
    public class Certificate
    {
        /// <summary>
        /// ID свидетельства в БД
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// Год в котором было оформлено свидетельство
        /// </summary>
        [Column("YEARS")]
        public int Year { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        [Column("CONTRACT_NUMBER")]
        [Required(ErrorMessage = "Необходимо указать номер договора.")]
        public string ContractNumber { get; set; }
        /// <summary>
        /// Серийный номер свидетельства
        /// </summary>
        [Column("CERTIFICATE_NUMBER")]
        [Required(ErrorMessage = "Необходимо указать номер свидетельства.")]
        public string CertificateNumber { get; set; }
        /// <summary>
        /// Номер свидетельства в Гос.Реестра
        /// </summary>
        [Column("REGISTER_NUMBER")]
        public string RegisterNumber { get; set; }
        /// <summary>
        /// Наименование методики поверки
        /// </summary>
        [Column("VERIFICATION_METHOD")]
        public string VerificationMethod { get; set; }
        /// <summary>
        /// Наименование организации заказчика
        /// </summary>
        [Column("CLIENT_NAME")]
        public string ClientName { get; set; }
        /// <summary>
        /// Наименование объекта эксплуатации
        /// </summary>
        [Column("OBJECT_NAME")]
        public string ObjectName { get; set; }
        /// <summary>
        /// Тип средства измерения
        /// </summary>
        [Column("TYPE_DEVICE")]
        [Required(ErrorMessage = "Необходимо указать группу СИ.")]
        public string DeviceType { get; set; }
        /// <summary>
        /// Наименование средства измерения
        /// </summary>
        [Column("NAME_DEVICE")]
        [Required(ErrorMessage = "Необходимо указать наименование СИ.")]
        public string DeviceName { get; set; }
        /// <summary>
        /// Заводской номер средства измерения
        /// </summary>
        [Column("SERIAL_NUMBER")]
        public string SerialNumber { get; set; }
        /// <summary>
        /// Дата поверки средства измерения
        /// </summary>
        [Column("CALIB_DATE")]
        public DateTime CalibrationDate { get; set; }
        /// <summary>
        /// Дата истечения срока поверки средства измерения
        /// </summary>
        [Column("CALIB_LAST_DATE")]
        [DateLessOrEqualThan("CalibrationDate", ErrorMessage = "Дата истечения срока поверки должна быть больше даты поверки")]
        public DateTime CalibrationExpireDate { get; set; }
        /// <summary>
        /// Путь к файлу свидетельства
        /// </summary>
        [Column("PATH")]
        public string CertificatePath { get; set; }

        [NotMapped]
        public virtual string FileSize
        {
            get
            {
                if (File.Exists(CertificatePath))
                    return new FileInfo(CertificatePath).Length.ToString();
                else
                    return "---";
            }
        }

        [NotMapped]
        public virtual string FileCreationDate
        {
            get
            {
                if (File.Exists(CertificatePath))
                    return new FileInfo(CertificatePath).CreationTime.ToString();
                else
                    return "---";
            }
        }
    }
}
