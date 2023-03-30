using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.ComentarioAulaFeature.Commands
{
    public class InserirComentarioAulaCommand : IRequest<ComentarioAulaModel>
    {
        public string? Descricao { get; set; }
        public long? AulaId { get; set; }

        public void Validar()
        {

        }
    }

    public class InserirComentarioAulaHandler : IRequestHandler<InserirComentarioAulaCommand, ComentarioAulaModel>
    {
        private readonly IRepository<ComentarioAula> _repositoryComentario;
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public InserirComentarioAulaHandler(IRepository<ComentarioAula> repositoryComentario, IRepository<Aula> repositoryAula, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryComentario = repositoryComentario;
            _repositoryAula = repositoryAula;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<ComentarioAulaModel> Handle(InserirComentarioAulaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirComentarioAulaCommand>());

            request.Validar();

            if (await _repositoryAula.ExistsAsync(x => x.Id == request.AulaId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Aula não encontrada");

            ComentarioAula comentario = request.ToDomain();
            comentario.Usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            await _repositoryComentario.AddAsync(comentario, cancellationToken);
            await _repositoryComentario.SaveChangesAsync(cancellationToken);

            return comentario.ToResponse();
        }
    }
}
