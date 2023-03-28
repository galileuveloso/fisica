namespace Fisica.Domains
{
    public class RespostaTopico : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        public long TopicoForumId { get; set; }
        private TopicoForum _TopicoForum;
        public virtual TopicoForum TopicoForum { get { return _TopicoForum; } set { _TopicoForum = value; SetTopico(value); } }

        public IEnumerable<Replica>? Replicas { get; set; }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }

        private void SetTopico(TopicoForum value)
        {
            TopicoForumId = value is null ? 0 : value.Id;
        }
    }
}
