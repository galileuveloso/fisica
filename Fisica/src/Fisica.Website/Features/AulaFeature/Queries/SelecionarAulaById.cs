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

        public void Validar()
        {

        }
    }

    public class SelecionarAulaByIdHandler : IRequestHandler<SelecionarAulaByIdQuery, AulaModel>
    {
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<SessaoAula> _repositorySessaoAula;
        private readonly IRepository<AreaFisica> _repositoryAreaFisica;

        public SelecionarAulaByIdHandler(IRepository<Aula> repositoryAula, IRepository<SessaoAula> repositorySessaoAula, IRepository<AreaFisica> repositoryAreaFisica)
        {
            _repositoryAula = repositoryAula;
            _repositorySessaoAula = repositorySessaoAula;
            _repositoryAreaFisica = repositoryAreaFisica;
        }

        public async Task<AulaModel> Handle(SelecionarAulaByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarAulaByIdQuery>());

            request.Validar();

            Aula aula = await _repositoryAula.GetSingleAsync(x => x.Id == request.AulaId, cancellationToken, x => x.Sessoes, x => x.AreaFisica, x => x.Professor);

            if (aula is null)
                throw new ObjectNotFoundException("Aula não encontrada.");

            //TO-DO: Trazer os arquivos caso tenha na sessão

            return aula.ToResponseWithSessoes();
        }
    }
}
