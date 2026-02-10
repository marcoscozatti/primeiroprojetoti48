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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            txtTotal.Enabled = false;
            txtProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            btnInciarVendas.Enabled = false;
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


        //---------------------------------------------------------------------------
        ///  Botão incluir sacola
        ///  Aqui é onde o usuário pode incluir os itens da venda, preenchendo os campos de 
        ///  id do produto, quantidade, preço unitário, desconto e total.
        ///  Implementando hoje dia 10/02/2025 o cálculo do valor total da venda, somando os 
        ///  totais dos itens incluídos na sacola, e mostrando o valor total na textbox txtValTOT.
        ///  lembrando dos descontos.
        ///  ----------------------------------------------------------------------------------------------
        private void btnInclulirSacola(object sender, EventArgs e)
        {
            try
            {
                // 1. Captura os valores básicos dos campos
                int idProduto = int.Parse(txtIdprod.Text);
                int quantidade = int.Parse(txtQuantidade.Text);
                decimal precoUnitario = decimal.Parse(txtPrecoUnit.Text);

                // 2. Trata o Desconto Percentual
                // Se o campo estiver vazio, considera 0. Se não, converte o valor digitado.
                decimal percentualDesconto = 0;
                if (!string.IsNullOrEmpty(txtDesconto.Text))
                {
                    percentualDesconto = decimal.Parse(txtDesconto.Text);
                }

                // 3. LÓGICA DO CÁLCULO (PORCENTAGEM)
                decimal subtotal = quantidade * precoUnitario;
                decimal valorDescontoDinheiro = subtotal * (percentualDesconto / 100);
                decimal valorTotalComDesconto = subtotal - valorDescontoDinheiro;

                // Atualiza o campo de Total na tela para o usuário ver
                txtTotal.Text = valorTotalComDesconto.ToString("N2");

                // 4. ALIMENTA O OBJETO PARA O BANCO DE DADOS
                itensVendas.idprod = idProduto;
                itensVendas.qtde = quantidade;
                itensVendas.precoUnit = precoUnitario;

                // Aqui você decide: salvar o % ou o valor em R$ que foi descontado. 
                // Geralmente salva-se o valor em R$ do desconto:
                itensVendas.desconto = valorDescontoDinheiro;
                itensVendas.total = valorTotalComDesconto;

                // 5. PERSISTÊNCIA
                // Busca o ID da venda principal (Mestre)
                int idMestreVendas = itensVendas.PegaUltimoIdMestreVendas();

                // Salva o item no banco
                itensVendas.CadItensVendas();

                // 6. ATUALIZAÇÃO DA INTERFACE
                atualizaGride();

                // Atualiza a soma total de todos os itens da sacola
                decimal valorTotalVenda = itensVendas.CalculaValorTotal(idMestreVendas);
                txtValTOT.Text = valorTotalVenda.ToString("N2");

                // Limpa os campos para o próximo produto
                limpadadosProdutos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, preencha os campos de quantidade, preço e desconto corretamente.", "Erro de preenchimento");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao incluir na sacola: " + ex.Message);
            }
        }






        // Método para limpar os campos de produto após incluir um item na sacola
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


        // Método para atualizar o DataGridView com os itens da venda
        private void atualizaGride()
        {
            DataTable dt = new DataTable();
            dgvItens.DataSource = itensVendas.AtualizaGride(dt);
            //atualização de gride para mostrar os itens da venda
        }


        // Evento para preencher os campos de edição ao clicar duas vezes em um item do DataGridView
        private void dgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdprod.Text = dgvItens.CurrentRow.Cells[0].Value.ToString();
            txtQuantidade.Text = dgvItens.CurrentRow.Cells[1].Value.ToString();
            txtPrecoUnit.Text = dgvItens.CurrentRow.Cells[2].Value.ToString();
            txtDesconto.Text = dgvItens.CurrentRow.Cells[3].Value.ToString();
            txtTotal.Text = dgvItens.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
