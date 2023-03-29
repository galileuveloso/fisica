using Fisica.Domains;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Fisica.Dados
{
    public class FisicaDbContext : DbContext, IDbContext
    {
        public FisicaDbContext(DbContextOptions<FisicaDbContext> options) : base(options) { }

        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Segue> Segue { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<TopicoForum> TopicoForum { get; set; }
        public DbSet<RespostaTopico> RespostaTopico { get; set; }
        public DbSet<Replica> Replica { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<AreaFisica> AreaFisica { get; set; }
        public DbSet<SessaoAula> SessaoAula { get; set; }
        public DbSet<WidgetAula> WidgetAula { get; set; }
        public DbSet<Widget> Widget { get; set; }
        public DbSet<ComentarioAula> ComentarioAula { get; set; }
        public DbSet<VisualizacaoAula> VisualizacaoAula { get; set; }

        public DbConnection Connection => base.Database.GetDbConnection();
    }
}
