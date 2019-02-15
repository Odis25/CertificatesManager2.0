using CertificatesModel.Components;
using System.Collections.Generic;

namespace CertificatesModel
{
    public class Certificates : SortableBindingList<Certificate> //IEnumerable<Certificate>
    {
        public Certificates() :base()
        {
            
        }

        public Certificates(List<Certificate> list) : base(list)
        {

        }
    }
}
