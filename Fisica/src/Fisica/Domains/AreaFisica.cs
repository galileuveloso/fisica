namespace Fisica.Domains
{
    public class AreaFisica : Entity
    {
        public string Descricao { get; set; }

        public IEnumerable<Aula>? Aulas { get; set; }
    }
}
