namespace Fisica.Models
{
    public class TopicoForumModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime DataCadastro { get; set; }

        public IList<RespostaTopicoModel>? Respostas { get; set; }
    }
}
