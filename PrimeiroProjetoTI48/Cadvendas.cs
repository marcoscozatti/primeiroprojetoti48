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
            vendaBloqueada();




        }

        private void vendaDesBloqueada()
        {
            txtIDVenda.Enabled = true;
            txtIDCliente.Enabled = true;
            txtCliente.Enabled = true;
            txtDataCompra.Enabled = true;
            btnIncluirSacola.Enabled = true;
            txtIdprod.Enabled = true;
            txtProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtPrecoUnit.Enabled = true;
            txtDesconto.Enabled = true;
            txtTotal.Enabled = true;
            txtProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            btnInciarVendas.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;

        }

        private void vendaBloqueada()
        {
            txtIDVenda.Enabled = true;
            txtIDCliente.Enabled = true;
            txtCliente.Enabled = true;
            txtDataCompra.Enabled = true;
            btnIncluirSacola.Enabled = false;
            txtIdprod.Enabled = false;
            txtProduto.Enabled = false;
            txtQuantidade.Enabled = false;  
            txtPrecoUnit.Enabled = false;
            txtDesconto.Enabled = false;
            txtTotal.Enabled = false;
            txtProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            btnInciarVendas.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

        }


        
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text == "" || txtDataCompra.Text == "")
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            MestreVendas.idcliente = int.Parse(txtIDCliente.Text);

            try
            {
                MestreVendas.DataCompra = DateTime.Parse(txtDataCompra.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show(x + "  - Data de compra inválida. Por favor, insira uma data válida.");
                return;
            }
            
            




            MestreVendas.CadMestreVendas();


            vendaDesBloqueada();
            txtIdprod.Focus();

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

            DataTable dt = new DataTable();
            atualizaGride();
         
            //mostra valor da soma dos produtos na textbox total
            decimal valorTotal = itensVendas.CalculaValorTotal(idMestreVendas);
            txtValTOT.Text = valorTotal.ToString("F2"); // Formata o valor para 2 casas decimais


            limpadadosProdutos();
        }

        private void limpadadosProdutos()
        {
            txtIdprod.Clear();
            txtProduto.Clear();
            txtQuantidade.Clear();
            txtPrecoUnit.Clear();   
            txtQuantidade.Clear();
            txtDesconto.Clear();
            txtTotal.Clear();
            txtIdprod.Focus();

        }

        private void atualizaGride()
        {
            DataTable dt = new DataTable();
            dgvItens.DataSource = itensVendas.AtualizaGride(dt);
            //atualização de gride para mostrar os itens da venda
        }
    }
}
