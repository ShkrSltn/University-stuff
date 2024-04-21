using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Library
{
    public class ConnectionBD : DbContext
    {
        NpgsqlConnection npgsqlConnection;
        public ConnectionBD(string value)
        {
            npgsqlConnection = new NpgsqlConnection($"User ID={value};Password=shakir95;Host=localhost;Port=5432;Database=DeLibre;");
        }
        public void OpenConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Closed)
            {
                npgsqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Open)
            {
                npgsqlConnection.Close();
            }
        }
        public NpgsqlConnection getConnection()
        {
            return npgsqlConnection;
        }
    }
}
