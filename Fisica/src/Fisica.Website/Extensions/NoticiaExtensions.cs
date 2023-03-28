using Fisica.Domains;
using Fisica.Models;

namespace Fisica.Website.Extensions
{
    public static class NoticiaExtensions
    {
        public static NoticiaModel ToResponse(this Noticia noticia)
        {
            return new()
            {
                AutorNome = noticia.Autor.Nome,
                Conteudo = noticia.Conteudo,
                DataCadastro = noticia.DataCadastro
            };
        }

        public static IEnumerable<NoticiaModel> ToResponse(this IEnumerable<Noticia> noticias)
        {
            IList<NoticiaModel> result = new List<NoticiaModel>();

            foreach (Noticia noticia in noticias)
                result.Add(ToResponse(noticia));

            return result;
        }
    }
}
