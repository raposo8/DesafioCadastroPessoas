using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DesafioCadastroPessoas;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace DesafioCadastroPessoas
{
    internal class API
    {
        private static readonly HttpClient client = new HttpClient();

        public async static Task<Endereco> buscarInfoMoradia(string CEP)
        {
            Erro.setErro(false);
            string request = $"https://viacep.com.br/ws/{CEP}/json/";

            try
            {
                Debug.WriteLine("Iniciando requisição...");
                string response = await client.GetStringAsync(request);
                Debug.WriteLine("Requisição concluída.");
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(response);
                return endereco;
            }
            catch (HttpRequestException ex)
            {
                Erro.setErro($"CEP inválido");
                return null;
            }
            catch (JsonException ex)
            {
                Erro.setErro($"Erro ao desserializar JSON: {ex.Message}");
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Erro.setErro($"Erro de operação inválida: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Erro.setErro($"Erro inesperado: {ex.Message}");
                return null;
            }
        }
    }
}