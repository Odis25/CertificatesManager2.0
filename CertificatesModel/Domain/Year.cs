using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{
    public class Year: List<Contract>
    {
        public int YearOfCreationCertificate { get; set; }
    }
}
