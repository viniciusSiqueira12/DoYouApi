using DoYou.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DoYou.Domain.Entities
{
    public class Proprietario : Pessoa
    {
        protected Proprietario()
        {

        }
        public Proprietario(string nome, string email, string senha, string celular)
        {
            Nome = nome;
            Email = email.ToLower();
            Senha = senha;
            Celular = celular;

            new AddNotifications<Proprietario>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, 60, "Nome deve conter entre 3 à 60 caracteres")
                .IfNotEmail(x => x.Email, "Informe um email válido!")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve conter entre 6 à 32 caracteres");

            //if (!string.IsNullOrEmpty(this.Senha))
            //{
            //    this.Senha = Senha.ConvertToMD5();
            //}
            DataCadastro = DateTime.Now;
            Ativo = false;

        }

        public void AdicionarEmpresa(Empresa novaEmpresa)
        {
            Empresas.Add(novaEmpresa);
        }
        public string EmpresaUltimoAcesso { get; set; }

        public ICollection<Empresa> Empresas { get; set; } = new Collection<Empresa> { };
    }
}
