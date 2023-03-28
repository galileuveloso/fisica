namespace Fisica.Domains
{
    public class TopicoForum : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        public long ForumId { get; set; }
        private Forum _Forum;
        public virtual Forum Forum { get { return _Forum; } set { _Forum = value; SetForum(value); } }

        public IEnumerable<RespostaTopico>? Respostas { get; set; }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }

        private void SetForum(Forum value)
        {
            ForumId = value is null ? 0 : value.Id;
        }
    }
}
