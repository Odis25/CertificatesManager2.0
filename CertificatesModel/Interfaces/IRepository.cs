using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Interfaces
{
    public interface IRepository
    {
        Certificates GetAllCertificatesFromDB();
    }
}