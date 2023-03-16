using Fisica.Classes;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.UsuarioFeature.Commands
{
    public class DeletarUsuarioCommand : IRequest
    {
        public long? AdminId { get; set; }
        public long? UsuarioId { get; set; }

        public void Validate()
        {
            if (UsuarioId is null) throw new ArgumentNullException(MessageHelper.NullFor<DeletarUsuarioCommand>(x => x.UsuarioId));
        }
    }

    public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;

        public DeletarUsuarioHandler(IRepository<Usuario> repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<DeletarUsuarioCommand>());

            request.Validate();

            request.AdminId = 1;

            Usuario? admin = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.AdminId!.Value, cancellationToken);

            if (admin!.TipoUsuario != (int)TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não possui permissão para excluir usuários.");

            Usuario? usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.UsuarioId!.Value, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuario não encontrada.");

            await _repositoryUsuario.RemoveAsync(usuario);
            await _repositoryUsuario.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
