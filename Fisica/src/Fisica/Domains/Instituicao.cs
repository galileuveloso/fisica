namespace Fisica.Domains
{
    public class Instituicao : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }

        public long EnderecoId { get; set; }
        private Endereco _Endereco;
        public virtual Endereco Endereco { get { return _Endereco; } set { _Endereco = value; SetEndereco(value); } }

        public IEnumerable<Usuario>? Usuarios { get; set; }

        private void SetEndereco(Endereco value)
        {
            EnderecoId = value is null ? 0 : value.Id;
        }
    }
}
