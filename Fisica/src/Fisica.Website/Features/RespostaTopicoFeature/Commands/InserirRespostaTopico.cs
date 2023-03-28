using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.RespostaTopicoFeature.Commands
{
    public class InserirRespostaTopicoCommand : IRequest<RespostaTopicoModel>
    {
        public long? TopicoForumId { get; set; }
        public string? Descricao { get; set; }

        public void Validar()
        {

        }
    }

    public class InserirRespostaTopicoHandler : IRequestHandler<InserirRespostaTopicoCommand, RespostaTopicoModel>
    {
        private readonly IRepository<TopicoForum> _repositoryTopicoForum;
        private readonly IRepository<RespostaTopico> _repositoryRespostaTopico;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public InserirRespostaTopicoHandler(IRepository<TopicoForum> repositoryTopicoForum, IRepository<RespostaTopico> repositoryRespostaTopico, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryTopicoForum = repositoryTopicoForum;
            _repositoryRespostaTopico = repositoryRespostaTopico;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<RespostaTopicoModel> Handle(InserirRespostaTopicoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirRespostaTopicoCommand>());

            if (!await _repositoryRespostaTopico.ExistsAsync(x => x.Id == request.TopicoForumId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Tópico não encontrado");

            RespostaTopico resposta = request.ToDomain();

            resposta.Usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            await _repositoryRespostaTopico.AddAsync(resposta, cancellationToken);
            await _repositoryRespostaTopico.SaveChangesAsync(cancellationToken);

            return resposta.ToResponse();
        }
    }
}
