using DoYou.Domain.Entities.Base;
using System;
using System.Linq;

namespace DoYou.Domain.Commands.Avaliacao.RetornarAvaliacoesEmpresa
{
    public class RetornarAvaliacoesEmpresaResponse : DataTableResponseBase<AvaliacaoHelper>
    {
        public RetornarAvaliacoesEmpresaResponse(DataTableResponseBase<Entities.Avaliacao> dataTable) :
        base(dataTable.PageSize, dataTable.PageView, dataTable.PageNumber, dataTable.Data.Select(e => new AvaliacaoHelper(e)).ToList())
        { }
    }

    public class AvaliacaoHelper : EntityBase
    {
        public AvaliacaoHelper(Entities.Avaliacao avaliacao)
        {
            Id = avaliacao.Id;
            Estrelas  = avaliacao.Estrelas;
            Comentario = avaliacao.Comentario;
            DataCriacao = avaliacao.DataCriacao;
            Usuario = new UsuarioHelper(avaliacao.Usuario);
        }
        public int Estrelas { get; set; }
        public string Comentario { get; set; }
        public UsuarioHelper Usuario { get; set; }
        public int MesasDisponiveis { get; set; }
        public DateTime DataCriacao { get; set; }

    }

   public class UsuarioHelper : EntityBase
   {
        public UsuarioHelper(Entities.Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Foto = usuario.Foto;
        }

        public string Nome { get; set; }
        public string Foto { get; set; }
    }
}
