using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using MediatR;
using prmToolkit.NotificationPattern;

namespace DoYou.Domain.Commands.Empresa.RetornarEmpresas
{
    public class RetornarEmpresasRequest : DataTableBase<Entities.Empresa>, IRequest<Response>
    {
        public RetornarEmpresasRequest() : base(new string[] { "Fantasia", "RazaoSocial", "Cnpj", "Fantasia" }, "Fantasia")
        {
        }

        public EnumCategoria Categoria { get; set; }
    }
}
