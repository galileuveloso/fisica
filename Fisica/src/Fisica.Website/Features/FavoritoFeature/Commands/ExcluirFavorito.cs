using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Commands;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.FavoritoFeature.Commands
{
    public class ExcluirFavoritoCommand : IRequest
    {
        public long? FavoritoId { get; set; }

        public void Validar()
        {

        }
    }

    public class ExcluirFavoritoHandler : IRequestHandler<ExcluirFavoritoCommand>
    {
        private readonly IRepository<Favorito> _repositoryFavorito;

        public ExcluirFavoritoHandler(IRepository<Favorito> repositoryFavorito)
        {
            _repositoryFavorito = repositoryFavorito;
        }

        public async Task<Unit> Handle(ExcluirFavoritoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>());

            request.Validar();

            Favorito favorito = await _repositoryFavorito.GetSingleAsync(x => x.Id == request.FavoritoId!.Value, cancellationToken);

            if (favorito is null)
                throw new ObjectNotFoundException("Favorito não encontrado.");

            if (favorito.UsuarioId != ControllerExtensions.IdUsuario!.Value)
                throw new InvalidOperationException("Usuário não pode remover este favorito.");

            await _repositoryFavorito.RemoveAsync(favorito);
            await _repositoryFavorito.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
