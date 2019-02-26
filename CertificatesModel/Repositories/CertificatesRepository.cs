using CertificatesModel.Components;
using System.Data;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.Linq;

namespace CertificatesModel.Repositories
{
    public static class CertificatesRepository
    {
        private static string _connectionString;
        private static Certificates _certificates;

        public static Certificates Certificates
        {
            get
            {
                if (_certificates == null)
                    _certificates = GetAllCertificatesFromDB();
                return _certificates;
            }
            set { _certificates = value; }
        }

        static CertificatesRepository()
        {
            _connectionString = $"Data Source = {Settings.Instance.DataBasePath}";
        }

        // Получаем все свидетельства из БД и сортируем по ID
        private static Certificates GetAllCertificatesFromDB()
        { 
            try
            {
                return GetSelectedCertificatesFromDB(new CertificateEventArgs());
            }
            catch(SqlCeException e)
            {
                return new Certificates();
            }           
        }

        // Получаем список свидетельств соответствующих поисковому шаблону
        public static Certificates GetSelectedCertificatesFromDB(CertificateEventArgs pattern)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
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

                return new Certificates(querry.ToList());
            }        
        }

        // Добавить новое свидетельство в база
        public static void AddNewCertificate(Certificate newCertificate)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                var result = db.Certificates.Add(newCertificate);
                db.SaveChanges();
                _certificates.Add(result);
            }
        }

        // Изменение путей к файлам свидетельств
        public static void ModifyFilePath(int[] idArray, string newFilePath)
        {
            using (var db = new MetrologyDbContext())
            {
                foreach (var id in idArray)
                {
                    var certificate = _certificates.Where(x => x.ID == id).FirstOrDefault();
                    certificate.CertificatePath = newFilePath;
                    db.Entry(certificate).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        // Внесение изменений в свидетельство по шаблону
        public static void EditCertificate(CertificateEventArgs pattern)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                var certificate = _certificates.Where(x => x.ID == pattern.ID).FirstOrDefault();

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
                db.Entry(certificate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Удаление свидетельств
        public static void DeleteCertificates(params int[] idList)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                foreach(var id in idList)
                {
                    var cert = _certificates.Single(x => x.ID == id);
                    _certificates.Remove(cert);
                    db.Entry(cert).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }
    }
}
