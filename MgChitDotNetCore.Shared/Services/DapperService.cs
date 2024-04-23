using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<T>> Get<T>(string query, object? model = default)
        {
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                var lst = await db.QueryAsync<T>(query,model);
                return lst.ToList();
            }
        }

        public async Task<T?> GetItem<T>(string query, object? model = default)
        {
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                var item = await db.QueryFirstOrDefaultAsync<T>(query, model);
                return item;
            }
        }

        public async Task<int> Execute(string query, object? model = default)
        {
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                var item = await db.ExecuteAsync(query, model);
                return item;
            }
        }
    }
}
