using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoTI48
{
    public partial class frmAgendda : Form
    {
        public frmAgendda()
        {
            InitializeComponent();
        }

        bool EmailValido(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void frmAgendda_Load(object sender, EventArgs e)
        {
            txtNome.Focus();

        }

        List<Contato> lista = new List<Contato>();
        int proximoId = 1;


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();

        }

        private void AtualizarGrid()
        {
            dg.DataSource = null;
            dg.DataSource = lista;
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var contato = lista[e.RowIndex];

                txtID.Text = contato.ID.ToString();
                txtNome.Text = contato.Nome;
                txtTelefone.Text = contato.Telefone;
                txtEmail.Text = contato.Email;
                txtDateTimePiker.Value = contato.DataRegistro;
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Validações básicas
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome!");
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido!");
                return;
            }

            // Criar novo contato
            Contato c = new Contato();
            c.ID = proximoId++;
            c.Nome = txtNome.Text;
            c.Telefone = txtTelefone.Text;
            c.Email = txtEmail.Text;
            c.DataRegistro = txtDateTimePiker.Value;

            // Adicionar na lista
            lista.Add(c);

            // Atualizar DataGrid
            AtualizarGrid();

            // Limpar campos
            LimparCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione um registro para alterar!");
                return;
            }

            int id = int.Parse(txtID.Text);

            Contato contato = lista.FirstOrDefault(c => c.ID == id);

            if (contato == null)
            {
                MessageBox.Show("Registro não encontrado!");
                return;
            }

            // Atualizar dados
            contato.Nome = txtNome.Text;
            contato.Telefone = txtTelefone.Text;
            contato.Email = txtEmail.Text;
            contato.DataRegistro = txtDateTimePiker.Value;

            AtualizarGrid();
            MessageBox.Show("Registro alterado com sucesso!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione um registro para excluir!");
                return;
            }

            if (MessageBox.Show("Deseja excluir este registro?", "Confirmação",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int id = int.Parse(txtID.Text);

            Contato contato = lista.FirstOrDefault(c => c.ID == id);

            if (contato != null)
            {
                lista.Remove(contato);
                AtualizarGrid();
                LimparCampos();

                MessageBox.Show("Registro excluído com sucesso!");
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AtualizarGrid();

        }
    }
}
