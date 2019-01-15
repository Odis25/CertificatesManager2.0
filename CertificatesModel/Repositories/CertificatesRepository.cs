using CertificatesModel.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.SqlServerCe;
using System.Linq;
using System.Threading.Tasks;

namespace CertificatesModel.Repositories
{
    public static class CertificatesRepository
    {
        static string _connectionString;

        static Certificates Certificates { get; set; }

        static CertificatesRepository()
        {
            _connectionString = $"Data Source = {Settings.Instance.DataBasePath}";
        }

        // Получаем все свидетельства из БД и сортируем по ID
        public static Certificates GetAllCertificatesFromDB()
        { 
            try
            {
                return GetAllCertificatesFromDB(new CertificateEventArgs());
            }
            catch(SqlCeException e)
            {
                return new Certificates();
            }           
        }

        // Получаем список свидетельств соответствующих поисковому шаблону
        public static Certificates GetAllCertificatesFromDB(CertificateEventArgs pattern)
        {
            var result = new Certificates();

            using (CertificateDbContext db = new CertificateDbContext())
            {
                IQueryable<Certificate> querry = db.Certificates;
                querry = querry.OrderBy(x=>x.ID);

                if (pattern.ID.HasValue)
                    querry = querry.Where(x => x.ID == pattern.ID);
                if (pattern.Year.HasValue)
                    querry = querry.Where(x => x.Year == pattern.Year);
                if (!string.IsNullOrEmpty(pattern.CertificateNumber))
                    querry = querry.Where(x => x.CertificateNumber.Contains(pattern.CertificateNumber));
                if (!string.IsNullOrEmpty(pattern.RegisterNumber))
                    querry = querry.Where(x => x.RegisterNumber.Contains(pattern.RegisterNumber));
                if (!string.IsNullOrEmpty(pattern.VerificationMethod))
                    querry = querry.Where(x => x.VerificationMethod.Contains(pattern.VerificationMethod));
                if (!string.IsNullOrEmpty(pattern.ContractNumber))
                    querry = querry.Where(x => x.ContractNumber.Contains(pattern.ContractNumber));
                if (!string.IsNullOrEmpty(pattern.ClientName))
                    querry = querry.Where(x => x.ClientName.Contains(pattern.ClientName));
                if (!string.IsNullOrEmpty(pattern.ObjectName))
                    querry = querry.Where(x => x.ObjectName.Contains(pattern.ObjectName));
                if (!string.IsNullOrEmpty(pattern.DeviceType))
                    querry = querry.Where(x => x.DeviceType.Contains(pattern.DeviceType));
                if (!string.IsNullOrEmpty(pattern.DeviceName))
                    querry = querry.Where(x => x.DeviceName.Contains(pattern.DeviceName));
                if (!string.IsNullOrEmpty(pattern.SerialNumber))
                    querry = querry.Where(x => x.SerialNumber.Contains(pattern.SerialNumber));

                if (pattern.CalibrationDate.HasValue)
                    querry = querry.Where(x => x.CalibrationDate >= pattern.CalibrationDate);
                if (pattern.CalibrationExpireDate.HasValue)
                    querry = querry.Where(x => x.CalibrationExpireDate <= pattern.CalibrationExpireDate);

                result = (Certificates)querry.ToList();
            }

            return result;
        }

        // Внесение изменений в свидетельство по шаблону
        public static void EditCertificate(CertificateEventArgs pattern)
        {
            using (CertificateDbContext db = new CertificateDbContext())
            {
                var certificate = db.Certificates.Where(x => x.ID == pattern.ID).First();
                certificate.Year = (int)pattern.Year;
                certificate.CertificateNumber = pattern.CertificateNumber;
                certificate.RegisterNumber = pattern.RegisterNumber;
                certificate.VerificationMethod = pattern.VerificationMethod;
                certificate.ContractNumber = pattern.ContractNumber;
                certificate.ClientName = pattern.ClientName;
                certificate.ObjectName = pattern.ObjectName;
                certificate.DeviceName = pattern.DeviceName;
                certificate.DeviceType = pattern.DeviceType;
                certificate.SerialNumber = pattern.SerialNumber;
                certificate.CalibrationDate = pattern.CalibrationDate.Value;
                certificate.CalibrationExpireDate = pattern.CalibrationExpireDate.Value;
                certificate.CertificatePath = pattern.CertificatePath;
                // Сохраняем изменения
                db.SaveChanges();
            }
        }

        public static void DeleteCertificates(params int[] idList)
        {
            using (CertificateDbContext db = new CertificateDbContext())
            {
                foreach(var id in idList)
                {
                    var cert = db.Certificates.Find(id);
                    db.Certificates.Remove(cert);
                }
                db.SaveChanges();
            }
        }
    }
}
