using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.AulaFeature.Queries;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.SegueFeature.Commands
{
    public class DeixarDeSeguirCommand : IRequest
    {
        public long? ProfessorId { get; set; }

        public void Validar()
        {

        }
    }

    public class DeixarDeSeguirHandler : IRequestHandler<DeixarDeSeguirCommand>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Segue> _repositorySegue;

        public DeixarDeSeguirHandler(IRepository<Usuario> repositoryUsuario, IRepository<Segue> repositorySegue)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositorySegue = repositorySegue;
        }

        public async Task<Unit> Handle(DeixarDeSeguirCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarAulaByIdQuery>());

            request.Validar();

            Usuario professor = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.ProfessorId!.Value, cancellationToken);

            if (professor is null)
                throw new ObjectNotFoundException("Professor não encontrado.");

            Segue segue = await _repositorySegue.GetSingleAsync(x => x.UsuarioId == ControllerExtensions.IdUsuario!.Value && x.ProfessorId == professor.Id, cancellationToken);

            if (segue is not null)
            {
                await _repositorySegue.RemoveAsync(segue);
                await _repositorySegue.SaveChangesAsync(cancellationToken);
            }

            return await Unit.Task;
        }
    }
}
