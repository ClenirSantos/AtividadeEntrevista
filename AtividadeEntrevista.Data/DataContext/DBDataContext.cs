using System.Data.Entity;

namespace AtividadeEntrevista.Data.DataContext
{
    public class DBDataContext : DbContext
    {
        public DBDataContext() : base("DBDataContext") {
        }


        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Beneficiario> Beneficiario { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        }

    }
}
