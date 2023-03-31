using Dapper;
using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;

namespace Fisica.Dados.Repositories
{
    public static class RepositoryNoticiaExtensions
    {
        public static async Task<IEnumerable<NoticiaModel>> ObterUltimasNoticias(this IRepository<Noticia> repository)
        {
            string sql = @"
                            SELECT  n.Conteudo as Conteudo,
                                    n.DataCadastro as DataCadastro,
                                    u.Nome as AutorNome
                            FROM Noticia n
                            INNER JOIN Usuario u ON (u.Id = n.AutorId)
                            ORDER BY n.DataCadastro
                            LIMIT 10
                          ";

            return await repository.Connection.QueryAsync<NoticiaModel>(sql);
        }
    }
}
