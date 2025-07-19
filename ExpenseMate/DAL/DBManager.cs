using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExpenseMate.DAL
{
    public class DBManager
    {
        private static string _connectionString = string.Empty;

        public static void Initialize(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found.");
        }

        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new(query, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new(query, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            con.Open();
            return cmd.ExecuteScalar();
        }

        public static List<T> ExecuteReader<T>(string query, SqlParameter[]? parameters, Func<SqlDataReader, T> readFunc)
        {
            List<T> result = new();
            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new(query, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add(readFunc(reader));
            return result;
        }
    }
}
