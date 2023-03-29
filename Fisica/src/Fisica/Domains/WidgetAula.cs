namespace Fisica.Domains
{
    public class WidgetAula : Entity
    {
        public long WidgetId { get; set; }
        private Widget _Widget;
        public virtual Widget Widget { get { return _Widget; } set { _Widget = value; SetWidget(value); } }

        public long AulaId { get; set; }
        private Aula _Aula;
        public virtual Aula Aula { get { return _Aula; } set { _Aula = value; SetAula(value); } }

        private void SetWidget(Widget value)
        {
            WidgetId = value is null ? 0 : value.Id;
        }

        private void SetAula(Aula value)
        {
            AulaId = value is null ? 0 : value.Id;
        }
    }
}
