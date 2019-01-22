using CertificatesModel.UsersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Repositories
{
    public static class UsersRepository
    {
        // Строка подключения
        private static string _connectionString;

        static UsersRepository()
        {
            _connectionString = $"Data Source = {Settings.Instance.DataBasePath}";
        }

        public static User GetUserData(string login)
        {
            using (MetrologyDbContext db = new MetrologyDbContext())
            {
                IQueryable<User> querry = db.Users.Where(x => x.Login.ToLower() == login);
                var result = querry.FirstOrDefault();
                return result;
            }
        }
    }
}
