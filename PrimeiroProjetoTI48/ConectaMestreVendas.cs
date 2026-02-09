using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoTI48
{
    public class ConectaMestreVendas
    {

        public string conec = @"Data Source=JUN0684676W11-1\BDSENAC;
                              Initial Catalog=BDComercio;
                              Persist Security Info=True;
                              User ID=senaclivre;Password=senaclivre";

        //public string conec = @"Data Source=MarcosCozatti\SQLEXPRESS;
        //                      Initial Catalog=BDComercioTi46;
        //                      Persist Security Info=True;
        //                      User ID=sa;Password=senaclivre";

        public SqlConnection con = null;
        SqlDataAdapter da = null;

        //Replica tabelas

        //MestreVendas
        public int id_MestreVendas { get; set; }
        public int idcliente { get; set; }
        public DateTime DataCompra { get; set; }

    


        //CRUD CADCLI
        public void CadMestreVendas()
        {
            string sql;
            SqlCommand cmd;
            con = new SqlConnection(conec);
            sql = "INSERT INTO MestreVendas (idcliente, DataCompra) " +
                "VALUES (@idcliente, @DataCompra)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idcliente", idcliente);
            cmd.Parameters.AddWithValue("@DataCompra", DataCompra);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Mestre de vendas adicionado!");
            con.Close();




        }




    }
}
