using System.Data.Entity;
using System.Data.SqlServerCe;

namespace CertificatesModel
{
    public class CertificateDbContext : DbContext
    {
        public CertificateDbContext() : base(new SqlCeConnection("Data Source = " + Settings.Instance.DataBasePath), true)
        { }
        public DbSet<Certificate> Certificates { get; set; }
    }
}
