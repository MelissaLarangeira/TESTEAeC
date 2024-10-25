using AecApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AecApi.Service
{
    public interface IAddresService
    {
        public Task<Usuarios?> GetUsuarioPorID(int id);

        public Task<Usuarios> ObterUsuarioPorEmail(string email);
        public Task AdcionarUsuarioEndereco([FromBody] Adress endereco);

        public Task AdcionarUsuario([FromBody] Usuarios usuarios);

        public Task<bool> AtualizaUsuarioEndereco(int id, Adress endereco);

        public Task<bool> ExcluiUsuario(int id);

    }
}
