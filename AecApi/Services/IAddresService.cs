using AecApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AecApi.Service
{
    public interface IAddresService
    {
        public Task<Usuario?> GetUsuarioPorID(int id);

        public Task AdcionarUsuarioEndereco([FromBody] Adress endereco);

        public Task<bool> AtualizaUsuarioEndereco(int id, Adress endereco);

        public Task<bool> ExcluiUsuario(int id);

    }
}
