using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.ComentarioAulaFeature.Commands
{
    public class ExcluirComentarioAulaCommand : IRequest
    {
        public long? ComentarioAulaId { get; set; }

        public void Validar() { }
    }

    public class ExcluirComentarioAulaHandler : IRequestHandler<ExcluirComentarioAulaCommand>
    {
        private readonly IRepository<ComentarioAula> _repositoryComentarioAula;
        public async Task<Unit> Handle(ExcluirComentarioAulaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirComentarioAulaCommand>());

            request.Validar();

            ComentarioAula comentario = await _repositoryComentarioAula.GetSingleAsync(x => x.Id == request.ComentarioAulaId!.Value, cancellationToken);

            if (comentario is null)
                throw new ObjectNotFoundException("Comentário não encontrado.");

            if (comentario.UsuarioId != ControllerExtensions.IdUsuario!.Value)
                throw new InvalidOperationException("Você não pode excluir este comentario.");

            await _repositoryComentarioAula.RemoveAsync(comentario);
            await _repositoryComentarioAula.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
