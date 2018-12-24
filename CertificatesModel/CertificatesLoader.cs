using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ModifyCertificate(CertificateEventArgs pattern)
        {
            Repository.ModifyCertificate(pattern);
        }
    }
}
