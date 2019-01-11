using CertificatesModel.Authorization;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertificatesModel.UsersModel
{
    [Serializable]
    [Table("USERS")]
    public class User
    {
        public User()
        {
            Login = "";
            Password = "";
            Domain = "Incomsystem.ru";
            UserRights = "Пользователь";
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("USER_NAME")]
        public string Login { get; set; }
        [NotMapped]
        public string Domain { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [Column("RIGHTS")]
        public string UserRights { get; set; }              
    }
}
