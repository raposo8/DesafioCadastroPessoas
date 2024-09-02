using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCadastroPessoas
{
    internal class Erro
    {
        private static bool erro;
        private static string mensagemErro;

        public static string getMensagem() { return mensagemErro; }
        public static bool getErro() { return erro; }
        public static void setErro(bool _erro) { erro = _erro; }
        public static void setErro(string _mensagem) { erro = true; mensagemErro = _mensagem; }
    }
}
