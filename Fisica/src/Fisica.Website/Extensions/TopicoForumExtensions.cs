using Fisica.Domains;
using Fisica.Models;
using Fisica.Website.Features.TopicoForumFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class TopicoForumExtensions
    {
        public static TopicoForum ToDomain(this InserirTopicoForumCommand request)
        {
            return new()
            {
                ForumId = request.ForumId,
                Descricao = request.Descricao,
                Titulo = request.Titulo,
                DataCadastro = DateTime.Now
            };
        }

        public static TopicoForumModel ToResponse(this TopicoForum topico)
        {
            return new()
            {
                DataCadastro = topico.DataCadastro,
                Descricao = topico.Descricao,
                Id = topico.Id,
                Titulo = topico.Titulo,
                UsuarioCadastro = topico.Usuario.Nome
            };
        }

        public static IEnumerable<TopicoForumModel> ToResponse(this IEnumerable<TopicoForum> topicos)
        {
            IList<TopicoForumModel> list = new List<TopicoForumModel>();

            foreach (TopicoForum topico in topicos)
                list.Add(ToResponse(topico));

            return list;
        }
    }
}
