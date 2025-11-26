using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        Connection con = new Connection();


        bool EmailValido(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void frmAgendda_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            AtualizarGrid();
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
            txtNome.Focus();
        }

        private void AtualizarGrid()
        {
            using (SqlConnection conn = con.Connect())
            {
                string sql = "SELECT * FROM Contatos";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dg.DataSource = dt;
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    txtID.Text = dg.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    txtNome.Text = dg.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                    txtTelefone.Text = dg.Rows[e.RowIndex].Cells["Telefone"].Value.ToString();
                    txtEmail.Text = dg.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    txtDateTimePiker.Value = Convert.ToDateTime(dg.Rows[e.RowIndex].Cells["DataRegistro"].Value);
                }
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = con.Connect())
                {
                    string sql = @"INSERT INTO Contatos 
                           (Nome, Telefone, Email, DataRegistro)
                           VALUES (@Nome, @Telefone, @Email, @DataRegistro)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@DataRegistro", txtDateTimePiker.Value);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registro inserido!");
                AtualizarGrid();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
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

            using (SqlConnection conn = con.Connect())
            {
                string sql = @"UPDATE Contatos 
                       SET Nome=@Nome, Telefone=@Telefone, Email=@Email, DataRegistro=@DataRegistro
                       WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DataRegistro", txtDateTimePiker.Value);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Registro alterado!");
            AtualizarGrid(); ;
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione um registro para excluir!");
                return;
            }

            using (SqlConnection conn = con.Connect())
            {
                string sql = "DELETE FROM Contatos WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Registro excluído!");
            AtualizarGrid();
            LimparCampos();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AtualizarGrid();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
