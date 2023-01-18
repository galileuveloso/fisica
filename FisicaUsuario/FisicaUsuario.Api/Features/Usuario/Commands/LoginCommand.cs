using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Dados.Extensions;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Data.Entity.Core;
using FisicaUsuario.Classes;

namespace FisicaUsuario.Api.Features.User.Commands
{
    public class LoginCommand : IRequest<Usuario>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Login não informado.");
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Senha não informada.");
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Usuario>
    {
        private readonly IRepository<Usuario> _repository;

        public LoginCommandHandler(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<LoginCommand>());

            request.Validate();

            Usuario? usuario = await _repository.ObterUsuarioPorLogin(request.Login!, request.Senha!);

            if (usuario == null)
                throw new ObjectNotFoundException(MessageHelper.NotFoundFor<Usuario>());

            return usuario;
        }
    }
}
