using DoYou.Domain.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Comanda.RetornarComanda
{
    public class RetornarComandaHandler : Notifiable, IRequestHandler<RetornarComandaRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryMesa _repositoryMesa;
        private readonly IRepositoryComanda _repositoryComanda;
        private readonly IRepositoryItemComanda _repositoryItemComanda;
        private readonly IRepositoryItem _repositoryItem;

        public RetornarComandaHandler(IMediator mediator, IRepositoryComanda repositoryComanda, IRepositoryEmpresa repositoryEmpresa, IRepositoryMesa repositoryMesa, IRepositoryItemComanda repositoryItemComanda,
            IRepositoryItem repositoryItem)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryMesa = repositoryMesa;
            _repositoryComanda = repositoryComanda;
            _repositoryItemComanda = repositoryItemComanda;
            _repositoryItem = repositoryItem;
        }

        public async Task<Response> Handle(RetornarComandaRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                AddNotification("Resquest", "Request inválido!");
                return new Response(this);
            }

            var comanda = _repositoryComanda.RetornarComanda(request.FkComanda.Value);
            //var mesa = _repositoryMesa.ObterPor(x => x.Comandas.Contains(comanda));
            //var empresa = _repositoryEmpresa.ObterPor(x => x.Mesas.Contains(mesa));

            //var itensComanda = _repositoryItemComanda.ListarPor(x => x.Comanda.Id == comanda.Id).ToList().;
            ////var itens = _repositoryItem.ObterPor(x => x.ItensComanda.Contains(itensComanda));




            //var result = new
            //{
            //    Status = comanda.Status,
            //    DataAbertura = comanda.Abertura,
            //    Total = comanda.Total,
            //    Empresa = new
            //    {
            //        Id = comanda.Mesa.Empresa.Id,
            //        Fantasia = comanda.Mesa.Empresa.Fantasia,
            //        Logo = comanda.Mesa.Empresa.Logo,
            //    },
            //    Mesa = new
            //    {
            //        Id = comanda.Mesa.Id,
            //        Numero = comanda.Mesa.Numero
            //    },
            //    ItensPedidos = new
            //    {
            //         foreach
            //    }
            //};

            RetornarComandaResponse result = new RetornarComandaResponse(comanda);

            var response = new Response(this, result);
            return await Task.FromResult(response); 
        }
    }
}
