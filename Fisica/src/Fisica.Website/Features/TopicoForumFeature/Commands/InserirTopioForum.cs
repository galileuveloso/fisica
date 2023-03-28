using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.TopicoForumFeature.Commands
{
    public class InserirTopicoForumCommand : IRequest<TopicoForumModel>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long ForumId { get; set; }

        public void Validar()
        {

        }
    }

    public class InserirTopicoForumHandler : IRequestHandler<InserirTopicoForumCommand, TopicoForumModel>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Forum> _repositoryForum;
        private readonly IRepository<TopicoForum> _repositoryTopicoForum;

        public InserirTopicoForumHandler(IRepository<Usuario> repositoryUsuario, IRepository<Forum> repositoryForum, IRepository<TopicoForum> repositoryTopicoForum)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryForum = repositoryForum;
            _repositoryTopicoForum = repositoryTopicoForum;
        }

        public async Task<TopicoForumModel> Handle(InserirTopicoForumCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirTopicoForumCommand>());

            request.Validar();

            if (!await _repositoryForum.ExistsAsync(x => x.Id == request.ForumId, cancellationToken))
                throw new ObjectNotFoundException("Fórum não encontrado.");

            TopicoForum topico = request.ToDomain();
            topico.Usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            await _repositoryTopicoForum.AddAsync(topico, cancellationToken);
            await _repositoryTopicoForum.SaveChangesAsync(cancellationToken);

            return topico.ToResponse();
        }
    }
}
