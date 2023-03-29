using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.AreaFisicaFeature.Queries
{
    public class SelecionarAreasFisicaQuery : IRequest<IEnumerable<AreaFisicaModel>>
    {
    }

    public class SelecionarAreasFisicaHandler : IRequestHandler<SelecionarAreasFisicaQuery, IEnumerable<AreaFisicaModel>>
    {
        private readonly IRepository<AreaFisica> _repositoryAreaFisica;

        public SelecionarAreasFisicaHandler(IRepository<AreaFisica> repositoryAreaFisica)
        {
            _repositoryAreaFisica = repositoryAreaFisica;
        }

        public async Task<IEnumerable<AreaFisicaModel>> Handle(SelecionarAreasFisicaQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarAreasFisicaQuery>());

            IEnumerable<AreaFisica> areas = await _repositoryAreaFisica.GetAsync(cancellationToken);

            return areas.ToResponse();
        }
    }
}
