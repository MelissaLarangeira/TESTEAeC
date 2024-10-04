using AecApi.Models;
using AecApi.Service;
using Microsoft.AspNetCore.Mvc;
using AecApi.Services.Helper;
using System.Runtime.ConstrainedExecution;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.Data;
using AecApi.Services;

namespace AecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresController : ControllerBase
    {

        private readonly IAddresService _service;

        private readonly IViaCepService _viacepservice;

        private readonly IAuthService _Auth;

        public AddresController(IAddresService service, IViaCepService viacep, IAuthService auth)
        {
            _service = service;

            _viacepservice = viacep;

            _Auth = auth;
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
        {
            // Autentica o usuário com os campos corretos
            var user = _Auth.Authenticate(loginRequest.Usuario, loginRequest.Senha);

            if (user == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            return Ok(new { message = "Login bem-sucedido", user });
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