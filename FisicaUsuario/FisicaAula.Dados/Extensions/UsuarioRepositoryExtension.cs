using Dapper;
using FisicaUsuario.Classes;
using FisicaUsuario.Interfaces;

namespace FisicaUsuario.Dados.Extensions
{
    public static class UsuarioRepositoryExtension
    {
        public static async Task<Usuario> ObterUsuarioPorLogin(this IRepository<Usuario> repository, string login, string senha)
        {
            string sql = @"SELECT id FROM Usuario WHERE login = :Login AND senha = md5(:senha)";

            long? id = await repository.Connection.QuerySingleOrDefaultAsync<long?>(sql, new { Login = login, Senha = senha });

            return await repository.GetFirstAsync(x => x.Id == id);
        }
    }
}
