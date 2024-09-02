using System;
using System.Text.RegularExpressions;

namespace DesafioCadastroPessoas
{
    internal class PessoaBLL
    {
        private readonly IPessoaRepository _pessoaRepository;
        private string formatacao;
        private Regex regex;

        public PessoaBLL(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void Conectar()
        {
            try
            {
                _pessoaRepository.Conectar();
            }
            catch (Exception ex)
            {
                Erro.setErro($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }

       public void Desconectar()
        {
            try
            {
                _pessoaRepository.Desconectar();
            }
            catch (Exception ex)
            {
                Erro.setErro($"Erro ao desconectar do banco de dados: {ex.Message}");
            }
        }

        public void ValidarDados(Pessoa pessoa)
        {
            Erro.setErro(false);

            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                Erro.setErro("Nome é de preenchimento obrigatório.");
                return;
            }

            if (string.IsNullOrEmpty(pessoa.Telefone))
            {
                Erro.setErro("Telefone é de preenchimento obrigatório.");
                return;
            }
            else
            {
                formatacao = @"^\(\d{2}\)\s\d{1}\s?\d{4}-\d{4}$";
                regex = new Regex(formatacao);
                if (!regex.IsMatch(pessoa.Telefone))
                {
                    Erro.setErro("Telefone está com formatação incorreta.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(pessoa.Email))
            {
                Erro.setErro("E-mail é de preenchimento obrigatório.");
                return;
            }
            else
            {
                formatacao = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // Regex para validação de e-mail
                regex = new Regex(formatacao);
                if (!regex.IsMatch(pessoa.Email))
                {
                    Erro.setErro("E-mail está com formatação incorreta.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(pessoa.Cep))
            {
                Erro.setErro("CEP é de preenchimento obrigatório.");
                return;
            }
            else
            {
                formatacao = @"^\d{8}$"; // CEP no formato XXXXXXXX
                regex = new Regex(formatacao);
                if (!regex.IsMatch(pessoa.Cep))
                {
                    Erro.setErro("CEP está com formatação incorreta.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(pessoa.Numero))
            {
                Erro.setErro("Número é de preenchimento obrigatório.");
                return;
            }

            Erro.setErro(false); // Nenhum erro, tudo está válido
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            ValidarDados(pessoa);

            if (!Erro.getErro())
            {
                _pessoaRepository.AdicionarPessoa(pessoa);
            }
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            ValidarDados(pessoa);
            ValidaId(pessoa.Id.ToString());

            if (!Erro.getErro())
            {
                _pessoaRepository.AtualizarPessoa(pessoa);
            }
        }

        public void RemoverPessoa(string id)
        {
            ValidaId(id);

            if (!Erro.getErro())
            {
                _pessoaRepository.RemoverPessoa(int.Parse(id));
            }
        }

        public Pessoa BuscarPessoaPorId(string id)
        {
            ValidaId(id);
            if (!Erro.getErro())
            {
                return _pessoaRepository.BuscarPessoaPorId(int.Parse(id));
            }
            return null;
        }

        private void ValidaId(string id)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(id))
            {
                Erro.setErro("Por favor forneça um Id.");
            }
        }
    }
}
