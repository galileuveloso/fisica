using FisicaAula.Classes;
using FisicaAula.Models;
using FisicaUsuario.Api.Helpers;
using MediatR;

namespace FisicaUsuario.Api.Features.User.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }

    public class LoginResponse : Response
    {
        public Usuario? Usuario { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<LoginCommand>());

            await Task.Delay(0, cancellationToken);

            return new();
        }
    }
}
