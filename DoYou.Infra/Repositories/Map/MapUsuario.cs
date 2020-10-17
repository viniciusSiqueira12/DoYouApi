using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Foto);
            builder.Property(x => x.Celular).HasMaxLength(11).IsRequired();
            builder.Property(x => x.DataAniversario).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();

            builder.HasMany(x => x.Avaliacoes).WithOne().HasForeignKey("FkUsuario");
            builder.HasMany(x => x.Comandas).WithOne().HasForeignKey("FkUsuario");
        }
    }
}
