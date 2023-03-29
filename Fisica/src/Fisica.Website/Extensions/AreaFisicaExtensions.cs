using Fisica.Domains;
using Fisica.Models;

namespace Fisica.Website.Extensions
{
    public static class AreaFisicaExtensions
    {
        public static AreaFisicaModel ToResponse(this AreaFisica domain)
        {
            return new()
            {
                Descricao = domain.Descricao,
                Id = domain.Id
            };
        }

        public static IEnumerable<AreaFisicaModel> ToResponse(this IEnumerable<AreaFisica> areas)
        {
            IList<AreaFisicaModel> result = new List<AreaFisicaModel>();

            foreach (AreaFisica area in areas)
                result.Add(area.ToResponse());

            return result;
        }
    }
}
