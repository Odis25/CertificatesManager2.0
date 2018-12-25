using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;

namespace CertificatesModel
{
    public class CertificatesLoader : ILoader
    {

        // Получить весь список свидетельств
        public Certificates GetAllCertificates()
        {
            Certificates result = Repository.GetAllCertificatesFromDB();
            return result;
        }

        // Получить список свидетельств соответствующих шаблону
        public Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern)
        {
            Certificates result = Repository.GetAllCertificatesFromDB(pattern);
            return result;
        }

        // Изменить свидетельство согласно шаблону
        public void EditCertificate(CertificateEventArgs pattern)
        {
            Repository.ModifyCertificate(pattern);
        }
    }
}
