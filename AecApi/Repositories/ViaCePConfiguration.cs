namespace AecApi.Repositories
{
    using AecApi.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ViaCepModelConfiguration : IEntityTypeConfiguration<ViaCepModel>
    {
        public void Configure(EntityTypeBuilder<ViaCepModel> builder)
        {
            // Nome da tabela (opcional, se não quiser deixar o padrão de nome da classe)
            builder.ToTable("ViaCep");

            // Configuração das propriedades com seus respectivos tamanhos e obrigatoriedade
            builder.Property(v => v.CEP)
                   .HasMaxLength(8)
                   .IsRequired();

            builder.Property(v => v.lougradouro)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(v => v.complemento)
                   .HasMaxLength(100)
                   .IsRequired(false); // Campo opcional

            builder.Property(v => v.unidade)
                   .HasMaxLength(50)
                   .IsRequired(false); // Campo opcional

            builder.Property(v => v.bairro)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(v => v.localidade)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(v => v.uf)
                   .HasMaxLength(2)
                   .IsRequired();

            builder.Property(v => v.estado)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(v => v.região)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(v => v.ibge)
                   .HasMaxLength(10)
                   .IsRequired(false); // Campo opcional

            builder.Property(v => v.gia)
                   .HasMaxLength(10)
                   .IsRequired(false); // Campo opcional

            builder.Property(v => v.ddd)
                   .HasMaxLength(3)
                   .IsRequired(false); // Campo opcional

            builder.Property(v => v.siafi)
                   .HasMaxLength(10)
                   .IsRequired(false); // Campo opcional
        }
    }

}
