using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AecApi.Models;

namespace AecApi.Services.Helper
{
    public class ViaCepService : IViaCepService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ViaCepModel> BuscarEnderecoPorCepAsync(string cep)
        {
            cep = cep.Replace("-", "").Trim();
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            var endereco = await client.GetFromJsonAsync<ViaCepModel>(url);

            if (endereco == null || endereco.CEP == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            return endereco;
        }
    }
}
