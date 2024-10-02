using Microsoft.Data.SqlClient;

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

            // Verifica se o script já foi executado
            var alreadyExecuted = await _context.SchemaMigrations
                .AnyAsync(m => m.ScriptName == scriptName);

            if (!alreadyExecuted)
            {
                // Lê o conteúdo do script
                var script = await File.ReadAllTextAsync(scriptPath);

                // Executa o script
                await _context.Database.ExecuteSqlRawAsync(script);

                // Registra a execução do script
                var migrationRecord = new SchemaMigration
                {
                    ScriptName = scriptName,
                    ExecutedAt = DateTime.UtcNow
                };

                _context.SchemaMigrations.Add(migrationRecord);
                await _context.SaveChangesAsync();
            }
        }
    }

    // Classe que representa a tabela SchemaMigrations
    public class SchemaMigration
    {
        public string ScriptName { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}