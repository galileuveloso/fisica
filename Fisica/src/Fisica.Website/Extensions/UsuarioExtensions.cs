using Fisica.Classes;
using Fisica.Website.Features.UsuarioFeature.Commands;
using Fisica.Website.Features.UsuarioFeature.Queries;

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

        public static Features.UsuarioFeature.Commands.Login.UsuarioResponse ToResponseLogin(this Usuario usuario)
        {
            return new()
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public static UsuarioResponse ToResponse(this Usuario usuario)
        {
            return new()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Cpf = usuario.Cpf,
                TipoUsuario = usuario.TipoUsuario,
                Login = usuario.Login,
                Instituicao = usuario.Instituicao?.Nome
            };
        }

        public static IEnumerable<UsuarioResponse> ToResponse(this IEnumerable<Usuario> usuarios)
        {
            IList<UsuarioResponse> resultado = new List<UsuarioResponse>();

            foreach (Usuario usuario in usuarios)
                resultado.Add(usuario.ToResponse());

            return resultado;
        }
    }
}
