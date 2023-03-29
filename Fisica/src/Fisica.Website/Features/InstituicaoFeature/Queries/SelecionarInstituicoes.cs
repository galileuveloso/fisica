using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.InstituicaoFeature.Queries
{
    public class SelecionarInstituicoesQuery : IRequest<IEnumerable<InstituicaoResponse>>
    {
        public long? UsuarioId { get; set; }
        public void Validate()
        {
        }
    }

    public class InstituicaoResponse
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public EnderecoModel Endereco { get; set; }
    }

    public class SelecionarInstituicoes : IRequestHandler<SelecionarInstituicoesQuery, IEnumerable<InstituicaoResponse>>
    {
        private readonly IRepository<Instituicao> _repository;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public SelecionarInstituicoes(IRepository<Instituicao> repository, IRepository<Usuario> repositoryUsuario)
        {
            _repository = repository;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<IEnumerable<InstituicaoResponse>> Handle(SelecionarInstituicoesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarInstituicoesQuery>());

            request.Validate();

            request.UsuarioId = 1;

            if (!await _repositoryUsuario.ExistsAsync(x => x.Id == request.UsuarioId, cancellationToken))
                throw new ObjectNotFoundException("Usuário não encontrado.");

            if (!await _repositoryUsuario.ExistsAsync(x => x.Id == request.UsuarioId && x.TipoUsuario == (int)TipoUsuario.Adminstrador, cancellationToken))
                throw new InvalidOperationException("Usuário informado não tem acesso as instituições.");

            return (await _repository.GetAsync(cancellationToken, x => x.Endereco.Cidade)).ToResponse();
        }
    }
}
