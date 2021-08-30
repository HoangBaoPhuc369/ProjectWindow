using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Report.DataAccessLayer
{
    public partial class ShopPetDbContext : DbContext
    {
        public ShopPetDbContext()
            : base("name=ShopPetDbContext")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Details)
                .WithOptional(e => e.Bill)
                .HasForeignKey(e => e.IDBills);

            modelBuilder.Entity<Detail>()
                .Property(e => e.Category)
                .IsUnicode(false);
        }
    }
}
