using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Connection
{
    private SqlConnection conn;

    private string connectionString = @"Data Source=JUN0684676W11-1\BDSENAC;Initial Catalog=AgendaDB;User Id=senaclivre;Password=senaclivre;";

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