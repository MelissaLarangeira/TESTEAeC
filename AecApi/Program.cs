using Microsoft.Data.SqlClient;

namespace AecApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            // Configuração dos serviços
            builder.Services.AddControllers();

            // Adiciona a classe responsável por inicializar o banco de dados
            builder.Services.AddTransient<DatabaseInitializer>();

            var app = builder.Build();

            // Inicializa o banco de dados ao iniciar a aplicação
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