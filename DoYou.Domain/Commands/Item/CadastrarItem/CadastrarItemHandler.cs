using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Item.CadastrarItem
{
    public class CadastrarItemHandler : Notifiable, IRequestHandler<CadastrarItemRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryItem _repositoryItem;
        //private readonly IImagem _imagem;
        public CadastrarItemHandler(IMediator mediator, IRepositoryEmpresa repositoryEmpresa, IRepositoryItem repositoryItem, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryItem = repositoryItem;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(CadastrarItemRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Preencha as informações do Item");
                return new Response(this);
            }

            var empresa = _repositoryEmpresa.ObterPorId(request.FkEmpresa.Value);
            string urlFoto = "";

            if (empresa == null)
            {
                AddNotification("Empresa", "Empresa inválida");
                return new Response(this);
            }

            //if (request.Foto != null)
            //{
            //    urlFoto = "Imagens/" + _imagem.UploadImage(request.Foto).Result;
            //}


            Entities.Item item = new Entities.Item(request.Nome, request.Descricao, request.Valor, urlFoto, request.Tipo, empresa);
            if (IsInvalid())
            {
                return new Response(this);
            }
            AddNotifications(item);

            item = _repositoryItem.Adicionar(item);
            empresa.AdicionarItem(item);
            _repositoryEmpresa.Editar(empresa);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                this.AddNotification("Adicionar Item", "Erro ao persistir dados: " + ex.Message);
            }

            var result = new { Nome = item.Nome, Descricao = item.Descricao, Valor = item.Valor, UrlFoto = item.Foto, Empresa = item.Empresa.Fantasia };

            var response = new Response(this, result);
            return await Task.FromResult(response);
        }
    }
}
