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

        public Task AdcionarUsuarioEndereco([FromBody] Adress endereco)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> GetUsuarioPorID(int id)
        {
            return await _service.GetUsuarioPorID(id);
        }
    }
}
