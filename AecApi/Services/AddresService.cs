using AecApi.Models;
using AecApi.Service;
using AecApi.Services.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AecApi.Services
{
    public class AddresService : IAddresService
    {
        private readonly IAddresService _service;
        public AddresService(IAddresService service )
        {
            _service = service;

        }

        public async Task AdcionarUsuarioEndereco([FromBody] Adress endereco)
        {
          await  _service.AdcionarUsuarioEndereco(endereco);
        }

        public Task<bool> AtualizaUsuarioEndereco(int id, Adress endereco)
        {
            return _service.AtualizaUsuarioEndereco(id, endereco);
        }

        public async Task<bool> ExcluiUsuario(int id)
        {
            return await _service.ExcluiUsuario(id);
        }

        public async Task<Usuario?> GetUsuarioPorID(int id)
        {
            return await _service.GetUsuarioPorID(id);
        }
    }
}
