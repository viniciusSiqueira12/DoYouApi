using DoYou.Domain.Enums;
using DoYou.Domain.ObjectValues;
using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Empresa.CadastrarEmpresa
{


    public class CadastrarEmpresaRequest : IRequest<Response>
    {
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnumCategoria Categoria { get; set; }
        public Endereco Endereco { get; set; }
        public Guid? FkProprietario { get; set; }
    }
}
