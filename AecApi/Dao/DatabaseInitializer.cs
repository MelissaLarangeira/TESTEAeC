using Microsoft.Data.SqlClient;

public class DatabaseInitializer
{
    private readonly IConfiguration _configuration;

    public DatabaseInitializer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Initialize()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var script = File.ReadAllText("Data/create_tables.sql");
            using (var command = new SqlCommand(script, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
