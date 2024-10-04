using AecApi.Dao;
using AecApi.Models;
using AecApi.Repositories;
using AecApi.Service;
using AecApi.Services.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AecApi.Services
{
    public class AddresService : IAddresService
    {
        private readonly MyDbContext _context;

        public AddresService(MyDbContext context)
        {
            _context = context;
        }

        public async Task AdcionarUsuario([FromBody] Usuarios usuarios)
        {
            // Adiciona o endereço ao contexto
            _context.Add(usuarios);

            // Se houver um usuário vinculado ao endereço, ele também será adicionado
            if (usuarios != null)
            {
                _context.Usuarios.Add(usuarios);
            }

            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }

   
        // Método para adicionar endereço e, opcionalmente, o usuário
        public async Task AdcionarUsuarioEndereco(Adress endereco)
        {
            // Adiciona o endereço ao contexto
            _context.Add(endereco);

            if (endereco != null)
            {
                _context.Enderecos.Add(endereco);
            }

            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }

        // Método para atualizar o endereço de um usuário
        public async Task<bool> AtualizaUsuarioEndereco(int id, Adress endereco)
        {
            var enderecoExistente = await _context.Enderecos.FindAsync(id);

            if (enderecoExistente == null)
            {
                return false; // Endereço não encontrado
            }

            // Atualiza os dados do endereço
            enderecoExistente.Cep = endereco.Cep;
            enderecoExistente.Logradouro = endereco.Logradouro;
            enderecoExistente.Complemento = endereco.Complemento;
            enderecoExistente.Bairro = endereco.Bairro;
            enderecoExistente.Cidade = endereco.Cidade;
            enderecoExistente.UF = endereco.UF;
            enderecoExistente.Numero = endereco.Numero;

            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();

            return true;
        }

        // Método para excluir um usuário
        public async Task<bool> ExcluiUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return false; // Usuário não encontrado
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        // Método para obter um usuário pelo ID
        public async Task<Usuarios?> GetUsuarioPorID(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}




