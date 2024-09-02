using System;
using System.Windows.Forms;

namespace DesafioCadastroPessoas
{
    public partial class Form1 : Form
    {
        private readonly PessoaBLL _pessoaBLL;

        public Form1(IPessoaRepository pessoaRepository)
        {
            InitializeComponent();
            _pessoaBLL = new PessoaBLL(pessoaRepository);
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
            Pessoa pessoa = new Pessoa
            {
                Nome = textBox2.Text,
                Telefone = maskedTextBox1.Text,
                Email = textBox3.Text,
                Cep = textBox4.Text,
                Estado = textEstado.Text,
                Cidade = textCidade.Text,
                Bairro = textBairro.Text,
                Rua = textRua.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text
            };

            _pessoaBLL.ValidarDados(pessoa);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }

            _pessoaBLL.AdicionarPessoa(pessoa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _pessoaBLL.Conectar();

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            _pessoaBLL.Desconectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = _pessoaBLL.BuscarPessoaPorId(textBox1.Text);

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
            Pessoa pessoa = new Pessoa
            {
                Id = int.Parse(textBox1.Text),
                Nome = textBox2.Text,
                Telefone = maskedTextBox1.Text,
                Email = textBox3.Text,
                Cep = textBox4.Text,
                Estado = textEstado.Text,
                Cidade = textCidade.Text,
                Bairro = textBairro.Text,
                Rua = textRua.Text,
                Numero = textNumero.Text,
                Complemento = textComplemento.Text
            };

            _pessoaBLL.ValidarDados(pessoa);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }

            _pessoaBLL.AtualizarPessoa(pessoa);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _pessoaBLL.RemoverPessoa(textBox1.Text);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMensagem());
                return;
            }

            MessageBox.Show("Usuário Eliminado");
        }
    }
}
