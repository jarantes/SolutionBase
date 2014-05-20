using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WEB_BASE.Models
{
    public class ApplicationFullContext : DbContext
    {
        public ApplicationFullContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ProductsModels> Products { get; set; }
        public DbSet<ProductsCategoryModels> Categorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}