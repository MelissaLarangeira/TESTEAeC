using AecApi.Models;

namespace AecApi.Repositories
{
    public class ViaCepRepository : IViaCepRepository
    {
        private readonly IViaCepRepository _repository;

        public ViaCepRepository(IViaCepRepository repository)
        {
            _repository = repository;
        }

        async Task<ViaCepModel?> IViaCepRepository.BuscarEnderecoPorCepAsync(string CEP)
        {
            return await _repository.BuscarEnderecoPorCepAsync(CEP);
        }
    }
}
