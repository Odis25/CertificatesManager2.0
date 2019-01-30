using CertificatesModel.Domain.UsersModel;

namespace CertificatesModel.Interfaces
{
    public interface IUsersLoader
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
        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="newUser">Логин</param>
        void AddNewUser(User newUser);
        /// <summary>
        /// Удалить пользователей
        /// </summary>
        /// <param name="arrayId">Массив Id пользователей</param>
        void DeleteUsers(int[] arrayId);
        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="id"></param>
        void EditUserData(User user);
    }
}
