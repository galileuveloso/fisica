using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.RespostaTopicoFeature.Commands;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.ReplicaFeature.Commands
{
    public class ExcluirReplicaCommand : IRequest
    {
        public long? ReplicaId { get; set; }
    }

    public class ExcluirReplicaHandler : IRequestHandler<ExcluirReplicaCommand>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Replica> _repositoryReplica;

        public ExcluirReplicaHandler(IRepository<Usuario> repositoryUsuario, IRepository<Replica> repositoryReplica)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryReplica = repositoryReplica;
        }

        public async Task<Unit> Handle(ExcluirReplicaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirRespostaTopicoCommand>());

            Replica? replica = await _repositoryReplica.GetSingleAsync(x => x.Id == request.ReplicaId!.Value, cancellationToken);

            if (replica is null)
                throw new ObjectNotFoundException("Replica não encontrada.");

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            if (replica.UsuarioId != usuario.Id && usuario.TipoUsuarioEnum != TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não pode excluir esta replica.");

            await _repositoryReplica.RemoveAsync(replica);
            await _repositoryReplica.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
