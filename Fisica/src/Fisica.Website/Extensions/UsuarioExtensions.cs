using Fisica.Classes;
using Fisica.Website.Features.UsuarioFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class UsuarioExtensions
    {
        public static Usuario ToDomain(this InserirUsuarioCommand request)
        {
            return new()
            {
                Nome = request.Nome!,
                Cpf = request.Cpf!,
                Email = request.Email!,
                Login = request.Login!,
                Senha = request.Senha!,
                TipoUsuario = request.TipoUsuario!.Value,
                Perfil = new()
                {
                    Descricao = ""
                },
                InstituicaoId = request.Instituicao?.Id
            };
        }

        public static UsuarioResponse ToResponse(this Usuario usuario)
        {
            return new()
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                TipoUsuario = usuario.TipoUsuario
            };
        }
    }
}
