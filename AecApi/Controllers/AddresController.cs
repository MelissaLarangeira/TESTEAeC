using AecApi.Models;
using AecApi.Service;
using Microsoft.AspNetCore.Mvc;
using AecApi.Services.Helper;
using System.Runtime.ConstrainedExecution;
using Microsoft.Identity.Client;

namespace AecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresController : ControllerBase
    {
     
        private readonly IAddresService _service;

        private readonly IViaCepService _viacepservice;  


        public AddresController(IAddresService service, IViaCepService viacep)
        {
            _service = service;

            _viacepservice = viacep;    
        }
             
        [HttpGet("{CEP}")]
        public async Task<ActionResult<IEnumerable<ViaCepModel>>> getAddres( string CEP)
        {
            try
            {
                // Busca o endereço usando o serviço
                var endereco = await _viacepservice.BuscarEnderecoPorCepAsync(CEP);

                // Retorna o endereço encontrado
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna uma mensagem de erro
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioPorID(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult>AdcionarUsuario([FromBody] Adress endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AdcionarUsuarioEndereco(endereco);

            return CreatedAtAction(nameof(GetUsuarioPorID), new { id = endereco.usuario.Id }, endereco);
        }


        

    }
}
