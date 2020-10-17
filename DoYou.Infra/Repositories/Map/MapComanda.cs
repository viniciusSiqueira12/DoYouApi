using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapComanda : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Abertura).IsRequired();
            builder.Property(x => x.Fechada);
            builder.Property(x => x.Total);
            builder.Property(x => x.SubTotal); 
            builder.Property(x => x.Fechada).IsRequired();

            builder.HasMany(x => x.ItensComanda).WithOne().HasForeignKey("FkComanda");
            builder.HasOne(x => x.Usuario).WithMany(m => m.Comandas).HasForeignKey("FkUsuario");
            builder.HasOne(x => x.Mesa).WithMany(m => m.Comandas).HasForeignKey("FkMesa");
        }
    }
}
