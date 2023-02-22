using Fisica.Website.Features.UsuarioFeature.Commands;
using Fisica.Classes;

namespace Fisica.Website.Extensions
{
    public static class UsuarioInstituicao
    {
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
