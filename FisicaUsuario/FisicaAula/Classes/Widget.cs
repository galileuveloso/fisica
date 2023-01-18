namespace FisicaUsuario.Classes
{
    public class Widget : Entity
    {
        public string? Descricao { get; set; }
        public Usuario? Usuario { get; set; }
        public long IdAula { get; set; }
    }
}
