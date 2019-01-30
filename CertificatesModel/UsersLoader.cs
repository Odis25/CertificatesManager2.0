using System;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;

namespace CertificatesModel
{
    public class UsersLoader : IUsersLoader
    {
        // Добавить нового пользователя
        public void AddNewUser(User newUser)
        {
            UsersRepository.AddNewUser(newUser);
        }

        // Получаем информацию о пользователе
        public User GetUserData(string login)
        {
            return UsersRepository.GetUserData(login) ?? new User();
        }

        // Получить список всех пользователей
        public Users GetUsersList()
        {
            return UsersRepository.Users;
        }

        // Удалить пользователей
        public void DeleteUsers(int[] arrayId)
        {
            UsersRepository.DeleteUsers(arrayId);
        }

        // Изменить данные пользователя
        public void EditUserData(User user)
        {
            UsersRepository.EditUserData(user);
        }
    }
}
