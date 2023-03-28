using Fisica.Classes;
using Fisica.Dados.Repositories;
using Fisica.Domains;
using Fisica.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fisica.Dados.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Cidade>), typeof(Repository<Cidade>));
            services.AddScoped(typeof(IRepository<Endereco>), typeof(Repository<Endereco>));
            services.AddScoped(typeof(IRepository<Favorito>), typeof(Repository<Favorito>));
            services.AddScoped(typeof(IRepository<Instituicao>), typeof(Repository<Instituicao>));
            services.AddScoped(typeof(IRepository<Perfil>), typeof(Repository<Perfil>));
            services.AddScoped(typeof(IRepository<Usuario>), typeof(Repository<Usuario>));
            services.AddScoped(typeof(IRepository<Widget>), typeof(Repository<Widget>));
            services.AddScoped(typeof(IRepository<Noticia>), typeof(Repository<Noticia>));
            services.AddScoped(typeof(IRepository<Segue>), typeof(Repository<Segue>));
        }

        public static void SetupDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<FisicaDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(FisicaDbContext).Assembly.FullName)),
                ServiceLifetime.Transient, ServiceLifetime.Transient
                );
        }
    }
}
