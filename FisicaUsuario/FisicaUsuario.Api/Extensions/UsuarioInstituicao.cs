using FisicaUsuario.Api.Features.UsuarioFeature.Commands;
using FisicaUsuario.Classes;

namespace FisicaUsuario.Api.Extensions
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
