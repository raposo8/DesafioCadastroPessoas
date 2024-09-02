using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCadastroPessoas
{
    
        public interface IPessoaRepository
        {
            void AdicionarPessoa(Pessoa pessoa);
            Pessoa BuscarPessoaPorId(int id);
            void AtualizarPessoa(Pessoa pessoa);
            void RemoverPessoa(int id);
            void Conectar(); // Adicione se houver um método para conectar
            void Desconectar(); // Adicione se houver um método para desconectar
        }
    
}
