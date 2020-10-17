using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Empresa.RetornaEmpresaUsuario
{
    public class RetornaEmpresaUsuarioRequest : IRequest<Response>
    {
        public Guid? FkEmpresa { get; set; }
    }
}
