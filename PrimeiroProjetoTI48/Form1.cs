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
        decimal convertePorcentagem;


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
                 txtResultado.Text = valor1.ToString();
   
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
                txtResultado.Text = txtDisplay.Text;
                valor1 = decimal.Parse(txtResultado.Text);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            txtDisplay.Clear();
            txtDisplay.Focus();

        }

        private void btnNegativo_Click(object sender, EventArgs e)
        {
            decimal converteNegativo = Decimal.Parse(txtDisplay.Text);
            valor1 = (converteNegativo * (-1));
            txtDisplay.Text = valor1.ToString(); 
        }

        private void btnPorcento_Click(object sender, EventArgs e)
        {
            operacao = "Porcentagem";
            convertePorcentagem = Decimal.Parse(txtDisplay.Text) / 100;
            
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacao == "Adicao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor1 + valor2;
                txtResultado.Text = valor2.ToString() + " + " + valor1.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Subtracao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor1 - valor2;
                txtResultado.Text = valor2.ToString() + " - " + valor1.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Multiplicacao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor1 * valor2;
                txtResultado.Text = valor1.ToString() + " * " + valor2.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Porcentagem")
            {
                resultado = convertePorcentagem * valor1;
                txtResultado.Text = valor1.ToString()  + " * " +  convertePorcentagem.ToString();
                txtDisplay.Text = resultado.ToString();

            }
            if (operacao == "Divisao")
            {
                valor2 = decimal.Parse(txtResultado.Text);
                resultado = valor2 / valor1;
                txtResultado.Text = valor2.ToString() + " / " + valor1.ToString();
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
