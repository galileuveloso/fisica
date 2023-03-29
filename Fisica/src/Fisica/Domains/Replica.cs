namespace Fisica.Domains
{
    public class Replica : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public long UsuarioId { get; set; }
        private Usuario _Usuario;
        public virtual Usuario Usuario { get { return _Usuario; } set { _Usuario = value; SetUsuario(value); } }

        public long RespostaTopicoId { get; set; }
        private RespostaTopico _RespostaTopico;
        public virtual RespostaTopico RespostaTopico { get { return _RespostaTopico; } set { _RespostaTopico = value; SetResposta(value); } }

        private void SetUsuario(Usuario value)
        {
            UsuarioId = value is null ? 0 : value.Id;
        }

        private void SetResposta(RespostaTopico value)
        {
            RespostaTopicoId = value is null ? 0 : value.Id;
        }
    }
}
