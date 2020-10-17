using DoYou.Domain.Entities.Base;
using DoYou.Domain.Extensions;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DoYou.Domain.Entities
{
    public class Usuario : Pessoa
    {
        public Usuario(string nome, string email, string senha, string celular, DateTime dataAniversario)
        {
            Nome = nome;
            Email = email.ToLower();
            Senha = senha;
            Celular = Regex.Replace(celular, "[^0-9]+", "");
            DataAniversario = dataAniversario;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, 50, "O Nome deve conter entre 3 à 50 caracteres")
                .IfNotEmail(x => x.Email, "O Email informado não é válido")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve conter entre 6 à 32 caracteres")
                .IfNullOrInvalidLength(x => x.Celular, 11, 11, "Informe o número de celular");

            //if (!string.IsNullOrEmpty(this.Senha))
            //{
            //    Console.WriteLine(this.Senha);
            //    this.Senha = Senha.ConvertToMD5();
            //}

            DataCadastro = DateTime.Now;
            Ativo = false;
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            Avaliacoes.Add(avaliacao);
        }

        public void AdicionarComanda(Comanda comanda)
        {
            Comandas.Add(comanda);
        }

        public string Foto { get; private set; }
        public DateTime DataAniversario { get; private set; }
        public ICollection<Avaliacao> Avaliacoes { get; private set; } = new Collection<Avaliacao> { };
        public ICollection<Comanda> Comandas { get; private set; } = new Collection<Comanda> { };
    }
}
