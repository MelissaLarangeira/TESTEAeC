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
        public async Task<ActionResult<IEnumerable<ViaCepModel>>> getAddres(string CEP)
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

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetUsuarioPorID(int id)
        {
           Usuarios? usuario = await _service.GetUsuarioPorID(id);

            if (usuario == null)
            {
                return NotFound();
            }


            return Ok(usuario);
        }

        [HttpPost("adicionar-Endereco")]
        public async Task<IActionResult> AdcionarEnderecoUsuario([FromBody] Adress endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AdcionarUsuarioEndereco(endereco);

            return CreatedAtAction(nameof(GetUsuarioPorID), new { id = endereco.UsuarioID }, endereco);
        }

        [HttpPost("adicionar-Usuario")]
        public async Task<IActionResult> AdcionarUsuario([FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AdcionarUsuario(usuarios);

            return CreatedAtAction(nameof(GetUsuarioPorID), new { id = usuarios.Id }, usuarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaEndereco(int id, [FromBody] Adress endereco)
        {

            var Update = await _service.AtualizaUsuarioEndereco(id, endereco);

            if (!Update)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirUsuario( int id)
        {
            var delete = await _service.ExcluiUsuario(id);

            if (!delete)
            {
                return NotFound("Usuario não existe ou ja foi excluido");
            }

            return Ok("Excluido com sucesso");
        }

    }
}