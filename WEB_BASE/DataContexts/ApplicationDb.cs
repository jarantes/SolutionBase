using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WEB_BASE.Models;

namespace WEB_BASE.DataContexts
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb()
            : base("DefaultConnection")
        {
        }

        //DBset da aplicação
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}