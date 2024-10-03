using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;
using AecApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AecApi.Repositories
{
    public class ConfigurationEndereco : EntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            // Nome da tabela
            builder.ToTable("Enderecos");

            // Definindo a chave primária
            builder.HasKey(e => e.Id);

            // Definindo a coluna Id como Identity
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // Definindo as propriedades com tamanhos específicos
            builder.Property(e => e.Cep)
                   .HasMaxLength(8)
                   .IsRequired();

            builder.Property(e => e.Logradouro)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Complemento)
                   .HasMaxLength(100)
                   .IsRequired(false); // Campo opcional

            builder.Property(e => e.Bairro)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Cidade)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.UF)
                   .HasMaxLength(2)
                   .IsRequired();

            builder.Property(e => e.Numero)
                   .HasMaxLength(10)
                   .IsRequired();

            // Relacionamento com a tabela Usuarios
            builder.HasOne<Usuarios>()
                   .WithMany()
                   .HasForeignKey(e => e.UsuarioID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
