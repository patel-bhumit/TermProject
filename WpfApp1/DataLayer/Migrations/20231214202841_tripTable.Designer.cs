﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(TMSDBContext))]
    [Migration("20231214202841_tripTable")]
    partial class tripTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataLayer.Model.Carrier", b =>
                {
                    b.Property<int>("cID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("FTLA")
                        .HasColumnType("int");

                    b.Property<double>("FTLARate")
                        .HasColumnType("double");

                    b.Property<int>("LTLA")
                        .HasColumnType("int");

                    b.Property<double>("LTLRate")
                        .HasColumnType("double");

                    b.Property<string>("cName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("reefCharge")
                        .HasColumnType("double");

                    b.HasKey("cID");

                    b.HasIndex("CityId");

                    b.ToTable("Carrier");

                    b.HasData(
                        new
                        {
                            cID = 1,
                            CityId = 1,
                            FTLA = 50,
                            FTLARate = 5.21,
                            LTLA = 640,
                            LTLRate = 0.36209999999999998,
                            cName = "Planet Express",
                            dCity = "Windsor",
                            reefCharge = 0.080000000000000002
                        },
                        new
                        {
                            cID = 2,
                            CityId = 2,
                            FTLA = 50,
                            FTLARate = 5.21,
                            LTLA = 640,
                            LTLRate = 0.36209999999999998,
                            cName = "Planet Express",
                            dCity = "Hamilton",
                            reefCharge = 0.080000000000000002
                        },
                        new
                        {
                            cID = 3,
                            CityId = 3,
                            FTLA = 50,
                            FTLARate = 5.21,
                            LTLA = 640,
                            LTLRate = 0.36209999999999998,
                            cName = "Planet Express",
                            dCity = "Oshawa",
                            reefCharge = 0.080000000000000002
                        },
                        new
                        {
                            cID = 4,
                            CityId = 4,
                            FTLA = 50,
                            FTLARate = 5.21,
                            LTLA = 640,
                            LTLRate = 0.36209999999999998,
                            cName = "Planet Express",
                            dCity = "Belleville",
                            reefCharge = 0.080000000000000002
                        },
                        new
                        {
                            cID = 5,
                            CityId = 5,
                            FTLA = 50,
                            FTLARate = 5.21,
                            LTLA = 640,
                            LTLRate = 0.36209999999999998,
                            cName = "Planet Express",
                            dCity = "Ottawa",
                            reefCharge = 0.080000000000000002
                        },
                        new
                        {
                            cID = 6,
                            CityId = 6,
                            FTLA = 18,
                            FTLARate = 5.0499999999999998,
                            LTLA = 98,
                            LTLRate = 0.34339999999999998,
                            cName = "Schooner's",
                            dCity = "London",
                            reefCharge = 0.070000000000000007
                        },
                        new
                        {
                            cID = 7,
                            CityId = 7,
                            FTLA = 18,
                            FTLARate = 5.0499999999999998,
                            LTLA = 98,
                            LTLRate = 0.34339999999999998,
                            cName = "Schooner's",
                            dCity = "Toronto",
                            reefCharge = 0.070000000000000007
                        },
                        new
                        {
                            cID = 8,
                            CityId = 8,
                            FTLA = 18,
                            FTLARate = 5.0499999999999998,
                            LTLA = 98,
                            LTLRate = 0.34339999999999998,
                            cName = "Schooner's",
                            dCity = "Kingston",
                            reefCharge = 0.070000000000000007
                        },
                        new
                        {
                            cID = 9,
                            CityId = 1,
                            FTLA = 24,
                            FTLARate = 5.1100000000000003,
                            LTLA = 35,
                            LTLRate = 0.30120000000000002,
                            cName = "Tillman Transport",
                            dCity = "Windsor",
                            reefCharge = 0.089999999999999997
                        },
                        new
                        {
                            cID = 10,
                            CityId = 6,
                            FTLA = 18,
                            FTLARate = 5.1100000000000003,
                            LTLA = 45,
                            LTLRate = 0.30120000000000002,
                            cName = "Tillman Transport",
                            dCity = "London",
                            reefCharge = 0.089999999999999997
                        },
                        new
                        {
                            cID = 11,
                            CityId = 2,
                            FTLA = 18,
                            FTLARate = 5.1100000000000003,
                            LTLA = 45,
                            LTLRate = 0.30120000000000002,
                            cName = "Tillman Transport",
                            dCity = "Hamilton",
                            reefCharge = 0.089999999999999997
                        },
                        new
                        {
                            cID = 12,
                            CityId = 5,
                            FTLA = 11,
                            FTLARate = 5.2000000000000002,
                            LTLA = 0,
                            LTLRate = 0.0,
                            cName = "We Haul",
                            dCity = "Ottawa",
                            reefCharge = 0.065000000000000002
                        },
                        new
                        {
                            cID = 13,
                            CityId = 7,
                            FTLA = 11,
                            FTLARate = 5.2000000000000002,
                            LTLA = 0,
                            LTLRate = 0.0,
                            cName = "We Haul",
                            dCity = "Toronto",
                            reefCharge = 0.065000000000000002
                        });
                });

            modelBuilder.Entity("DataLayer.Model.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CityId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Windsor"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "Hamilton"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Oshawa"
                        },
                        new
                        {
                            CityId = 4,
                            Name = "BelleVille"
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Ottawa"
                        },
                        new
                        {
                            CityId = 6,
                            Name = "London"
                        },
                        new
                        {
                            CityId = 7,
                            Name = "Toronto"
                        },
                        new
                        {
                            CityId = 8,
                            Name = "Kingston"
                        });
                });

            modelBuilder.Entity("DataLayer.Model.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VanType")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataLayer.Model.DataLayer.Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VanType")
                        .HasColumnType("int");

                    b.Property<int?>("cID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("cID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DataLayer.Model.LogEntry", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LogLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("LogId");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("DataLayer.Model.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DestinationCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("cID")
                        .HasColumnType("int");

                    b.HasKey("RouteID");

                    b.HasIndex("cID");

                    b.ToTable("Route");

                    b.HasData(
                        new
                        {
                            RouteID = 1,
                            CarrierName = "Planet Express",
                            DestinationCity = "Windsor",
                            cID = 1
                        },
                        new
                        {
                            RouteID = 2,
                            CarrierName = "Planet Express",
                            DestinationCity = "Hamilton",
                            cID = 2
                        },
                        new
                        {
                            RouteID = 3,
                            CarrierName = "Planet Express",
                            DestinationCity = "Oshawa",
                            cID = 3
                        },
                        new
                        {
                            RouteID = 4,
                            CarrierName = "Planet Express",
                            DestinationCity = "Belleville",
                            cID = 4
                        },
                        new
                        {
                            RouteID = 5,
                            CarrierName = "Planet Express",
                            DestinationCity = "Ottawa",
                            cID = 5
                        },
                        new
                        {
                            RouteID = 6,
                            CarrierName = "Schooner's",
                            DestinationCity = "London",
                            cID = 6
                        },
                        new
                        {
                            RouteID = 7,
                            CarrierName = "Schooner's",
                            DestinationCity = "Toronto",
                            cID = 7
                        },
                        new
                        {
                            RouteID = 8,
                            CarrierName = "Schooner's",
                            DestinationCity = "Kingston",
                            cID = 8
                        },
                        new
                        {
                            RouteID = 9,
                            CarrierName = "Tillman Transport",
                            DestinationCity = "Windsor",
                            cID = 9
                        },
                        new
                        {
                            RouteID = 10,
                            CarrierName = "Tillman Transport",
                            DestinationCity = "London",
                            cID = 10
                        },
                        new
                        {
                            RouteID = 11,
                            CarrierName = "Tillman Transport",
                            DestinationCity = "Hamilton",
                            cID = 11
                        },
                        new
                        {
                            RouteID = 12,
                            CarrierName = "We Haul",
                            DestinationCity = "Ottawa",
                            cID = 12
                        },
                        new
                        {
                            RouteID = 13,
                            CarrierName = "We Haul",
                            DestinationCity = "Toronto",
                            cID = 13
                        });
                });

            modelBuilder.Entity("DataLayer.Model.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AssignDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CarrierID")
                        .HasColumnType("int");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.HasIndex("CarrierID");

                    b.HasIndex("OrderID");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("DataLayer.Model.login", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Username");

                    b.ToTable("login");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            Password = "admin",
                            Role = "admin"
                        },
                        new
                        {
                            Username = "planner",
                            Password = "planner",
                            Role = "planner"
                        },
                        new
                        {
                            Username = "buyer",
                            Password = "buyer",
                            Role = "buyer"
                        });
                });

            modelBuilder.Entity("DataLayer.Model.Carrier", b =>
                {
                    b.HasOne("DataLayer.Model.City", null)
                        .WithMany("Carriers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Model.DataLayer.Model.Order", b =>
                {
                    b.HasOne("DataLayer.Model.Carrier", "Carrier")
                        .WithMany("Orders")
                        .HasForeignKey("cID");

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("DataLayer.Model.Route", b =>
                {
                    b.HasOne("DataLayer.Model.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("cID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("DataLayer.Model.Trip", b =>
                {
                    b.HasOne("DataLayer.Model.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Model.DataLayer.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataLayer.Model.Carrier", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataLayer.Model.City", b =>
                {
                    b.Navigation("Carriers");
                });
#pragma warning restore 612, 618
        }
    }
}
