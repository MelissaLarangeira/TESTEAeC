using Microsoft.EntityFrameworkCore;

namespace AecApi.Dao
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // Defina suas entidades (tabelas) aqui
        public DbSet<SchemaMigration> SchemaMigrations { get; set; }

        // Adicione outros DbSets conforme necessário para suas outras entidades
    }
}