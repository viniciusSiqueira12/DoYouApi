using DoYou.Domain.Entities;
using DoYou.Infra.Repositories.Map;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace DoYou.Infra.Repositories.Base
{
    public partial class DoYouContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        //public DbSet<Funcionario> Funcionario { get; set; }
        //public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ItemComanda> ItemComanda { get; set; } 
        public DbSet<Avaliacao> Avaliacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-DKKE61I;Database=DoYou;User=DoYou;Password=D3skt0p@Vv;");
                optionsBuilder.UseSqlServer("Server=DESKTOP-DKKE61I;Database=APIDoYou;User=Vinicius;Password=D3skt0p@Vv;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            modelBuilder.Ignore<Notification>();
            //modelBuilder.Ignore<Endereco>();
            //modelBuilder.Ignore<Nome>();
            //modelBuilder.Ignore<Email>();

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapUsuario());
            //modelBuilder.ApplyConfiguration(new MapCartao());
            modelBuilder.ApplyConfiguration(new MapEmpresa());
            modelBuilder.ApplyConfiguration(new MapProprietario());
            modelBuilder.ApplyConfiguration(new MapMesa());
            modelBuilder.ApplyConfiguration(new MapItem()); 
            modelBuilder.ApplyConfiguration(new MapAvaliacao());
            modelBuilder.ApplyConfiguration(new MapComanda());
            modelBuilder.ApplyConfiguration(new MapItemComanda());
            //modelBuilder.ApplyConfiguration(new MapFuncionario());


            base.OnModelCreating(modelBuilder);
        }
    }
}
