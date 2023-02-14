using Fisica.Classes;
using Fisica.Domains;
using Microsoft.EntityFrameworkCore;

namespace Fisica.Dados.Extensions.Tables
{
    public static class TablesExtensions
    {
        public static void SetupTabelas(this ModelBuilder modelBuilder)
        {
            //CIDADE
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


            //ENDERECO
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


            //FAVORITO              TO - DO: Colcoar as navegabiliddes pra Aula e Sessao Aula quando trouxer todas as Entities
            modelBuilder
               .Entity<Favorito>()
               .HasOne(x => x.Usuario)
               .WithMany(x => x.Favoritos)
               .HasForeignKey(x => x.UsuarioId);


            //INSTITUICAO
            modelBuilder
               .Entity<Instituicao>()
               .Property(x => x.Nome)
               .HasMaxLength(200);
            modelBuilder
               .Entity<Instituicao>()
               .Property(x => x.Descricao)
               .HasMaxLength(200);
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


            //PERFIL
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


            //USUARIO
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


            //WIDGET
            modelBuilder
             .Entity<Widget>()
             .HasOne(x => x.Usuario)
             .WithMany(x => x.Widgets)
             .HasForeignKey(x => x.UsuarioId);
            modelBuilder
              .Entity<Widget>()
              .Property(x => x.Descricao)
              .HasMaxLength(200);
            //TO - DO: Colcoar a Prop da Aula.
        }
    }
}
