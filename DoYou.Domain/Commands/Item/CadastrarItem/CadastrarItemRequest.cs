using DoYou.Domain.Enums;
using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Item.CadastrarItem
{
    public class CadastrarItemRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        //public IFormFile Foto { get; set; }
        public EnumTipoItem Tipo { get; set; }
        public Guid? FkEmpresa { get; set; }
    }
}
