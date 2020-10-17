using System;

namespace DoYou.Domain.Entities.Base
{
   public class Pessoa : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Celular { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
