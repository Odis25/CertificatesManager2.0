using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Authorization
{
    [Serializable]
    public class User
    {
        public User()
        {
            Domain = "Incomsystem.ru";
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Domain { get; }
        public string Password { get; set; }
        public AccessRights SecurityLevel { get; set; }
    }

}
