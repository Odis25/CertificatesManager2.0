using CertificatesModel.Domain.UsersModel;

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
        /// <summary>
        /// Получить список пользователей из БД
        /// </summary>
        /// <returns></returns>
        Users GetUsersList();
    }
}
