using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FisicaUsuario.Dados.Repositories
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbConnection Connection { get; }
    }
}
