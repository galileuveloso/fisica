using Dapper;
using Fisica.Classes;
using Fisica.Interfaces;

namespace Fisica.Dados.Repositories
{
    public static class RepositoryUsuarioExtension
    {
        public static async Task<string> ObterHash(this IRepository<Usuario> repository, string senha, CancellationToken cancellationToken)
        {
            string sql = @"SELECT md5(:Senha)";

            return await repository.Connection.QuerySingleAsync<string>(sql, new { Senha = senha });
        }

        public static async Task CriptografarSenha(this IRepository<Usuario> repository, Usuario usuario)
        {
            string sql = "SELECT md5(:Senha)";

            usuario.Senha = await repository.Connection.QuerySingleAsync<string>(sql, new { usuario.Senha });
        }
    }
}
