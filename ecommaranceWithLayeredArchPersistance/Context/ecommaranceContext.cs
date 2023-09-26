using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ecommaranceWithLayeredArchDomain.Entities;
using Microsoft.Win32;

namespace ecommaranceWithLayeredArchPersistance.Content
{
    public class ecommaranceContext : DbContext
    {
        public ecommaranceContext()
            : base("name=ecommaranceContext")
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<SKU> SKUs { get; set; }
        public virtual DbSet<VariantSKU> GetVariantSKUs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
