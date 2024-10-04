using AecApi.Models;

namespace AecApi.Services
{
    public interface IAuthService
    {
        public Usuarios Authenticate(string usuario, string senha);


    }
}
