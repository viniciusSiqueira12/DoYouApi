using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Pedido.RealizarPedido
{
    public class RealizarPedidoHandler : Notifiable, IRequestHandler<RealizarPedidoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryComanda _repositoryComanda;
        private readonly IRepositoryItemComanda _repositoryItemComanda;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryMesa _repositoryMesa;
        private readonly IRepositoryItem _repositoryItem; 
        public RealizarPedidoHandler(IMediator mediator, IRepositoryItemComanda repositoryItemComanda, IRepositoryComanda repositoryComanda, IRepositoryUsuario repositoryUsuario, IRepositoryMesa repositoryMesa, IRepositoryItem repositoryItem, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
            _repositoryItemComanda = repositoryItemComanda;
            _unitOfWork = unitOfWork;
            _repositoryMesa = repositoryMesa;
            _repositoryItem = repositoryItem;
            _repositoryComanda = repositoryComanda;
        }

        public async Task<Response> Handle(RealizarPedidoRequest request, CancellationToken cancellationToken)
        {
            var usuario = _repositoryUsuario.ObterPorId(request.FkUsuario.Value);
            var mesa = _repositoryMesa.ObterPorId(request.FkMesa.Value);
            var Existecomanda = _repositoryComanda.ObterPor(x => x.Usuario.Id == usuario.Id && x.Status == Enums.EnumStatusComanda.EmAberto);

            Entities.Comanda comanda;
            //var existeComandaAberta = usuario.Comandas.Where(x => x.Status == Enums.EnumStatusComanda.EmAberto).FirstOrDefault();
            if (Existecomanda == null)
            {
                comanda = new Entities.Comanda(usuario, mesa);
                if (IsInvalid())
                {
                    return new Response(this);
                }

                comanda = _repositoryComanda.Adicionar(comanda);
            }
            comanda = Existecomanda; 

            double total = 0;
            for (var i = 0; i < request.ItemPedido.Length; i++)
            { 
                var item = _repositoryItem.ObterPorId(request.ItemPedido[i].FkItem.Value);
                Entities.ItemComanda itemComanda = new Entities.ItemComanda(Enums.EnumStatusPedido.Feito, request.ItemPedido[i].Quantidade, item.Valor, item.Valor * request.ItemPedido[i].Quantidade, request.ItemPedido[i].Observacao, item, comanda);
                total = total += itemComanda.Total;
                itemComanda = _repositoryItemComanda.Adicionar(itemComanda);
                comanda.AdicionarItensComanda(itemComanda);
                item.AdicionarItensComanda(itemComanda); 
            }

            mesa.Ocupada = true;
            comanda.Total = total;
            _repositoryComanda.Editar(comanda);
            mesa = _repositoryMesa.Editar(mesa);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                this.AddNotification("Adicionar ItemPedido", "Erro ao persistir dados: " + ex.Message);
            }

            Response resp = new Response(this, comanda);
            return await Task.FromResult(resp);
        }


    }
}
