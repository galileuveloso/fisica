using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using Fisica.Classes;
using Fisica.Dados.Repositories;
using Fisica.Interfaces;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.UsuarioFeature.Commands
{
    public class LoginCommand : IRequest<UsuarioResponse>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Login não informado.");
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Senha não informada.");
        }
    }

    public class UsuarioResponse
    {
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public int TipoUsuario { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, UsuarioResponse>
    {
        private readonly IRepository<Usuario> _repository;

        public LoginCommandHandler(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<LoginCommand>());

            request.Validate();

            Usuario? usuario = await _repository.ObterUsuarioPorLogin(request.Login!, request.Senha!, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuário não encontrado.");

            return usuario.ToResponse();
        }
    }
}
