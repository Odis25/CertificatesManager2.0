using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{
    public class Loader : ILoader
    {
        public Certificates Load()
        {
            //IRepository repository = new Repository();

            //Certificates result = Repository.GetAllCertificatesFromDB();
            Certificates result = new Certificates();
            return result;
        }
    }
}
