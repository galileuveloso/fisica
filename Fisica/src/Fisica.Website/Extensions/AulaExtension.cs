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
    }
}
