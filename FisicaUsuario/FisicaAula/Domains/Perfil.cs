namespace FisicaUsuario.Classes
{
    public class Perfil : Entity
    {
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public DateTime Aniversario { get; set; }

        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }
    }
}
