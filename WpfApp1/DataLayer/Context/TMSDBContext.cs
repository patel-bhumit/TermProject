using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DataLayer.Context
{
    internal class TMSDBContext : DbContext
    {
        public DbSet<login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=localhost;port=3306;database=TMS;user=root;password=9487;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<login>().HasData(
                new login
                {
                    Username = "admin",
                    Password = "admin",
                    Role = "admin"
                },
                new login
                {
                    Username = "planner",
                    Password = "planner",
                    Role = "planner"
                },
                new login
                {
                    Username = "buyer",
                    Password = "buyer",
                    Role = "buyer"
                }
            );
        }
    }
}
