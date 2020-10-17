using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapItemComanda : IEntityTypeConfiguration<ItemComanda>
    {
        public void Configure(EntityTypeBuilder<ItemComanda> builder)
        {
            builder.ToTable("ItemComanda");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Observacao).HasMaxLength(200);
            builder.Property(x => x.ValorItem).IsRequired();
            builder.Property(x => x.Total).IsRequired();
            builder.Property(x => x.DataPedido).IsRequired();

            builder.HasOne(x => x.Comanda).WithMany(m => m.ItensComanda).HasForeignKey("FkComanda");
            builder.HasOne(x => x.Item).WithMany(m => m.ItensComanda).HasForeignKey("FkItem"); 
        }
    }
}
