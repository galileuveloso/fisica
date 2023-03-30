using Fisica.Domains;
using Fisica.Models;
using Fisica.Website.Features.AulaFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class AulaExtension
    {
        public static Aula ToDomain(this InserirAulaCommand request)
        {
            return new()
            {
                Titulo = request.Titulo!,
                Descricao = request.Descricao!,
                DataCadastro = DateTime.Now
            };
        }

        public static AulaModel ToResponse(this Aula aula)
        {
            return new()
            {
                Descricao = aula.Descricao,
                Titulo = aula.Titulo,
                AreaFisica = aula.AreaFisica.Descricao,
                ProfessorNome = aula.Professor.Nome
            };
        }

        public static IEnumerable<AulaModel> ToResponse(this IEnumerable<Aula> aulas)
        {
            IList<AulaModel> result = new List<AulaModel>();

            foreach (Aula aula in aulas)
                result.Add(aula.ToResponse());

            return result;
        }

        public static AulaModel ToResponseWithSessoesAndComentarios(this Aula aula)
        {
            AulaModel response = new()
            {
                Descricao = aula.Descricao,
                Titulo = aula.Titulo,
                AreaFisica = aula.AreaFisica.Descricao,
                ProfessorNome = aula.Professor.Nome,
                ProfessorId = aula.ProfessorId,
                Sessoes = new List<SessaoAulaModel>(),
                Comentarios = new List<ComentarioAulaModel>()
            };

            foreach (SessaoAula sessao in aula.Sessoes)
                response.Sessoes.Add(sessao.ToResponse());

            foreach (ComentarioAula comentario in aula.Comentarios)
                response.Comentarios.Add(comentario.ToResponse());

            return response;
        }
    }
}
