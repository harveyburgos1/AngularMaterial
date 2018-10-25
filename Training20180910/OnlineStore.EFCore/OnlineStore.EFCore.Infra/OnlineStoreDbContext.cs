using Microsoft.EntityFrameworkCore;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class OnlineStoreDbContext
        : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Student> Students { get; set; }
        public OnlineStoreDbContext(
            DbContextOptions<OnlineStoreDbContext> options)
            : base(options)
        {

        }

        public OnlineStoreDbContext()
        {

        }



        protected override void OnConfiguring(
                    DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=OnlineStoreDB;Integrated Security=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}
