using Fisica.Classes;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Queries;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.UsuarioFeature.Queries
{
    public class SelecionarUsuariosQuery : IRequest<IEnumerable<UsuarioResponse>>
    {
    }

    public class UsuarioResponse
    {
        public long Id { get; set; }
        public string? Login { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public int? TipoUsuario { get; set; }
        public string? Instituicao { get; set; }
    }

    public class SelecionarUsuariosHandler : IRequestHandler<SelecionarUsuariosQuery, IEnumerable<UsuarioResponse>>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;

        public SelecionarUsuariosHandler(IRepository<Usuario> repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<IEnumerable<UsuarioResponse>> Handle(SelecionarUsuariosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarInstituicoesQuery>());

            if (!await _repositoryUsuario.ExistsAsync(x => x.Id == 1 && x.TipoUsuario == (int)TipoUsuario.Adminstrador, cancellationToken))
                throw new InvalidOperationException("Usuário informado não tem acesso aos usuarios.");

            return (await _repositoryUsuario.GetAsync(cancellationToken, x => x.Instituicao)).ToResponse();
        }
    }
}
