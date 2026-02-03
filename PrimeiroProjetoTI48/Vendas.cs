using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoTI48
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CadClientes cadClientes = new CadClientes();
            cadClientes.ShowDialog();


        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgendda agendda = new frmAgendda();
            agendda.ShowDialog();
        }
    }
}
