using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

namespace DoctorWho.Db
{
    // Declare the DoctorWhoCoreDbContext class and inherit from DbContext
    public class DoctorWhoCoreDbContext : DbContext
    {
        // Define a constructor that takes in a DbContextOptions<DoctorWhoCoreDbContext> object
        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options) : base(options) // Pass the options object to the base class constructor
        {
        }

        // Override the OnConfiguring method to configure the database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the UseSqlServer method to configure the connection string to use SQL Server
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-COT3PQTF\\SQLEXPRESS; Initial Catalog=DoctorWhoCore")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }
    }
}
