using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using DoYou.Domain.ObjectValues;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DoYou.Domain.Entities
{
    public class Empresa : EntityBase
    {
        protected Empresa()
        {

        }
        public Empresa(string razaoSocial, string fantasia, string cnpj, string email, string telefone, EnumCategoria categoria, Endereco endereco, Proprietario proprietario)
        {
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Cnpj = Regex.Replace(cnpj, "[^0-9]+", "");
            Email = email.ToLower();
            Telefone = telefone;
            Categoria = categoria;
            Endereco = endereco ?? new Endereco();
            Proprietario = proprietario;

            new AddNotifications<Empresa>(this)
              .IfNullOrInvalidLength(x => x.RazaoSocial, 3, 60, "Razão Social deve conter entre 3 à 60 caracteres")
              .IfNullOrInvalidLength(x => x.Fantasia, 3, 60, "Fantasia deve conter entre 3 à 60 caracteres")
              .IfNullOrInvalidLength(x => x.Cnpj, 10, 20, "Cnpj deve conter 14 caracteres")
              .IfNotEmail(x => x.Email, "O email não é válido")
              .IfNullOrInvalidLength(x => x.Telefone, 5, 15, "O telefone deve conter 10 caracteres");

            Ativo = true;
            DataCadastro = DateTime.Now;
        }

        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }
        public void AdicionarMesa(Mesa mesa)
        {
            Mesas.Add(mesa);
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
           Avaliacoes.Add(avaliacao);
        }

        public string RazaoSocial { get; private set; }
        public string Fantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string Logo { get; private set; }
        public string Telefone { get; private set; }
        public EnumCategoria Categoria { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public Proprietario Proprietario { get; private set; }
        public ICollection<Mesa> Mesas { get; private set; } = new Collection<Mesa> { };
        public ICollection<Item> Itens { get; private set; } = new Collection<Item> { };
        public ICollection<Avaliacao> Avaliacoes { get; private set; } = new Collection<Avaliacao> { };
        //public ICollection<Avaliacao> Avaliacoes { get; private set; } = new Collection<Avaliacao> { };
    }
}
