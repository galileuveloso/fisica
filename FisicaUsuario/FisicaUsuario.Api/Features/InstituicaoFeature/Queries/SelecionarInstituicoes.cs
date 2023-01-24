using FisicaUsuario.Api.Extensions;
using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Classes;
using FisicaUsuario.Enums;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Data.Entity.Core;

namespace FisicaUsuario.Api.Features.InstituicaoFeature.Queries
{
    public class SelecionarInstituicoesQuery : IRequest<IEnumerable<InstituicaoResponse>>
    {
        public long? UsuarioId { get; set; }
        public void Validate()
        {
            if (UsuarioId is null || UsuarioId!.Value == 0) throw new ArgumentNullException(MessageHelper.NullFor<SelecionarInstituicoesQuery>(x => x.UsuarioId));
        }
    }

    public class InstituicaoResponse
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
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

            if (!await _repositoryUsuario.ExistsAsync(x => x.Id == request.UsuarioId, cancellationToken))
                throw new ObjectNotFoundException("Usuário não encontrado.");

            if (!await _repositoryUsuario.ExistsAsync(x => x.Id == request.UsuarioId && x.TipoUsuario == (int)TipoUsuario.Adminstrador, cancellationToken))
                throw new InvalidOperationException("Usuário informado não tem acesso as instituições.");

            return (await _repository.GetAsync(cancellationToken)).ToResponse();
        }
    }
}
