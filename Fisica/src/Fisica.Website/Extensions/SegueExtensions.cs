using Fisica.Domains;
using Fisica.Website.Features.SegueFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class SegueExtensions
    {
        public static Segue ToDomain(this SeguirProfessorCommand request, long usuarioId)
        {
            return new()
            {
                ProfessorId = request.ProfessorId!.Value,
                UsuarioId = usuarioId
            };
        }
    }
}
