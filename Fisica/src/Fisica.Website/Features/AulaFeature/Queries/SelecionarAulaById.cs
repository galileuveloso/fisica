using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.AulaFeature.Queries
{
    public class SelecionarAulaByIdQuery : IRequest<AulaModel>
    {
        public long? AulaId { get; set; }
        public string Maquina { get; set; }
        public void Validar()
        {

        }
    }

    public class SelecionarAulaByIdHandler : IRequestHandler<SelecionarAulaByIdQuery, AulaModel>
    {
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<VisualizacaoAula> _repositoryVisualizacao;

        public SelecionarAulaByIdHandler(IRepository<Aula> repositoryAula, IRepository<VisualizacaoAula> repositoryVisualizacao)
        {
            _repositoryAula = repositoryAula;
            _repositoryVisualizacao = repositoryVisualizacao;
        }

        public async Task<AulaModel> Handle(SelecionarAulaByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarAulaByIdQuery>());

            request.Validar();

            Aula aula = await _repositoryAula.GetSingleAsync(x => x.Id == request.AulaId, cancellationToken, x => x.Sessoes!, x => x.Comentarios!, x => x.AreaFisica, x => x.Professor);

            if (aula is null)
                throw new ObjectNotFoundException("Aula não encontrada.");

            //TO-DO: Trazer os arquivos caso tenha na sessão

            if (!await _repositoryVisualizacao.ExistsAsync(x => x.AulaId == aula.Id && (x.UsuarioId == ControllerExtensions.IdUsuario!.Value || x.Maquina == request.Maquina), cancellationToken))
                await RegistrarVisualizacao(aula.Id, ControllerExtensions.IdUsuario!.Value, request.Maquina, cancellationToken);

            return aula.ToResponseWithSessoesAndComentarios();
        }

        private async Task RegistrarVisualizacao(long aulaId, long? usuarioId, string maquina, CancellationToken cancellationToken)
        {
            VisualizacaoAula visualizacao = new()
            {
                AulaId = aulaId,
                UsuarioId = usuarioId,
                Maquina = maquina
            };

            await _repositoryVisualizacao.AddAsync(visualizacao, cancellationToken);
            await _repositoryVisualizacao.SaveChangesAsync(cancellationToken);
        }
    }
}
