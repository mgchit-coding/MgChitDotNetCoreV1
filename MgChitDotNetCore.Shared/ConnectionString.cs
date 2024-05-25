using System.Data.SqlClient;

namespace MgChitDotNetCore.Shared;

public class ConnectionString
{
    public static string GetConnection()
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
}
