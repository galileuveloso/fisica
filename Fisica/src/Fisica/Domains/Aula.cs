using Fisica.Interfaces;

namespace Fisica.Domains
{
    public class Aula : Entity, IFavoritavel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public long ProfessorId { get; set; }
        private Usuario _Professor;
        public virtual Usuario Professor { get { return _Professor; } set { _Professor = value; SetProfessor(value); } }

        public long AreaFisicaId { get; set; }
        private AreaFisica _AreaFisica;
        public virtual AreaFisica AreaFisica { get { return _AreaFisica; } set { _AreaFisica = value; SetAreaFisica(value); } }

        public IEnumerable<WidgetAula>? WidgetsAulas { get; set; }

        public IEnumerable<ComentarioAula>? Comentarios { get; set; }

        public IEnumerable<VisualizacaoAula>? Visualizacoes { get; set; }

        public IEnumerable<SessaoAula>? Sessoes { get; set; }

        public IList<Favorito>? Favoritos { get; set; }

        private void SetProfessor(Usuario value)
        {
            ProfessorId = value is null ? 0 : value.Id;
        }

        private void SetAreaFisica(AreaFisica value)
        {
            AreaFisicaId = value is null ? 0 : value.Id;
        }
    }
}
