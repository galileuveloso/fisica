namespace Fisica.Models
{
    public class ReplicaModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeUsuario { get; set; }
        public long RespostaTopicoId { get; set; }
    }
}
