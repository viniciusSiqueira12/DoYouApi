using MediatR;
using prmToolkit.NotificationPattern;
using System;

namespace DoYou.Domain.Commands.Avaliacao.AvaliarRestaurante
{
    public class AvaliarRestauranteRequest : IRequest<Response>
    {
        public int Estrelas { get; set; }
        public string Comentario { get; set; }
        public Guid? FkUsuario { get; set; }
        public Guid? FkEmpresa { get; set; }
    }
}
