using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Interfaces;
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

        public Users GetUsersList()
        {
            return UsersRepository.GetUsersList();
        }
    }
}
