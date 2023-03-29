using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.TopicoForumFeature.Queries
{
    public class SelecionarTopicoForumByIdQuery : IRequest<TopicoForumModel>
    {
        public long? TopicoForumId { get; set; }

        public void Validar()
        {

        }
    }

    public class SelecionarTopicoForumByIdHandler : IRequestHandler<SelecionarTopicoForumByIdQuery, TopicoForumModel>
    {
        private readonly IRepository<TopicoForum> _repositoryTopicoForum;
        private readonly IRepository<RespostaTopico> _repositoryRespostaTopico;

        public SelecionarTopicoForumByIdHandler(IRepository<TopicoForum> repositoryTopicoForum, IRepository<RespostaTopico> repositoryRespostaTopico)
        {
            _repositoryTopicoForum = repositoryTopicoForum;
            _repositoryRespostaTopico = repositoryRespostaTopico;
        }

        public async Task<TopicoForumModel> Handle(SelecionarTopicoForumByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarTopicosForumByForumQuery>());

            if (!await _repositoryTopicoForum.ExistsAsync(x => x.Id == request.TopicoForumId, cancellationToken))
                throw new ObjectNotFoundException("Tópico do Fórum não encontrado.");

            TopicoForum topico = await _repositoryTopicoForum.GetSingleAsync(x => x.Id == request.TopicoForumId!.Value, cancellationToken, x => x.Usuario);

            topico.Respostas = await _repositoryRespostaTopico.GetAsync(x => x.TopicoForumId == request.TopicoForumId!.Value, cancellationToken, x => x.Replicas, x => x.Usuario);

            return topico.ToResponseWithRespostas();
        }
    }
}
