using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoTI48
{
    public class ConectaItensVendas
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
        public int idItensVenda  { get; set; }
        public int IdVenda { get; set; }
        public int idprod { get; set; }
        public int qtde { get; set; }
        public decimal precoUnit { get; set; }
        public decimal desconto { get; set; }
        public decimal total { get; set; }
       


        //CRUD CADCLI
        public void CadItensVendas()
        {
            string sql;
            SqlCommand cmd;
            con = new SqlConnection(conec);
            sql = "INSERT INTO ItensVenda (IdVenda, idprod, qtde, precoUnit, desconto, total) " +
                "VALUES (@IdVenda, @idprod, @qtde,@precoUnit, @desconto, @total)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@IdVenda", PegaUltimoIdMestreVendas());
            cmd.Parameters.AddWithValue("@idprod", idprod);
            cmd.Parameters.AddWithValue("@qtde", qtde);
            cmd.Parameters.AddWithValue("@PrecoUnit", precoUnit);
            cmd.Parameters.AddWithValue("@Desconto", desconto);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item de vendas adicionado!");
            con.Close();

        }



        public int PegaUltimoIdMestreVendas()
        {
            int idOutraTabela = 0;
            //string connectionString = @"Data Source=JUN0684686W11-1\BDSENAC; " +
            //                          "Initial Catalog=BDComercio; " +
            //                          "Persist Security Info=True; " +
            //                          "User ID=senaclivre;Password=senaclivre";

            string connectionString = @"Data Source=JUN0684676W11-1\BDSENAC;
                                    Initial Catalog=BDComercio;
                                    Persist Security Info=True;
                                    User ID=senaclivre;Password=senaclivre";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 id_MestreVendas FROM MestreVendas ORDER BY id_MestreVendas DESC";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    idOutraTabela = reader.GetInt32(0);
                }

                reader.Close();
            }

            return idOutraTabela;
        }

      
        public DataTable AtualizaGride(DataTable x)
        {
            string query = "SELECT TOP 1 id_MestreVendas FROM MestreVendas ORDER BY id_MestreVendas DESC";

            string strSql;
            //strSql = "SELECT * FROM MestreVendas where id_MestreVendas = (SELECT TOP 1 id_MestreVendas FROM MestreVendas ORDER BY id_MestreVendas DESC)";
            strSql = "SELECT idprod, qtde, precoUnit, desconto, total FROM ItensVenda where idVenda =  (SELECT TOP 1 id_MestreVendas FROM MestreVendas ORDER BY id_MestreVendas DESC)";

            con = new SqlConnection(conec);
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            x = dt;
            con.Close();
            return x;

        }

        //internal decimal CalculaValorTotal(int idMestreVendas)
        //{

        //}


        public decimal CalculaValorTotal(int idVenda)
        {
            decimal totalGeral = 0;

            string connectionString = @"Data Source=JUN0684676W11-1\BDSENAC;
                                    Initial Catalog=BDComercio;
                                    Persist Security Info=True;
                                    User ID=senaclivre;Password=senaclivre";



            // String de conexão (use a que você já tem definida na sua classe)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // A função SUM(total) do SQL faz todo o trabalho de soma para você
                string sql = "SELECT SUM(total) from ItensVenda WHERE idVenda  = @idVenda";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idVenda", idVenda);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    // Se o resultado não for nulo, converte para decimal
                    if (resultado != DBNull.Value && resultado != null)
                    {
                        totalGeral = Convert.ToDecimal(resultado);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao calcular total da venda: " + ex.Message);
                }
            }

            return totalGeral;
        }



        int idOutraTabela = 0;




    }
}
