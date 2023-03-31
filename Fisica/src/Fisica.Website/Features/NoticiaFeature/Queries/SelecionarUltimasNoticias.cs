using Fisica.Dados.Repositories;
using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.NoticiaFeature.Queries
{
    public class SelecionarUltimasNoticiasQuery : IRequest<IEnumerable<NoticiaModel>>
    {
    }

    public class SelecionarUltimasNoticiasHandler : IRequestHandler<SelecionarUltimasNoticiasQuery, IEnumerable<NoticiaModel>>
    {
        private readonly IRepository<Noticia> _repositoryNoticia;

        public SelecionarUltimasNoticiasHandler(IRepository<Noticia> repositoryNoticia)
        {
            _repositoryNoticia = repositoryNoticia;
        }

        public async Task<IEnumerable<NoticiaModel>> Handle(SelecionarUltimasNoticiasQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarNoticiasQuery>());

            return await _repositoryNoticia.ObterUltimasNoticias();
        }
    }
}
