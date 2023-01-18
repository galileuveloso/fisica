using FisicaUsuario.Classes;
using FisicaUsuario.Dados.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FisicaUsuario.Interfaces;

namespace FisicaUsuario.Dados.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Favorito>), typeof(Repository<Favorito>));
            services.AddScoped(typeof(IRepository<Instituicao>), typeof(Repository<Instituicao>));
            services.AddScoped(typeof(IRepository<Perfil>), typeof(Repository<Perfil>));
            services.AddScoped(typeof(IRepository<Usuario>), typeof(Repository<Usuario>));
            services.AddScoped(typeof(IRepository<Widget>), typeof(Repository<Widget>));
        }

        public static void SetupDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FisicaUsuarioDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(DbContext).Assembly.FullName)
            ));
        }
    }
}
