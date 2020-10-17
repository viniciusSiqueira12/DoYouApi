using DoYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoYou.Infra.Repositories.Map
{
    public class MapEmpresa : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RazaoSocial).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Fantasia).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cnpj).HasMaxLength(18).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(14).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Logo);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.Categoria).IsRequired();

            builder.OwnsOne(x => x.Endereco).Property(e => e.CEP).HasMaxLength(10).HasColumnName("EndCep");
            builder.OwnsOne(x => x.Endereco).Property(e => e.UF).HasMaxLength(10).HasColumnName("EndUf");
            builder.OwnsOne(x => x.Endereco).Property(e => e.Municipio).HasMaxLength(100).HasColumnName("EndMunicipio");
            builder.OwnsOne(x => x.Endereco).Property(e => e.Bairro).HasMaxLength(100).HasColumnName("EndBairro");
            builder.OwnsOne(x => x.Endereco).Property(e => e.Logradouro).HasMaxLength(100).HasColumnName("EndLogradouro");
            builder.OwnsOne(x => x.Endereco).Property(e => e.Numero).HasMaxLength(10).HasColumnName("EndNumero");
            builder.OwnsOne(x => x.Endereco).Property(e => e.Complemento).HasMaxLength(200).HasColumnName("EndComplemento");

            builder.HasOne(x => x.Proprietario).WithMany(m => m.Empresas).HasForeignKey("FkProprietario");
            builder.HasMany(x => x.Mesas).WithOne().HasForeignKey("FkEmpresa");
            //builder.HasMany(x => x.Funcionarios).WithOne().HasForeignKey("FkEmpresa");
            builder.HasMany(x => x.Itens).WithOne().HasForeignKey("FkEmpresa");
            builder.HasMany(x => x.Avaliacoes).WithOne().HasForeignKey("FkEmpresa");
        }
    }
}
