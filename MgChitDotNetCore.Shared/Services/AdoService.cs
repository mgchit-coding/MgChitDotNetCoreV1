﻿using System.Data;
using System.Data.SqlClient;

namespace MgChitDotNetCore.Shared.Services
{
    public class AdoService
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
        private DataTable Get(string query, Dictionary<string, object>? keyValues = null)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (keyValues != null)
                    cmd.Parameters.AddRange(keyValues.ToArray());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                connection.Close();
            }
            return dt;
        }

        private int ExecuteQuery(string query, Dictionary<string, object>? keyValues = null)
        {
            int result = 0;
            using (var connection = new SqlConnection(GetConnection()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (keyValues != null)
                    cmd.Parameters.AddRange(keyValues.ToArray());
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }

        public T GetLst<T>(string query, Dictionary<string, object>? keyValues = null)
        {
            var dt = Get(query, keyValues);
            var jsonStr = dt.ToJson();
            var jsonObj = jsonStr.ToObject<T>();
            return jsonObj;
        }

        public T GetItem<T>(string query, Dictionary<string, object>? keyValues = null)
        {
            var dt = Get(query, keyValues);
            var jsonStr = dt.ToJson();
            var jsonObj = jsonStr.ToObject<List<T>>();
            return jsonObj.FirstOrDefault();
        }

        public int Execute(string query, Dictionary<string, object>? keyValues = null)
        {
            var result = ExecuteQuery(query, keyValues);
            return result;
        }
    }
}
