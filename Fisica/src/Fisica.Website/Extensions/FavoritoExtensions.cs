using Fisica.Domains;
using Fisica.Models;

namespace Fisica.Website.Extensions
{
    public static class FavoritoExtensions
    {
        public static IEnumerable<FavoritoModel> ToResponse(this IEnumerable<Favorito> favoritos)
        {
            IList<FavoritoModel> result = new List<FavoritoModel>();

            foreach (Favorito item in favoritos)
            {
                result.Add(new()
                {
                    Id = item.Id,
                    AulaId = item.AulaId,
                    SessaoAulaId = item.SessaoAulaId,
                    Descricao = item.SessaoAula != null ? "Sessão " + item.SessaoAula.Ordem + "(" + item.SessaoAula.Aula.Titulo + ")" : item.Aula.Titulo
                });
            }

            return result;
        }
    }
}
