using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Features.AulaFeature.Commands;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.AulaFeature.Queries
{
    public class SelecionarAulasByAreaFisicaQuery : IRequest<IEnumerable<AulaModel>>
    {
        public long? AreaFisicaId { get; set; }

        public void Validar()
        {

        }
    }

    public class SelecionarAulasByAreaFisicaHandler : IRequestHandler<SelecionarAulasByAreaFisicaQuery, IEnumerable<AulaModel>>
    {
        private readonly IRepository<AreaFisica> _repositoryAreaFisica;
        private readonly IRepository<Aula> _repositoryAula;

        public SelecionarAulasByAreaFisicaHandler(IRepository<AreaFisica> repositoryAreaFisica, IRepository<Aula> repositoryAula)
        {
            _repositoryAreaFisica = repositoryAreaFisica;
            _repositoryAula = repositoryAula;
        }

        public async Task<IEnumerable<AulaModel>> Handle(SelecionarAulasByAreaFisicaQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirAulaCommand>());

            request.Validar();

            if (!await _repositoryAreaFisica.ExistsAsync(x => x.Id == request.AreaFisicaId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Área da Física não encontrada.");

            IEnumerable<Aula> aulas = await _repositoryAula.GetAsync(x => x.AreaFisicaId == request.AreaFisicaId!.Value, cancellationToken);

            return aulas.ToResponse();
        }
    }
}
