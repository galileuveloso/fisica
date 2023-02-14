namespace Fisica.Classes
{
    public class Perfil : Entity
    {
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public DateTime Aniversario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
