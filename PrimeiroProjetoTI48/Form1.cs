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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            double valor1 = double.Parse(txtCampo1.Text);
            double valor2 = double.Parse(txtCampo2.Text);
            double resultado = valor1 + valor2;
            txtResultado.Text = resultado.ToString();   
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            double valor1 = double.Parse(txtCampo1.Text);
            double valor2 = double.Parse(txtCampo2.Text);
            double resultado = valor1 - valor2;
            txtResultado.Text = resultado.ToString();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            double valor1 = double.Parse(txtCampo1.Text);
            double valor2 = double.Parse(txtCampo2.Text);
            double resultado = valor1 * valor2;
            txtResultado.Text = resultado.ToString();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            double valor1 = double.Parse(txtCampo1.Text);
            double valor2 = double.Parse(txtCampo2.Text);
            double resultado = valor1 / valor2;
            txtResultado.Text = resultado.ToString();
        }
    }
}
