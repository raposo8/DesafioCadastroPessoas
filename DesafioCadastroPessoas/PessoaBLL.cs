using DesafioCadastroPessoas;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DesafioCadastroPessoas
{
    internal class PessoaBLL
    {
        static string formatacao;
        static Regex regex;



        public static void ValidarDados(Pessoa pessoa)
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
                Erro.setErro("Numero é de preenchimento obrigatório.");
                return;
            }

                // Adicione aqui outras validações, se necessário.

                Erro.setErro(false); // Nenhum erro, tudo está válido
        }
        public static void AdicionarPessoa(Pessoa pessoa)
        {
            ValidarDados(pessoa);

            if (!Erro.getErro())
            {
                PessoaDAL.AdicionarPessoa(pessoa);
            }
        }

        public static void AtualizarPessoa(Pessoa pessoa)
        {
            ValidarDados(pessoa);
            ValidaId(pessoa.Id.ToString());

            if (!Erro.getErro())
            {
                PessoaDAL.AtualizarPessoa(pessoa);
            }
        }

        public static void RemoverPessoa(string id)
        {
            ValidaId(id);

            if (!Erro.getErro())
            {
                PessoaDAL.RemoverPessoa(int.Parse(id));
            }
           
        }

        public static void ValidaId(string id)
        {
            Erro.setErro(false);
            if (string.IsNullOrEmpty(id))
            {
                Erro.setErro("Por favor forneça um Id");
                return;
            }

        }

        public static Pessoa BuscarPessoaPorId(string id)
        {
            ValidaId(id);
            if (!Erro.getErro())
            {

                return PessoaDAL.BuscarPessoaPorId(int.Parse(id));
            }
            return null;
            
        }

      

    }
}
