﻿namespace Fisica.Domains
{
    public class Favorito : Entity
    {
        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        public long? AulaId { get; set; }
        private Aula _Aula;
        public virtual Aula Aula { get { return _Aula; } set { _Aula = value; SetAula(value); } }
        
        public long? SessaoAulaId { get; set; }
        private SessaoAula _SessaoAula;
        public virtual SessaoAula SessaoAula { get { return _SessaoAula; } set { _SessaoAula = value; SetSessaoAula(value); } }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }

        private void SetAula(Aula value)
        {
            AulaId = value is null ? 0 : value.Id;
        }
        
        private void SetSessaoAula(SessaoAula value)
        {
            SessaoAulaId = value is null ? 0 : value.Id;
        }
    }
}
