using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DoYou.Domain.Entities
{
    public class Item : EntityBase
    {
        protected Item()
        {

        }
        public Item(string nome, string descricao, double valor, string foto, EnumTipoItem tipo, Empresa empresa)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
            Tipo = tipo;
            Empresa = empresa;

            new AddNotifications<Item>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, 60, "O Nome do prato deve conter 3 à 60 caracteres")
                .IfNullOrInvalidLength(x => x.Descricao, 3, 200, "A descrição deve conter 3 à 200 caracteres");

            Ativo = true;
            DataCadastro = DateTime.Now;
        }

        public void AdicionarItensComanda(ItemComanda itemComanda)
        {
            ItensComanda.Add(itemComanda);
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public string Foto { get; private set; }
        public bool Ativo { get; private set; }
        public EnumTipoItem Tipo { get; private set; }
        public DateTime DataCadastro { get; set; }
        public Empresa Empresa { get; private set; }
        public ICollection<ItemComanda> ItensComanda { get; private set; } = new Collection<ItemComanda> { };
    }
}
