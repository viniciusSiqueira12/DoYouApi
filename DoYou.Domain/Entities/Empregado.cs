using DoYou.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Entities
{
    public class Empregado : Pessoa
    {
        protected Empregado()
        {

        }
        public Empregado(string nome, string email, string senha, string celular,  string foto)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Celular = celular;
            Foto = foto;

            new AddNotifications<Empregado>(this)
              .IfNullOrInvalidLength(x => x.Nome, 3, 50, "Deve conter entre 3 à 50 carateres")
              .IfNotEmail(x => x.Email, "Informe um email válido")
              .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve conter entre 6 à 32 caracteres")
              .IfNullOrInvalidLength(x => x.Celular, 11, 11, "Informe um celular válido");

            DataCadastro = DateTime.Now;
            Ativo = false;

  
        }
         
        public string Foto { get; set; }
    }
}
