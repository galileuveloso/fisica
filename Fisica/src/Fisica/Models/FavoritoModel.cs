namespace Fisica.Models
{
    public class FavoritoModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long? AulaId { get; set; }
        public long? SessaoAulaId { get; set; }
    }
}
