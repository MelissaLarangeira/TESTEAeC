using System.Threading.Tasks;
using AecApi.Models;

namespace AecApi.Services.Helper
{
    public interface IViaCepService
    {
        Task<ViaCepModel> BuscarEnderecoPorCepAsync(string cep);
    }

}
