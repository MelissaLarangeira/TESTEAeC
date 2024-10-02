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

        //    // Configura��o dos servi�os
        //    builder.Services.AddControllers();

        //    // Adiciona a classe respons�vel por inicializar o banco de dados
        //    builder.Services.AddTransient<DatabaseInitializer>();

        //    var app = builder.Build();

        //    // Inicializa o banco de dados ao iniciar a aplica��o
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

            // Configura��o dos servi�os
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Adiciona a classe respons�vel por inicializar o banco de dados
            builder.Services.AddTransient<DatabaseInitializer>();

            var app = builder.Build();

            // Inicializa o banco de dados ao iniciar a aplica��o
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
                try
                {
                    await initializer.InitializeAsync(); // Chamada ass�ncrona
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