namespace FisicaAula.Classes
{
    public class Favorito : Entity
    {
        public Usuario? Usuario { get; set; }
        public long? IdAula { get; set; }
        public long? IdSessaoAula { get; set; }
    }
}
