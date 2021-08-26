using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopPet.DataAccessLayer.Entities
{
    public partial class ShopPetModels : DbContext
    {
        public ShopPetModels()
            : base("name=ShopPetModels")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpPass)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.IDEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProCate)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IDEmployee)
                .WillCascadeOnDelete(false);
        }
    }
}
