using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapProprietario : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietario");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Celular).HasMaxLength(11).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.EmpresaUltimoAcesso);
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.Empresas).WithOne().HasForeignKey("FkProprietario");
        }
    }
}
