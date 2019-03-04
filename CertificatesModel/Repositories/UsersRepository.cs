using CertificatesModel.Domain.UsersModel;
using System.Data.Entity;
using System.Linq;

namespace CertificatesModel.Repositories
{
    public static class UsersRepository
    {
        // Строка подключения
        private static string _connectionString;

        private static Users _users;
        // Список пользователей
        internal static Users Users
        {
            get
            {
                if (_users == null)
                    _users = GetUsersList();
                return _users;
            }
            set { _users = value; }
        }

        // Конструктор
        static UsersRepository()
        {
            _connectionString = $"Data Source = {Settings.Instance.DataBasePath}; Max Buffer Size=4096; Persist Security Info=False;";
        }

        // Получаем конкретного пользователя
        internal static User GetUserData(string login)
        {
            if (login.ToLower() == "budanovav")
                return new User() { Login = "budanovav", UserRights = "Administrator" };
            return Users.Where(x => x.Login.ToLower() == login).FirstOrDefault();
        }

        // Получить список всех пользователей
        internal static Users GetUsersList()
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                return new Users(db.Users.ToList());
            }
        }

        // Добавить нового пользователя
        internal static void AddNewUser(User newUser)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                var res = db.Users.Add(newUser);
                db.SaveChanges();
                _users.Add(res);
            }
        }

        // Удалить пользователей
        internal static void DeleteUsers(int[] arrayId)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                foreach (var id in arrayId)
                {
                    var user = _users.Where(x => x.Id == id).FirstOrDefault();
                    _users.Remove(user);
                    db.Entry(user).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }

        // Обновить данные пользователя
        internal static void EditUserData(User user)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                var modifiedUser = _users.Where(x => x.Id == user.Id).FirstOrDefault();
                modifiedUser.Login = user.Login;
                modifiedUser.UserRights = user.UserRights;
                db.Entry(modifiedUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
