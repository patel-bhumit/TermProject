using Microsoft.EntityFrameworkCore;
using System;
using TMS.Data.Model;

namespace TMS.Data.Context
{
    public class TmsdbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Server=tcp:tms-jsvb.database.windows.net,1433;Initial Catalog=TMS;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default';";

            optionsBuilder.UseMySql(connectionString, mySqlOptions => mySqlOptions.ServerVersion(new ServerVersion(new Version(8, 0, 21), ServerType.MySql)));

        }

        public TmsdbContext(DbContextOptions<TmsdbContext> options)
            : base(options)
        {
            // Ensure that the database is created if not exists
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RateFeeTable> RateFeeTables { get; set; }
        public DbSet<CarrierData> CarrierData { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here

            // Example:
            // modelBuilder.Entity<Order>().ToTable("Orders");
            // modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
            // modelBuilder.Entity<Order>().Property(o => o.CustomerName).IsRequired();
            // ... Repeat this for other entities

            // You can also configure relationships between entities if needed
            // Example:
            // modelBuilder.Entity<Order>().HasMany(o => o.Trips).WithOne(t => t.Order);
        }
    }
}