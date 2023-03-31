using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.UsuarioFeature.Queries
{
    public class SelecionarProfessoresQuery : IRequest<IEnumerable<UsuarioResponse>>
    {
    }

    public class SelecionarProfessoresHandler : IRequestHandler<SelecionarProfessoresQuery, IEnumerable<UsuarioResponse>>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;

        public SelecionarProfessoresHandler(IRepository<Usuario> repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<IEnumerable<UsuarioResponse>> Handle(SelecionarProfessoresQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarProfessoresQuery>());

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            if (usuario.TipoUsuarioEnum != TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não é um administrador.");

            IEnumerable<Usuario> professores = await _repositoryUsuario.GetAsync(x => x.TipoUsuario == (int)TipoUsuario.Adminstrador, cancellationToken);

            return professores.ToResponse();
        }
    }
}
