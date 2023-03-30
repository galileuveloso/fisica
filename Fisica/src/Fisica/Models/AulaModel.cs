namespace Fisica.Models
{
    public class AulaModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AreaFisica { get; set; }
        public string ProfessorNome { get; set; }
        public long ProfessorId { get; set; }
        public IList<SessaoAulaModel>? Sessoes { get; set; }
        public IList<ComentarioAulaModel>? Comentarios { get; set; }
    }
}
