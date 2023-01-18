using FisicaAula.Enums;

namespace FisicaAula.Classes
{
    public class Usuario : Entity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int Cpf { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Perfil? Perfil { get; set; }
        public Instituicao? Instituicao { get; set; }
    }
}
