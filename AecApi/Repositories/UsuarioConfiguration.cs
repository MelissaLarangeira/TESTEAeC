using AecApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AecApi.Repositories
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            // Nome da tabela
            builder.ToTable("Usuarios");

            // Definindo a chave primária
            builder.HasKey(u => u.Id);

            // Definindo a coluna Id como Identity
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            // Definindo as propriedades com tamanhos específicos
            builder.Property(u => u.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Usuario)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Senha)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
