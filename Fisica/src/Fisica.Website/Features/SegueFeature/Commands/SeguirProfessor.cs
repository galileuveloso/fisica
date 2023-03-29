using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.AulaFeature.Queries;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.SegueFeature.Commands
{
    public class SeguirProfessorCommand : IRequest
    {
        public long? ProfessorId { get; set; }

        public void Validar()
        {

        }
    }

    public class SeguirProfessorHandler : IRequestHandler<SeguirProfessorCommand>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Segue> _repositorySegue;

        public SeguirProfessorHandler(IRepository<Usuario> repositoryUsuario, IRepository<Segue> repositorySegue)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositorySegue = repositorySegue;
        }

        public async Task<Unit> Handle(SeguirProfessorCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarAulaByIdQuery>());

            request.Validar();

            Usuario professor = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.ProfessorId!.Value, cancellationToken);

            if (professor is null)
                throw new ObjectNotFoundException("Professor não encontrado.");

            if (professor.TipoUsuarioEnum != TipoUsuario.Professor && professor.TipoUsuarioEnum != TipoUsuario.ProfessorAdministrador)
                throw new InvalidOperationException("Usuário não pode ser seguido pois não é um professor.");

            if (!await _repositorySegue.ExistsAsync(x => x.UsuarioId == ControllerExtensions.IdUsuario!.Value && x.ProfessorId == request.ProfessorId, cancellationToken))
            {
                Segue segue = request.ToDomain(ControllerExtensions.IdUsuario!.Value);

                await _repositorySegue.AddAsync(segue, cancellationToken);
                await _repositorySegue.SaveChangesAsync(cancellationToken);
            }

            return await Unit.Task;
        }
    }
}
