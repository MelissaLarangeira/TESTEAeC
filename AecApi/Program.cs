using Microsoft.Data.SqlClient;

namespace AecApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            // Configura��o dos servi�os
            builder.Services.AddControllers();

            // Adiciona a classe respons�vel por inicializar o banco de dados
            builder.Services.AddTransient<DatabaseInitializer>();

            var app = builder.Build();

            // Inicializa o banco de dados ao iniciar a aplica��o
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
                initializer.Initialize();
            }
            // Configura o roteamento e os endpoints
            app.MapControllers();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.Run();

        }
       
    }
}