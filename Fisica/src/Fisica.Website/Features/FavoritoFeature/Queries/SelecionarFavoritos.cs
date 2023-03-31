using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Commands;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.FavoritoFeature.Queries
{
    public class SelecionarFavoritosQuery : IRequest<IEnumerable<FavoritoModel>>
    {
    }

    public class SelecionarFavoritosHandler : IRequestHandler<SelecionarFavoritosQuery, IEnumerable<FavoritoModel>>
    {
        private readonly IRepository<Favorito> _repositoryFavorito;

        public SelecionarFavoritosHandler(IRepository<Favorito> repositoryFavorito)
        {
            _repositoryFavorito = repositoryFavorito;
        }

        public async Task<IEnumerable<FavoritoModel>> Handle(SelecionarFavoritosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>());

            IEnumerable<Favorito> favoritos = await _repositoryFavorito.GetAsync(x => x.UsuarioId == ControllerExtensions.IdUsuario!.Value, cancellationToken, x => x.SessaoAula.Aula, x => x.Aula);

            return favoritos.ToResponse();
        }
    }
}
