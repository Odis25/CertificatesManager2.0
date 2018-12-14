using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{
    public class Year: List<Contract>
    {
        private List<Certificate> _certificates;

        public int YearOfCreationCertificate { get; set; }

        /// <summary>
        /// Все свидетельства за год
        /// </summary>
        public List<Certificate> ListOfCertificates
        {
            get
            {
                _certificates = new List<Certificate>();
                foreach (var contract in this)
                    foreach (var certificate in contract)
                        _certificates.Add(certificate);
                _certificates.Sort();
                return _certificates;
            }

        }
    }
}
