using Ayana.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ayana.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<ProductSales> ProductSales { get; set; }


       
           
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Discount>().ToTable("Discounts");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Subscription>().ToTable("Subscriptions");
            modelBuilder.Entity<ProductOrder>().ToTable("ProductOrders");
            modelBuilder.Entity<ProductSales>().ToTable("ProductSales");

            base.OnModelCreating(modelBuilder);
        }



    }
}