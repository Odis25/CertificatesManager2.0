using CertificatesModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertificatesModel.UsersModel;
using CertificatesModel.Repositories;

namespace CertificatesModel
{
    public class UsersLoader : IUsersLoader
    {
        // Получаем информацию о пользователе
        public User GetUserData(string login)
        {
            return UsersRepository.GetUserData(login) ?? new User();
        }
    }
}
