using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AecApi.Dao;

namespace AecApi
{
    public class Program
    {
        #region antigo main
        //public static void Main(string[] args)
        //{

        //    var builder = WebApplication.CreateBuilder(args);

        //    builder.Services.AddSwaggerGen();

        //    // Configuração dos serviços
        //    builder.Services.AddControllers();

        //    // Adiciona a classe responsável por inicializar o banco de dados
        //    builder.Services.AddTransient<DatabaseInitializer>();

        //    var app = builder.Build();

        //    // Inicializa o banco de dados ao iniciar a aplicação
        //    using (var scope = app.Services.CreateScope())
        //    {
        //        var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
        //        initializer.Initialize();
        //    }
        //    // Configura o roteamento e os endpoints
        //    app.MapControllers();

        //    app.UseSwagger();

        //    app.UseSwaggerUI();

        //    app.Run();

        //}
        #endregion
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registro do DbContext
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configuração dos serviços
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Adiciona a classe responsável por inicializar o banco de dados
            builder.Services.AddTransient<DatabaseInitializer>();

            var app = builder.Build();

            // Inicializa o banco de dados ao iniciar a aplicação
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
                try
                {
                    await initializer.InitializeAsync(); // Chamada assíncrona
                }
                catch (Exception ex)
                {
                    // Log de erro
                    Console.WriteLine($"Erro ao inicializar o banco de dados: {ex.Message}");
                }
            }

            // Configura o roteamento e os endpoints
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Configura Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            await app.RunAsync();
        }



    }
}