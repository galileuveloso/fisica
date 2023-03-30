namespace Fisica.Models
{
    public class ComentarioAulaModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeUsuario { get; set; }
        public long AulaId { get; set; }
    }
}
