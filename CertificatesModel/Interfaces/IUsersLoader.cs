using CertificatesModel.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Interfaces
{
    interface IUsersLoader
    {
        /// <summary>
        /// Получаем информацию о пользователе
        /// </summary>
        /// <param name="login">Логин пользователя в сети</param>
        /// <returns></returns>
        User GetUserData(string login);
    }
}
