using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.TopicoForumFeature.Commands
{
    public class ExcluirTopicoForumCommand : IRequest
    {
        public long? TopicoForumId { get; set; }

        public void Validar()
        {

        }
    }

    public class ExcluirTopicoForumHandler : IRequestHandler<ExcluirTopicoForumCommand>
    {
        private readonly IRepository<TopicoForum> _repositoryTopicoForum;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public ExcluirTopicoForumHandler(IRepository<TopicoForum> repositoryTopicoForum, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryTopicoForum = repositoryTopicoForum;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Unit> Handle(ExcluirTopicoForumCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirTopicoForumCommand>());

            request.Validar();

            TopicoForum? topico = await _repositoryTopicoForum.GetSingleAsync(x => x.Id == request.TopicoForumId!.Value, cancellationToken);

            if (topico is null)
                throw new ObjectNotFoundException("Tópico nao encontrado.");

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            if (usuario.Id != topico.UsuarioId && usuario.TipoUsuarioEnum != TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Você não tem permissão para excluir este tópico.");

            await _repositoryTopicoForum.RemoveAsync(topico);
            await _repositoryTopicoForum.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
