using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    class MapItem : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Valor).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Foto);
           
            builder.HasOne(x => x.Empresa).WithMany(m => m.Itens).HasForeignKey("FkEmpresa");
            builder.HasMany(x => x.ItensComanda).WithOne().HasForeignKey("FkItem");
        }
    }
}
