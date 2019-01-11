using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{
    [Table("METROLOGY")]
    public class Certificate //IComparable<Certificate>
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
        public string ContractNumber { get; set; }
        /// <summary>
        /// Серийный номер свидетельства
        /// </summary>
        [Column("CERTIFICATE_NUMBER")]
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
        public string DeviceType { get; set; }
        /// <summary>
        /// Наименование средства измерения
        /// </summary>
        [Column("NAME_DEVICE")]
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
        public DateTime CalibrationExpireDate { get; set; }
        /// <summary>
        /// Путь к файлу свидетельства
        /// </summary>
        [Column("PATH")]
        public string CertificatePath { get; set; }

        ///// <summary>
        ///// Сортировка по ID
        ///// </summary>
        ///// <param name="other"></param>
        ///// <returns></returns>
        //public int CompareTo(Certificate other)
        //{
        //    return this.ID.CompareTo(other.ID);
        //}
    }
}
