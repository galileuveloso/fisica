using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.TopicoForumFeature.Queries
{
    public class SelecionarTopicosForumByForumQuery : IRequest<IEnumerable<TopicoForumModel>>
    {
        public long? ForumId { get; set; }

        public void Validar()
        {

        }
    }

    public class SelecionarTopicosForumByForumHandler : IRequestHandler<SelecionarTopicosForumByForumQuery, IEnumerable<TopicoForumModel>>
    {
        private readonly IRepository<TopicoForum> _repositoryTopicoForum;
        private readonly IRepository<Forum> _repositoryForum;

        public SelecionarTopicosForumByForumHandler(IRepository<TopicoForum> repositoryTopicoForum, IRepository<Forum> repositoryForum)
        {
            _repositoryTopicoForum = repositoryTopicoForum;
            _repositoryForum = repositoryForum;
        }

        public async Task<IEnumerable<TopicoForumModel>> Handle(SelecionarTopicosForumByForumQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarTopicosForumByForumQuery>());

            if (!await _repositoryForum.ExistsAsync(x => x.Id == request.ForumId, cancellationToken))
                throw new ObjectNotFoundException("Fórum não encontrado.");

            IEnumerable<TopicoForum> topicos = await _repositoryTopicoForum.GetAsync(x => x.Id == request.ForumId!.Value, cancellationToken);

            return topicos.ToResponse();
        }
    }
}
