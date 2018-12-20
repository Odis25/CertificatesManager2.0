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
        public Certificates Load()
        {
            Certificates result = Repository.GetAllCertificatesFromDB();
            return result;
        }

        public Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern)
        {
            Certificates result = Repository.GetAllCertificatesFromDB(pattern);
            return result;
        }
    }
}
