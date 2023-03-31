namespace Fisica.Models
{
    public class WidgetAulaModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        public IList<AulaModel> Aulas { get; set; }
    }
}
