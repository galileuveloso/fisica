using Dapper;
using Fisica.Classes;
using Fisica.Interfaces;

namespace Fisica.Dados.Repositories
{
    public static class RepositoryUsuarioExtension
    {
        public static async Task<Usuario> ObterUsuarioPorLogin(this IRepository<Usuario> repository, string login, string senha, CancellationToken cancellationToken)
        {
            string sql = @"SELECT id FROM Usuario WHERE login = :Login AND senha = md5(:senha)";

            long? id = await repository.Connection.QuerySingleOrDefaultAsync<long?>(sql, new { Login = login, Senha = senha });

            return await repository.GetSingleAsync(x => x.Id == id, cancellationToken);
        }
    }
}
