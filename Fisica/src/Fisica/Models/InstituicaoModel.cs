namespace Fisica.Models
{
    public class InstituicaoModel
    {
        public long? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public long? EnderecoId { get; set; }
    }
}
