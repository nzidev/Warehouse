using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBL.Models.DataBase
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions options) : base (options)
        {
            
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(new Staff
            {
                StaffId = 1,
                Name = "Имя1",
                Surname = "Фамилия1",
                Title = "Работник"
            });
            modelBuilder.Entity<Staff>().HasData(new Staff
            {
                StaffId = 2,
                Name = "Имя2",
                Surname = "Фамилия2",
                Title = "Работник"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdictId = 1,
                Name = "Товар 1",
                Price = 100,
                Status = Product.ProductStatus.Accept
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdictId = 2,
                Name = "Товар 2",
                Price = 300,
                Status = Product.ProductStatus.Accept
            });
        }
    }
}
