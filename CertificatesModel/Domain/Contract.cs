using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{
    public class Contract : List<Certificate>
    {        
        public string ContractNumber { get; set; }
    }
}
