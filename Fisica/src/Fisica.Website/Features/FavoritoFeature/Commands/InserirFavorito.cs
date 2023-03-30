using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Commands;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.FavoritoFeature.Commands
{
    public class InserirFavoritoCommand : IRequest
    {
        public long? AulaId { get; set; }
        public long? SessaoAulaId { get; set; }

        public void Validar()
        {

        }
    }

    public class InserirFavoritoHnadler : IRequestHandler<InserirFavoritoCommand>
    {
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<SessaoAula> _repositorySessaoAula;
        private readonly IRepository<Favorito> _repositoryFavorito;

        public InserirFavoritoHnadler(IRepository<Aula> repositoryAula, IRepository<SessaoAula> repositorySessaoAula, IRepository<Favorito> repositoryFavorito)
        {
            _repositoryAula = repositoryAula;
            _repositorySessaoAula = repositorySessaoAula;
            _repositoryFavorito = repositoryFavorito;
        }

        public async Task<Unit> Handle(InserirFavoritoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>());

            request.Validar();

            Aula? aula = null;
            SessaoAula? sessao = null;
            Favorito favorito = new() { UsuarioId = ControllerExtensions.IdUsuario!.Value };

            if (request.AulaId.HasValue)
            {
                aula = await _repositoryAula.GetSingleAsync(x => x.Id == request.AulaId!.Value, cancellationToken);

                if (aula is null)
                    throw new ObjectNotFoundException("Aula não encontrada.");

                favorito.Aula = aula;
            }
            else
            {
                sessao = await _repositorySessaoAula.GetSingleAsync(x => x.Id == request.SessaoAulaId!.Value, cancellationToken);

                if (aula is null)
                    throw new ObjectNotFoundException("Sessao não encontrada.");

                favorito.SessaoAula = sessao;
            }

            await _repositoryFavorito.AddAsync(favorito, cancellationToken);
            await _repositoryFavorito.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
