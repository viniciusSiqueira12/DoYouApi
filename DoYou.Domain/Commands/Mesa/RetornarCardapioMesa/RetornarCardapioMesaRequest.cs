
using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Mesa.RetornarCardapioMesa
{

    public class RetornarCardapioMesaRequest : DataTableBase<Entities.Item>, IRequest<Response>
    {
        public RetornarCardapioMesaRequest() : base(new string[] { "Nome", "Descricao", }, "Nome")
        {
        }
        public Guid? FkMesa { get; set; }
        public EnumTipoItem Tipo { get; set; }
    }
}
