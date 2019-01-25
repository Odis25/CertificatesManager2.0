using CertificatesModel.Domain.UsersModel;
using System.Linq;

namespace CertificatesModel.Repositories
{
    public static class UsersRepository
    {
        // Строка подключения
        private static string _connectionString;

        private static Users _users;

        public static Users Users
        {
            get
            {
                if (_users == null)
                    _users = GetUsersList();
                return _users;
            }
            set { _users = value; }
        }

        static UsersRepository()
        {
            _connectionString = $"Data Source = {Settings.Instance.DataBasePath}";
        }

        public static User GetUserData(string login)
        {
            return Users.Where(x => x.Login.ToLower() == login).FirstOrDefault();
        }

        public static Users GetUsersList()
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                return db.Users.ToList();
            }
        }
    }
}
