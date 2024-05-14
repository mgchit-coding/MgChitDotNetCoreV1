using MgChitDotNetCore.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgChitDotNetCore.Shared.Services
{
    public class AppDbContext:DbContext
    {
        public string GetConnection()
        {
            var connection = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            return connection.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnection());
        }
        public DbSet<BlogDataModel> Blog { get; set; }
    }
}
