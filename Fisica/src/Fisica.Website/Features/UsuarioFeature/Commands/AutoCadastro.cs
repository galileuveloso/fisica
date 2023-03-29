using Fisica.Dados.Repositories;
using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Features.UsuarioFeature.Queries;
using Fisica.Website.Helpers;
using MediatR;
using System.Data;

namespace Fisica.Website.Features.UsuarioFeature.Commands
{
    public class AutoCadastroCommand : IRequest<UsuarioResponse>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? SobreMim { get; set; }

        public void Validar()
        {

        }
    }

    public class AutoCadastroHandler : IRequestHandler<AutoCadastroCommand, UsuarioResponse>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;

        public AutoCadastroHandler(IRepository<Usuario> repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<UsuarioResponse> Handle(AutoCadastroCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<AutoCadastroCommand>());

            request.Validar();

            if (await _repositoryUsuario.ExistsAsync(x => x.Cpf == request.Cpf, cancellationToken))
                throw new DuplicateNameException("Já existe um usuário com este cpf.");

            if (await _repositoryUsuario.ExistsAsync(x => x.Email == request.Email, cancellationToken))
                throw new DuplicateNameException("Já existe um usuário com este email.");

            Usuario usuario = request.ToDomain();

            await _repositoryUsuario.CriptografarSenha(usuario);

            await _repositoryUsuario.AddAsync(usuario, cancellationToken);
            await _repositoryUsuario.SaveChangesAsync(cancellationToken);

            return usuario.ToResponse();
        }
    }
}
