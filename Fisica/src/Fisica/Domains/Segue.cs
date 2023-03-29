namespace Fisica.Domains
{
    public class Segue : Entity
    {
        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        public long ProfessorId { get; set; }
        private Usuario _Professor;
        public virtual Usuario Professor { get { return _Professor; } set { _Professor = value; SetProfessor(value); } }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }

        private void SetProfessor(Usuario value)
        {
            ProfessorId = value is null ? 0 : value.Id;
        }
    }
}
