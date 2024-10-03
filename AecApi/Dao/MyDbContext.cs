using AecApi.Models;
using AecApi.Repositories;
using Microsoft.EntityFrameworkCore;


namespace AecApi.Dao
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }             

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Adress> Enderecos { get; set; }    
    }
}