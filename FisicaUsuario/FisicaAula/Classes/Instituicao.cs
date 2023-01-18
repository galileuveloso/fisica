namespace FisicaUsuario.Classes
{
    public class Instituicao : Entity
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
    }
}
