namespace Fisica.Classes
{
    public class Favorito : Entity
    {
        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }


        //TO - DO: Colocar as prop quando colocar todas as entities neste projeto
        public long? AulaId { get; set; }

        public long? SessaoAula { get; set; }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }
    }
}
