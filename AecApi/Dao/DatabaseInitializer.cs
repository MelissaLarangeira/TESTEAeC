using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace AecApi.Dao
{
    public class DatabaseInitializer
    {
        private readonly MyDbContext _context; // Contexto do Entity Framework
        private readonly IConfiguration _configuration;

        public DatabaseInitializer(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task InitializeAsync()
        {
            // Verifica se o banco de dados já está criado
            await _context.Database.EnsureCreatedAsync();

            var scriptName = "Create_Table.sql"; // Nome do script
            var scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "Dao", scriptName);

       
        }
    }

}