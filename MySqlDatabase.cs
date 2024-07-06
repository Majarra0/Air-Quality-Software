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
        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
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