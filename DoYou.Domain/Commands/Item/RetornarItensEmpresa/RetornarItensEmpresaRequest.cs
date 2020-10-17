using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Item.RetornarItensEmpresa
{
    public class RetornarItensEmpresaRequest : DataTableBase<Entities.Item>, IRequest<Response>
    {
        public RetornarItensEmpresaRequest() : base(new string[] { "Nome", "Descricao", }, "Nome")
        {
        }
        public Guid? FkEmpresa { get; set; }
        public EnumTipoItem Tipo { get; set; }
    }
}
