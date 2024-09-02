using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DesafioCadastroPessoas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void textBox4_Leave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                Endereco endereco = await API.buscarInfoMoradia(textBox4.Text);

                if (Erro.getErro())
                {
                    MessageBox.Show(Erro.getMensagem());
                }
                else
                {

                    textBairro.Text = endereco.Bairro;
                    textCidade.Text = endereco.Localidade;
                    textRua.Text = endereco.Logradouro;
                    textEstado.Text = endereco.Uf;
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = textBox2.Text;
            pessoa.Telefone = maskedTextBox1.Text;
            pessoa.Email = textBox3.Text;
            pessoa.Cep = textBox4.Text;
            pessoa.Estado = textEstado.Text;
            pessoa.Cidade = textCidade.Text;
            pessoa.Bairro = textBairro.Text;
            pessoa.Rua = textRua.Text;
            pessoa.Numero = textNumero.Text;
            pessoa.Complemento = textComplemento.Text;
            PessoaBLL.ValidarDados(pessoa);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }

            PessoaBLL.AdicionarPessoa(pessoa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PessoaDAL.conecta();

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            PessoaDAL.desconecta();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = PessoaBLL.BuscarPessoaPorId(textBox1.Text);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }
            textBox2.Text = pessoa.Nome;
            maskedTextBox1.Text = pessoa.Telefone;
            textBox3.Text = pessoa.Email;
            textBox4.Text = pessoa.Cep;
            textEstado.Text = pessoa.Estado;
            textCidade.Text = pessoa.Cidade;
            textBairro.Text = pessoa.Bairro;
            textRua.Text = pessoa.Rua;
            textNumero.Text = pessoa.Numero;
            textComplemento.Text = pessoa.Complemento;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = int.Parse(textBox1.Text);
            pessoa.Nome = textBox2.Text;
            pessoa.Telefone = maskedTextBox1.Text;
            pessoa.Email = textBox3.Text;
            pessoa.Cep = textBox4.Text;
            pessoa.Estado = textEstado.Text;
            pessoa.Cidade = textCidade.Text;
            pessoa.Bairro = textBairro.Text;
            pessoa.Rua = textRua.Text;
            pessoa.Numero = textNumero.Text;
            pessoa.Complemento = textComplemento.Text;
            PessoaBLL.ValidarDados(pessoa);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }
            PessoaBLL.AtualizarPessoa(pessoa);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PessoaBLL.RemoverPessoa(textBox1.Text);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }
            MessageBox.Show("Usuário Eliminado");
        }
    }
}
