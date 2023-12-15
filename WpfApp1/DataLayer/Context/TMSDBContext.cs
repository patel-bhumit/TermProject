using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;
using DataLayer.Model.DataLayer.Model;

namespace DataLayer.Context
{
    public class TMSDBContext : DbContext
    {
        public DbSet<login> Login { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Route> Route { get; set; }

        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Trip> Trip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=localhost;port=3306;database=TMS;user=root;password=9487;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, Name = "Windsor" },
                new City { CityId = 2, Name = "Hamilton" },
                new City { CityId = 3, Name = "Oshawa" },
                new City { CityId = 4, Name = "BelleVille" },
                new City { CityId = 5, Name = "Ottawa" },
                new City { CityId = 6, Name = "London" },
                new City { CityId = 7, Name = "Toronto" },
                new City { CityId = 8, Name = "Kingston" }

                // Add more cities as needed
            );

            modelBuilder.Entity<Carrier>( entity =>
            {
                entity.Property(e => e.cID).ValueGeneratedOnAdd();
            }
            );



            modelBuilder.Entity<LogEntry>().HasKey(l => l.LogId);

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);

            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);

            modelBuilder.Entity<Trip>().HasKey(r => r.TripID);

            modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceID);


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
                    reefCharge = 0.08,
                    CityId = 1
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
                    reefCharge = 0.08,
                    CityId = 2
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
                    reefCharge = 0.08,
                    CityId = 3
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
                    reefCharge = 0.08,
                    CityId = 4
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
                    reefCharge = 0.08,
                    CityId = 5
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
                    reefCharge = 0.07,
                    CityId = 6
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
                    reefCharge = 0.07,
                    CityId = 7
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
                    reefCharge = 0.07,
                    CityId = 8
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
                    reefCharge = 0.09,
                    CityId = 1
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
                    reefCharge = 0.09,
                    CityId = 6
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
                    reefCharge = 0.09,
                    CityId = 2
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
                    reefCharge = 0.065,
                    CityId = 5
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
                    reefCharge = 0.065,
                    CityId = 7
                }
                );
        

        modelBuilder.Entity<Route>().HasData(
                new Route
                {
                    RouteID = 1,
                    cID = 1,
                    CarrierName = "Planet Express",
                    DestinationCity = "Windsor"
                },
                new Route
                {
                    RouteID = 2,
                    cID = 2,
                    CarrierName = "Planet Express",
                    DestinationCity = "Hamilton"
                },
                new Route
                {
                    RouteID = 3,
                    cID = 3,
                    CarrierName = "Planet Express",
                    DestinationCity = "Oshawa"
                },
                new Route
                {
                    RouteID = 4,
                    cID = 4,
                    CarrierName = "Planet Express",
                    DestinationCity = "Belleville"
                },
                new Route
                {
                    RouteID = 5,
                    cID = 5,
                    CarrierName = "Planet Express",
                    DestinationCity = "Ottawa"
                },
                new Route
                {
                    RouteID = 6,
                    cID = 6,
                    CarrierName = "Schooner's",
                    DestinationCity = "London"
                },
                new Route
                {
                    RouteID = 7,
                    cID = 7,
                    CarrierName = "Schooner's",
                    DestinationCity = "Toronto"
                },
                new Route
                {RouteID = 8,
                    cID = 8,
                    CarrierName = "Schooner's",
                    DestinationCity = "Kingston"
                },
                new Route
                {RouteID = 9,
                    cID = 9,
                    CarrierName = "Tillman Transport",
                    DestinationCity = "Windsor"
                },
                new Route
                {RouteID = 10,
                    cID = 10,
                    CarrierName = "Tillman Transport",
                    DestinationCity = "London"
                },
                new Route
                {RouteID = 11,
                    cID = 11,
                    CarrierName = "Tillman Transport",
                    DestinationCity = "Hamilton"
                },
                new Route
                {RouteID = 12,
                    cID = 12,
                    CarrierName= "We Haul",
                    DestinationCity = "Ottawa"
                },
                new Route
                {RouteID = 13,
                    cID = 13,
                    CarrierName = "We Haul",
                    DestinationCity = "Toronto"
                }
                );
        }
    }
}
