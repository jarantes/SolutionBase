using BASE_APP.Models;
using System.Data.Entity;

namespace BASE_APP.Context
{
    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=APP_DATABASE")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<AppModules> AppModules { get; set; }
        public virtual DbSet<AppProfileClass> AppProfileClass { get; set; }
        public virtual DbSet<AppProfiles> AppProfiles { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }
    }
}
