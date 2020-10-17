using DoYou.Domain.Interfaces.Repositories;
using DoYou.Domain.Interfaces.Transactions;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoYou.Domain.Commands.Avaliacao.AvaliarRestaurante
{
    public class AvaliarRestauranteHandler : Notifiable, IRequestHandler<AvaliarRestauranteRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryEmpresa _repositoryEmpresa;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryAvaliacao _repositoryAvaliacao;

        public AvaliarRestauranteHandler(IMediator mediator, IRepositoryEmpresa repositoryEmpresa, IRepositoryUsuario repositoryUsuario, IRepositoryAvaliacao repositoryAvaliacao, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repositoryEmpresa = repositoryEmpresa;
            _repositoryUsuario = repositoryUsuario;
            _repositoryAvaliacao = repositoryAvaliacao;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(AvaliarRestauranteRequest request, CancellationToken cancellationToken)
         {
            if(request == null)
            {
                AddNotification("Resquest", "Preencha as informações da avaliação");
                return new Response(this);
            }

            var usuario = _repositoryUsuario.ObterPorId(request.FkUsuario.Value);
            var empresa = _repositoryEmpresa.ObterPorId(request.FkEmpresa.Value);

            Entities.Avaliacao avaliacao = new Entities.Avaliacao(request.Estrelas, request.Comentario, empresa, usuario);
            if (IsInvalid())
            {
                return new Response(this);
            }

            avaliacao = _repositoryAvaliacao.Adicionar(avaliacao);

            empresa.AdicionarAvaliacao(avaliacao);
            _repositoryEmpresa.Editar(empresa);

            usuario.AdicionarAvaliacao(avaliacao);
            _repositoryUsuario.Editar(usuario);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                this.AddNotification("Avaliar Empresa", "Erro ao persistir dados: " + ex.Message);
            }

            var result = new
            {
                Id = avaliacao.Id,
                Estrelas = avaliacao.Estrelas,
                Comentario = avaliacao.Comentario,
                Usuario = new { Id = avaliacao.Usuario.Id, Nome = avaliacao.Usuario.Nome, Foto = avaliacao.Usuario.Foto }
            };

            var response = new Response(this, result);
            return await Task.FromResult(response);
        }
    }
}
