using AecApi.Dao;
using AecApi.Models;

namespace AecApi.Services
{
    public class AuthSerive : IAuthService
    {
        private readonly MyDbContext _context;

        public AuthSerive(MyDbContext context)
        {
            _context = context;
        }

        public Usuarios Authenticate(string usuario, string senha)
        {
           return _context.Usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }
    }
}
