using ConsultarCep.Service.Model;
using Newtonsoft.Json;
using System.Net;

namespace ConsultarCep.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient cliente = new WebClient();
            string Conteudo = cliente.DownloadString(NovoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (endereco.Cep == null)
                return null;

            return endereco;
        }
    }
}
