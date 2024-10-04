using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AecApi.Dao;
using AecApi.Service;
using AecApi.Services;
using AecApi.Services.Helper;
using System;
using static System.Net.Mime.MediaTypeNames;


namespace AecApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registro do DbContext
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAddresService, AddresService>();
            builder.Services.AddScoped<IViaCepService, ViaCepService>();
            builder.Services.AddScoped<IAuthService, AuthSerive>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("teste",
                    builder => builder
                        .WithOrigins("http://localhost:3000") // Permite requisi��es desse endere�o
                        .AllowAnyMethod() // Permite todos os m�todos (GET, POST, etc.)
                        .AllowAnyHeader()); // Permite todos os cabe�alhos
            });

            // Configura��o dos servi�os
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Adiciona a classe respons�vel por inicializar o banco de dados
            builder.Services.AddTransient<DatabaseInitializer>();
            //builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db_jpv")));


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

            app.UseCors("teste");

            await app.RunAsync();
        }

    }
}