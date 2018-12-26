using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Authorisation
{
    public class User
    {
        public User()
        { }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AccessRights SecurityLevel { get; set; }
    }

}
