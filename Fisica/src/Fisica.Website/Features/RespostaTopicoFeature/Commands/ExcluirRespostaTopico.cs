using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.RespostaTopicoFeature.Commands
{
    public class ExcluirRespostaTopicoCommand : IRequest
    {
        public long? RespostaTopicoId { get; set; }

        public void Validar()
        {

        }
    }

    public class ExcluirRespostaTopicoHandler : IRequestHandler<ExcluirRespostaTopicoCommand>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<RespostaTopico> _repositoryRespostaTopico;

        public ExcluirRespostaTopicoHandler(IRepository<Usuario> repositoryUsuario, IRepository<RespostaTopico> repositoryRespostaTopico)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryRespostaTopico = repositoryRespostaTopico;
        }

        public async Task<Unit> Handle(ExcluirRespostaTopicoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirRespostaTopicoCommand>());

            RespostaTopico? resposta = await _repositoryRespostaTopico.GetSingleAsync(x => x.Id == request.RespostaTopicoId!.Value, cancellationToken);

            if (resposta is null)
                throw new ObjectNotFoundException("Resposta não encontrada.");

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            if (resposta.UsuarioId != usuario.Id && usuario.TipoUsuarioEnum != TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não pode excluir esta resposta");

            await _repositoryRespostaTopico.RemoveAsync(resposta);
            await _repositoryRespostaTopico.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
