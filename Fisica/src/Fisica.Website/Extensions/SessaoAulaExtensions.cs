using Fisica.Domains;
using Fisica.Models;

namespace Fisica.Website.Extensions
{
    public static class SessaoAulaExtensions
    {
        public static SessaoAula ToDomain(this SessaoAulaModel sessao, long aulaId)
        {
            return new()
            {
                AulaId = aulaId,
                Conteudo = sessao.Conteudo,
                Ordem = sessao.Ordem,
                TipoSessao = sessao.TipoSessao
            };
        }

        public static SessaoAulaModel ToResponse(this SessaoAula sessao)
        {
            return new()
            {
                AulaId = sessao.AulaId,
                Conteudo = sessao.Conteudo,
                Ordem = sessao.Ordem,
                TipoSessao = sessao.TipoSessao
            };
        }
    }
}
