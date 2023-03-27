using Fisica.Classes;
using Fisica.Dados.Repositories;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fisica.Website.Features.UsuarioFeature.Commands.Login
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
        public string Token { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, UsuarioResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Usuario> _repository;

        public LoginCommandHandler(IConfiguration configuration, IRepository<Usuario> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<UsuarioResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<LoginCommand>());

            request.Validate();

            string hash = await _repository.ObterHash(request.Senha!, cancellationToken);

            Usuario? usuario = await _repository.GetSingleAsync(x => x.Login == request.Login! && x.Senha == hash, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuário não encontrado.");

            IList<Claim> claims = new List<Claim>
            {
                new("idUsuario", usuario.Id.ToString())
            };

            string chaveJwt = _configuration.GetValue<string>("jwt:key")!;

            JwtSecurityToken token = new(
                issuer: _configuration.GetValue<string>("jwt:issuer"),
                audience: _configuration.GetValue<string>("jwt:audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("jwt:timeout")),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(chaveJwt)), SecurityAlgorithms.HmacSha256)
            );

            UsuarioResponse response = usuario.ToResponseLogin();

            response.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return response;
        }
    }
}
