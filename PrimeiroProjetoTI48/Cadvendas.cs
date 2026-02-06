using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoTI48
{
    public partial class Cadvendas : Form
    {
        public Cadvendas()
        {
            InitializeComponent();
        }

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


        ConectaMestreVendas MestreVendas = new ConectaMestreVendas();
        ConectaItensVendas itensVendas = new ConectaItensVendas();

        private void Cadvendas_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MestreVendas.idcliente = int.Parse(txtIDCliente.Text);
            MestreVendas.DataCompra = DateTime.Parse(txtDataCompra.Text);


            MestreVendas.CadMestreVendas();



            //limpadados();
            //atualizaGrid();
        }

        private void btnInclulirSacola(object sender, EventArgs e)
        {
            itensVendas.idItensVenda = int.Parse(txtIdprod.Text);

            // Buscar o idMestreVendas gerado
            int idMestreVendas = itensVendas.PegaUltimoIdMestreVendas();

            itensVendas.idprod = int.Parse(txtIdprod.Text);
            itensVendas.qtde = int.Parse(txtQuantidade.Text);
            itensVendas.precoUnit = decimal.Parse(txtPrecoUnit.Text);
            if (txtDesconto.Text == "")
            {
                txtDesconto.Text = "0"; // Se o campo de desconto estiver vazio, define como 0
            }
            else
            {
                txtDesconto.Text = txtDesconto.Text; // Mantém o valor digitado
            }
            itensVendas.desconto = decimal.Parse(txtDesconto.Text);
            itensVendas.total = decimal.Parse(txtTotal.Text);
          


            itensVendas.CadItensVendas();

           // dgVendas.DataSource = itensVendas.AtualizaGride(dt, idMestreVendas);
            //limpadados();
        }
    }
}
