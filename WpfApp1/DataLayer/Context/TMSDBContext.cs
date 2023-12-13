using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public class TMSDBContext : DbContext
{
    public DbSet<Login> Login { get; set; }
    public DbSet<Carrier> Carrier { get; set; }

    private static readonly DbContextOptions<TMSDBContext> options = new DbContextOptionsBuilder<TMSDBContext>()
        .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
        .Options;

    public TMSDBContext() : base(options)
    {
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "server=localhost;port=3306;database=TMS;user=root;password=9487;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Carrier>(entity => { entity.Property(e => e.cID).ValueGeneratedOnAdd(); }
        );

        modelBuilder.Entity<Login>().HasData(
            new Login
            {
                Username = "admin",
                Password = "admin",
                Role = "admin"
            },
            new Login
            {
                Username = "planner",
                Password = "planner",
                Role = "planner"
            },
            new Login
            {
                Username = "buyer",
                Password = "buyer",
                Role = "buyer"
            }
        );

        modelBuilder.Entity<Carrier>().HasData(
            new Carrier
            {
                cID = 1,
                cName = "Planet Express",
                dCity = "Windsor",
                FTLA = 50,
                LTLA = 640,
                FTLARate = 5.21,
                LTLRate = 0.3621,
                reefCharge = 0.08
            },
            new Carrier
            {
                cID = 2,
                cName = "Planet Express",
                dCity = "Hamilton",
                FTLA = 50,
                LTLA = 640,
                FTLARate = 5.21,
                LTLRate = 0.3621,
                reefCharge = 0.08
            },
            new Carrier
            {
                cID = 3,
                cName = "Planet Express",
                dCity = "Oshawa",
                FTLA = 50,
                LTLA = 640,
                FTLARate = 5.21,
                LTLRate = 0.3621,
                reefCharge = 0.08
            },
            new Carrier
            {
                cID = 4,
                cName = "Planet Express",
                dCity = "Belleville",
                FTLA = 50,
                LTLA = 640,
                FTLARate = 5.21,
                LTLRate = 0.3621,
                reefCharge = 0.08
            },
            new Carrier
            {
                cID = 5,
                cName = "Planet Express",
                dCity = "Ottawa",
                FTLA = 50,
                LTLA = 640,
                FTLARate = 5.21,
                LTLRate = 0.3621,
                reefCharge = 0.08
            },
            new Carrier
            {
                cID = 6,
                cName = "Schooner's",
                dCity = "London",
                FTLA = 18,
                LTLA = 98,
                FTLARate = 5.05,
                LTLRate = 0.3434,
                reefCharge = 0.07
            },
            new Carrier
            {
                cID = 7,
                cName = "Schooner's",
                dCity = "Toronto",
                FTLA = 18,
                LTLA = 98,
                FTLARate = 5.05,
                LTLRate = 0.3434,
                reefCharge = 0.07
            },
            new Carrier
            {
                cID = 8,
                cName = "Schooner's",
                dCity = "Kingston",
                FTLA = 18,
                LTLA = 98,
                FTLARate = 5.05,
                LTLRate = 0.3434,
                reefCharge = 0.07
            },
            new Carrier
            {
                cID = 9,
                cName = "Tillman Transport",
                dCity = "Windsor",
                FTLA = 24,
                LTLA = 35,
                FTLARate = 5.11,
                LTLRate = 0.3012,
                reefCharge = 0.09
            },
            new Carrier
            {
                cID = 10,
                cName = "Tillman Transport",
                dCity = "London",
                FTLA = 18,
                LTLA = 45,
                FTLARate = 5.11,
                LTLRate = 0.3012,
                reefCharge = 0.09
            },
            new Carrier
            {
                cID = 11,
                cName = "Tillman Transport",
                dCity = "Hamilton",
                FTLA = 18,
                LTLA = 45,
                FTLARate = 5.11,
                LTLRate = 0.3012,
                reefCharge = 0.09
            },
            new Carrier
            {
                cID = 12,
                cName = "We Haul",
                dCity = "Ottawa",
                FTLA = 11,
                LTLA = 0,
                FTLARate = 5.2,
                LTLRate = 0,
                reefCharge = 0.065
            },
            new Carrier
            {
                cID = 13,
                cName = "We Haul",
                dCity = "Toronto",
                FTLA = 11,
                LTLA = 0,
                FTLARate = 5.2,
                LTLRate = 0,
                reefCharge = 0.065
            }
        );
    }
}