using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapAvaliacao : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable("Avaliacao");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Estrelas).HasMaxLength(1).IsRequired();
            builder.Property(x => x.Comentario).HasMaxLength(200);
            builder.HasOne(x => x.Empresa).WithMany(m => m.Avaliacoes ).HasForeignKey("FkEmpresa");
            builder.HasOne(x => x.Usuario).WithMany(m => m.Avaliacoes).HasForeignKey("FkUsuario");
        }
    }
}
