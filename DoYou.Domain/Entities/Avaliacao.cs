using DoYou.Domain.Entities.Base;
using System;

namespace DoYou.Domain.Entities
{
    public class Avaliacao : EntityBase
    {
        protected Avaliacao()
        {

        }
        public Avaliacao(int estrelas, string comentario, Empresa empresa, Usuario usuario)
        {
            Estrelas = estrelas;
            Comentario = comentario;
            Empresa = empresa;
            Usuario = usuario;

            DataCriacao = DateTime.Now;
        }

        public int Estrelas { get; private set; }
        public string Comentario { get; private set; } 
        public Empresa Empresa { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataCriacao { get; set; }
    }
}
