using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgChitDotNetCore.Shared.Services
{
    public class DapperService
    {
        public string GetConnection()
        {
            var connection = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
            };
            return connection.ConnectionString;
        }
    }
}
