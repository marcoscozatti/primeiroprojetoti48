using System.Data;
using System.Data.SqlClient;

public class Connection
{
    private SqlConnection conn;

    private string connectionString = @"Server=SEU_SERVIDOR;Database=AgendaDB;Trusted_Connection=True;";

    public SqlConnection Connect()
    {
        conn = new SqlConnection(connectionString);

        if (conn.State == ConnectionState.Closed)
            conn.Open();

        return conn;
    }

    public void Disconnect()
    {
        if (conn != null && conn.State == ConnectionState.Open)
            conn.Close();
    }
}