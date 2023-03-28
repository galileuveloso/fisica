namespace Fisica.Models
{
    public class RespostaTopicoModel
    {
        public long Id { get; set; }
        public long TopicoForumId { get; set; }
        public string Descricao { get; set; }
        public string NomeUsuario { get; set; }
    }
}
