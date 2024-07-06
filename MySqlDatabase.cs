using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace WebApplication8
{
public class MySqlDatabase
{
    private string connectionString;

    public MySqlDatabase()
    {
            connectionString = "server=roundhouse.proxy.rlwy.net;port=14081;database=railway;uid=root;pwd=dyVffpqiLLedigOgxJLUvvRpXNfLffel;";
    }

    public DataTable GetData(string query)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
}