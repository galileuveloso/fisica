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
            services.AddScoped(typeof(IRepository<Forum>), typeof(Repository<Forum>));
            services.AddScoped(typeof(IRepository<TopicoForum>), typeof(Repository<TopicoForum>));
            services.AddScoped(typeof(IRepository<RespostaTopico>), typeof(Repository<RespostaTopico>));
            services.AddScoped(typeof(IRepository<Replica>), typeof(Repository<Replica>));
            services.AddScoped(typeof(IRepository<Aula>), typeof(Repository<Aula>));
            services.AddScoped(typeof(IRepository<SessaoAula>), typeof(Repository<SessaoAula>));
            services.AddScoped(typeof(IRepository<AreaFisica>), typeof(Repository<AreaFisica>));
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
