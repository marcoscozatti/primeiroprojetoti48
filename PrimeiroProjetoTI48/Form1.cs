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

        decimal valor1, valor2, resultado;
        string operacao="Adicao";


        private void Form1_Load(object sender, EventArgs e)
        {
            valor1 = 0;
            valor2 = 0;
            resultado = 0;

        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            operacao = "Adicao";
                       
            if (operacao == "Adicao")
            {
                txtResultado.Text = valor1.ToString() + " + ";
            }

            txtDisplay.Clear();

        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            operacao = "Subtracao";

            if (operacao == "Subtracao")
            {
                txtResultado.Text = valor1.ToString();
            }

            txtDisplay.Clear();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operacao = "Multiplicacao";

            if (operacao == "Multiplicacao")
            {
                txtResultado.Text = valor1.ToString() ;
            }

            txtDisplay.Clear();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            operacao = "Divisao";

            if (operacao == "Divisao")
            {
                txtResultado.Text = valor1.ToString();
            }

            txtDisplay.Clear();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn1.Text;
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn9.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btn0.Text;
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += btnVirgula.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            operacao = "";
            txtDisplay.Clear();
            txtResultado.Clear();

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacao == "Adicao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor2 + valor1;
                txtResultado.Text = valor1.ToString() + " + " + valor2.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Subtracao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor2 - valor1;
                txtResultado.Text = valor2.ToString() + " - " + valor1.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Multiplicacao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor2 * valor1;
                txtResultado.Text = valor1.ToString() + " * " + valor2.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Divisao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor2 / valor1;
                txtResultado.Text = valor1.ToString() + " / " + valor2.ToString();
                txtDisplay.Text = resultado.ToString();

            }
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            // 1. Faz o cast do remetente (sender) para o tipo Button.
            Button botao = (Button)sender;

            // 2. Anexa o texto (o número) do botão ao texto atual do display.
            txtDisplay.Text += botao.Text;
            valor1 = decimal.Parse(txtDisplay.Text);
        }

    }
}
