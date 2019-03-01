using CertificatesModel.Domain.UsersModel;
using System.Data.Entity;
using System.Data.SqlServerCe;

namespace CertificatesModel
{
    public class MetrologyDbContext : DbContext
    {
        public MetrologyDbContext() : base(new SqlCeConnection($"Data Source = {Settings.Instance.DataBasePath}; Max Buffer Size=4096; Persist Security Info=False;"), true)
        { }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
