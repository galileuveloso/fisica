﻿using FisicaUsuario.Classes;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FisicaUsuario.Dados.Repositories
{
    public class FisicaUsuarioDbContext : DbContext, IDbContext
    {
        public FisicaUsuarioDbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Widget> Widgets { get; set; }

        public DbConnection Connection => base.Database.GetDbConnection();
    }
}
