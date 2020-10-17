using DoYou.Domain.Entities.Base;
using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Avaliacao.RetornarAvaliacoesEmpresa
{

    public class RetornarAvaliacoesEmpresaRequest : DataTableBase<Entities.Avaliacao>, IRequest<Response>
    {
        public RetornarAvaliacoesEmpresaRequest() : base(new string[] { ""}, "")
        {
        }
        public Guid? FkEmpresa { get; set; }
    }
}
