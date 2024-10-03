using AecApi.Models;

namespace AecApi.Repositories
{
    public interface IViaCepRepository
    {
        public Task<ViaCepModel?> BuscarEnderecoPorCepAsync (string CEP);
    }
}
