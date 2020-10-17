using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    class MapMesa : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("Mesa");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Ocupada).IsRequired();
            //builder.HasMany(x => x.Pedidos).WithOne().HasForeignKey("FkMesa");
            builder.HasOne(x => x.Empresa).WithMany(m => m.Mesas).HasForeignKey("FkEmpresa");
            builder.HasMany(x => x.Comandas).WithOne().HasForeignKey("FkMesa");
        }
    }
}
