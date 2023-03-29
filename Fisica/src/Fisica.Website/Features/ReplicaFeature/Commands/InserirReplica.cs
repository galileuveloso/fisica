using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.ReplicaFeature.Commands
{
    public class InserirReplicaCommand : IRequest<ReplicaModel>
    {
        public long? RespostaTopicoId { get; set; }
        public string? Descricao { get; set; }

    }

    public class InserirReplicaHandler : IRequestHandler<InserirReplicaCommand, ReplicaModel>
    {
        private readonly IRepository<RespostaTopico> _repositoryRespostaTopico;
        private readonly IRepository<Replica> _repositoryReplica;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public InserirReplicaHandler(IRepository<RespostaTopico> repositoryRespostaTopico, IRepository<Replica> repositoryReplica, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryRespostaTopico = repositoryRespostaTopico;
            _repositoryReplica = repositoryReplica;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<ReplicaModel> Handle(InserirReplicaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirReplicaCommand>());

            if (!await _repositoryRespostaTopico.ExistsAsync(x => x.Id == request.RespostaTopicoId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Resposta não encontrada");

            Replica replica = request.ToDomain();

            replica.Usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            await _repositoryReplica.AddAsync(replica, cancellationToken);
            await _repositoryReplica.SaveChangesAsync(cancellationToken);

            return replica.ToResponse();
        }
    }
}
