using AecApi.Models;

namespace AecApi.Service
{
    public interface IAddresService
    {
        public Task<IEnumerable<ViaCepModel>> BuscarLista();
      //  public Task<Adress?> BuscapCEP(int id);
      //  public Task AdicionarEnd([FromBody] Endereco Adress);
      ////  public Task<bool> AtualizarEndereco(int id, usuario candidato); - precisa da model referente ao banco
      //  public Task<bool> ExcluirCandidato(int id);      
    }
}
