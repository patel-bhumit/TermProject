using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class ContractDB : DbContext
    {
        public static DataView? DefaultView { get; set; }

        // DbSet for the Contract entity
        public DbSet<Model.Contract> Contract { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=159.89.117.198;port=3306;database=cmp;user=DevOSHT;password=Snodgr4ss!;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
