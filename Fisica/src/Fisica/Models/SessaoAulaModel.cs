namespace Fisica.Models
{
    public class SessaoAulaModel
    {
        public long Id { get; set; }
        public long AulaId { get; set; }
        public string Conteudo { get; set; }
        public int Ordem { get; set; }
        public int TipoSessao { get; set; }
    }
}
