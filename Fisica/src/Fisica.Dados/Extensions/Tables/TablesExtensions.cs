using Fisica.Domains;
using Microsoft.EntityFrameworkCore;

namespace Fisica.Dados.Extensions.Tables
{
    public static class TablesExtensions
    {
        public static void SetupTabelas(this ModelBuilder modelBuilder)
        {
            #region Cidade

            modelBuilder
               .Entity<Cidade>()
               .Property(x => x.Nome)
               .HasMaxLength(200);
            modelBuilder
               .Entity<Cidade>()
               .Property(x => x.UF)
               .HasMaxLength(2);
            modelBuilder
              .Entity<Cidade>()
              .HasMany(x => x.Enderecos)
              .WithOne(x => x.Cidade);
            #endregion

            #region Endereco
            modelBuilder
               .Entity<Endereco>()
               .Property(x => x.Bairro)
               .HasMaxLength(200);
            modelBuilder
               .Entity<Endereco>()
               .Property(x => x.Logradouro)
               .HasMaxLength(200);
            modelBuilder
               .Entity<Endereco>()
               .HasOne(x => x.Cidade)
               .WithMany(x => x.Enderecos)
               .HasForeignKey(x => x.CidadeId);
            #endregion

            #region Favorito
            //TO - DO: Colcoar as navegabiliddes pra Aula e Sessao Aula quando trouxer todas as Entities
            modelBuilder
               .Entity<Favorito>()
               .HasOne(x => x.Usuario)
               .WithMany(x => x.Favoritos)
               .HasForeignKey(x => x.UsuarioId);
            modelBuilder
              .Entity<Favorito>()
              .HasOne(x => x.Aula)
              .WithMany(x => x.Favoritos)
              .HasForeignKey(x => x.AulaId);
            modelBuilder
             .Entity<Favorito>()
             .HasOne(x => x.SessaoAula)
             .WithMany(x => x.Favoritos)
             .HasForeignKey(x => x.SessaoAulaId);
            #endregion

            #region Instituicao
            //INSTITUICAO
            modelBuilder
               .Entity<Instituicao>()
               .Property(x => x.Nome)
               .HasMaxLength(200);
            modelBuilder
               .Entity<Instituicao>()
               .Property(x => x.Descricao)
               .HasMaxLength(600);
            modelBuilder
              .Entity<Instituicao>()
              .Property(x => x.Email)
              .HasMaxLength(200);
            modelBuilder
              .Entity<Instituicao>()
              .Property(x => x.Site)
              .HasMaxLength(200);
            modelBuilder
              .Entity<Instituicao>()
              .HasOne(x => x.Endereco)
              .WithOne(x => x.Instituicao)
              .HasForeignKey<Instituicao>(x => x.EnderecoId);
            modelBuilder
              .Entity<Instituicao>()
              .HasMany(x => x.Usuarios)
              .WithOne(x => x.Instituicao);
            #endregion

            #region Noticia
            modelBuilder
                .Entity<Noticia>()
                .Property(x => x.Conteudo)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<Noticia>()
                .HasOne(x => x.Autor)
                .WithMany(x => x.Noticias)
                .HasForeignKey(x => x.AutorId);
            #endregion

            #region Perfil

            modelBuilder
              .Entity<Perfil>()
              .Property(x => x.Descricao)
              .HasMaxLength(200);
            modelBuilder
              .Entity<Perfil>()
              .Property(x => x.Foto)
              .HasMaxLength(400);
            modelBuilder
              .Entity<Perfil>()
              .HasOne(x => x.Usuario)
              .WithOne(x => x.Perfil);
            #endregion

            #region Usuario
            modelBuilder
                .Entity<Usuario>()
                .Property(x => x.Nome)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Usuario>()
                .Property(x => x.Email)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Usuario>()
                .Property(x => x.Cpf)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Usuario>()
                .Property(x => x.Login)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Usuario>()
                .Property(x => x.Senha)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Usuario>()
                .HasOne(x => x.Perfil)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Usuario>(x => x.PerfilId);
            modelBuilder
                .Entity<Usuario>()
                .HasOne(x => x.Instituicao)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.InstituicaoId);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Favoritos)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Noticias)
                .WithOne(x => x.Autor);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Seguindo)
                .WithMany(x => x.Seguidores)
                .UsingEntity<Segue>(
                    segue => segue.HasOne(x => x.Usuario).WithMany(),
                    segue => segue.HasOne(x => x.Professor).WithMany()
                   );
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.TopicosForum)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.RespostasTopicos)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.TopicosForum)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Replicas)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Widgets)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Visualizacoes)
                .WithOne(x => x.Usuario);
            modelBuilder
                .Entity<Usuario>()
                .HasMany(x => x.Aulas)
                .WithOne(x => x.Professor);
            #endregion

            #region Widget
            modelBuilder
                .Entity<Widget>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Widgets)
                .HasForeignKey(x => x.UsuarioId);
            modelBuilder
                .Entity<Widget>()
                .Property(x => x.Descricao)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Widget>()
                .HasMany(x => x.Aulas)
                .WithOne(x => x.Widget);
            #endregion

            #region Forum
            modelBuilder
                .Entity<Forum>()
                .Property(x => x.Titulo)
                 .HasMaxLength(200);
            modelBuilder
                .Entity<Forum>()
                .HasMany(x => x.Topicos)
                .WithOne(x => x.Forum);
            #endregion

            #region Topico Forum
            modelBuilder
                .Entity<TopicoForum>()
                .Property(x => x.Titulo)
                .HasMaxLength(200);
            modelBuilder
                .Entity<TopicoForum>()
                .Property(x => x.Descricao)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<TopicoForum>()
                .HasOne(x => x.Forum)
                .WithMany(x => x.Topicos)
                .HasForeignKey(x => x.ForumId);
            modelBuilder
                .Entity<TopicoForum>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.TopicosForum)
                .HasForeignKey(x => x.UsuarioId);
            modelBuilder
                .Entity<TopicoForum>()
                .HasMany(x => x.Respostas)
                .WithOne(x => x.TopicoForum);
            #endregion

            #region Resposta Topico
            modelBuilder
                .Entity<RespostaTopico>()
                .Property(x => x.Descricao)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<RespostaTopico>()
                .HasOne(x => x.TopicoForum)
                .WithMany(x => x.Respostas)
                .HasForeignKey(x => x.TopicoForumId);
            modelBuilder
                .Entity<RespostaTopico>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.RespostasTopicos)
                .HasForeignKey(x => x.UsuarioId);
            #endregion

            #region Replica
            modelBuilder
                .Entity<Replica>()
                .Property(x => x.Descricao)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<Replica>()
                .HasOne(x => x.RespostaTopico)
                .WithMany(x => x.Replicas)
                .HasForeignKey(x => x.RespostaTopicoId);
            modelBuilder
                .Entity<Replica>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Replicas)
                .HasForeignKey(x => x.UsuarioId);
            #endregion

            #region Widget
            modelBuilder
                .Entity<Widget>()
                .Property(x => x.Descricao)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Widget>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Widgets)
                .HasForeignKey(x => x.UsuarioId);
            modelBuilder
                .Entity<Widget>()
                .HasMany(x => x.Aulas)
                .WithOne(x => x.Widget);
            #endregion

            #region Widget Aula
            modelBuilder
                .Entity<WidgetAula>()
                .HasOne(x => x.Widget)
                .WithMany(x => x.Aulas)
                .HasForeignKey(x => x.WidgetId);
            modelBuilder
                .Entity<WidgetAula>()
                .HasOne(x => x.Aula)
                .WithMany(x => x.WidgetsAulas)
                .HasForeignKey(x => x.AulaId);
            #endregion

            #region Aula
            modelBuilder
                .Entity<Aula>()
                .Property(x => x.Descricao)
                .HasMaxLength(200);
            modelBuilder
                .Entity<Aula>()
                .HasOne(x => x.AreaFisica)
                .WithMany(x => x.Aulas)
                .HasForeignKey(x => x.AreaFisicaId);
            modelBuilder
                .Entity<Aula>()
                .HasMany(x => x.WidgetsAulas)
                .WithOne(x => x.Aula);
            modelBuilder
                .Entity<Aula>()
                .HasOne(x => x.Professor)
                .WithMany(x => x.Aulas)
                .HasForeignKey(x => x.ProfessorId);
            modelBuilder
                .Entity<Aula>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Aula);
            modelBuilder
                .Entity<Aula>()
                .HasMany(x => x.Visualizacoes)
                .WithOne(x => x.Aula);
            modelBuilder
                .Entity<Aula>()
                .HasMany(x => x.Sessoes)
                .WithOne(x => x.Aula);
            #endregion

            #region Sessao Aula
            modelBuilder
                .Entity<SessaoAula>()
                .Property(x => x.Conteudo)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<SessaoAula>()
                .HasOne(x => x.Aula)
                .WithMany(x => x.Sessoes);
            //TO-DO: Arquivos.
            #endregion

            #region Area Fisica
            modelBuilder
                .Entity<AreaFisica>()
                .Property(x => x.Descricao)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<AreaFisica>()
                .HasMany(x => x.Aulas)
                .WithOne(x => x.AreaFisica);
            #endregion

            #region Comentario Aula
            modelBuilder
                .Entity<ComentarioAula>()
                .Property(x => x.Descricao)
                .HasMaxLength(8000);
            modelBuilder
                .Entity<ComentarioAula>()
                .HasOne(x => x.Aula)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.AulaId);
            modelBuilder
                .Entity<ComentarioAula>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.UsuarioId);
            #endregion

            #region Visualizacao Aula
            modelBuilder
                .Entity<VisualizacaoAula>()
                .Property(x => x.Maquina)
                .HasMaxLength(200);
            modelBuilder
                .Entity<VisualizacaoAula>()
                .HasOne(x => x.Aula)
                .WithMany(x => x.Visualizacoes)
                .HasForeignKey(x => x.AulaId);
            modelBuilder
                .Entity<VisualizacaoAula>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Visualizacoes)
                .HasForeignKey(x => x.UsuarioId);
            #endregion
        }
    }
}
