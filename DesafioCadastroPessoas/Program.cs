using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioCadastroPessoas
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Crie uma instância da implementação concreta de IPessoaRepository
            IPessoaRepository pessoaRepository = new PessoaDAL();

            // Crie uma instância do Form1 passando o IPessoaRepository
            Application.Run(new Form1(pessoaRepository));
        }
    }
}
