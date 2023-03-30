using Fisica.Domains;
using Fisica.Models;
using Fisica.Website.Features.ComentarioAulaFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class ComentarioAulaExtensions
    {
        public static ComentarioAula ToDomain(this InserirComentarioAulaCommand request)
        {
            return new()
            {
                AulaId = request.AulaId!.Value,
                DataCadastro = DateTime.Now,
                Descricao = request.Descricao!
            };
        }

        public static ComentarioAulaModel ToResponse(this ComentarioAula domain)
        {
            return new()
            {
                AulaId = domain.AulaId,
                DataCadastro = domain.DataCadastro,
                Descricao = domain.Descricao,
                NomeUsuario = domain.Usuario.Nome
            };
        }
    }
}
