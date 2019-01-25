using CertificatesModel.Authorization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertificatesModel.Domain.UsersModel
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

        [DisplayName("Имя пользователя")]
        [Column("USER_NAME")]
        public string Login { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string Domain { get; set; }

        [Browsable(false)]
        [NotMapped]
        public string Password { get; set; }

        [DisplayName("Уровень прав")]
        [Column("RIGHTS")]
        public string UserRights { get; set; }              
    }
}
