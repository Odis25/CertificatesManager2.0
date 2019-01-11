using CertificatesModel.UsersModel;
using System.Data.Entity;
using System.Data.SqlServerCe;

namespace CertificatesModel.Domain.UsersModel
{
    public class UserDbContext: DbContext
    {
        public UserDbContext() : base(new SqlCeConnection("Data Source = " + Settings.Instance.DataBasePath), true)
        { }
        public DbSet<User> Users { get; set; }
    }
}
