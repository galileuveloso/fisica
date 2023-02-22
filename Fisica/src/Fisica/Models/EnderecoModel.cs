using Fisica.Domains;

namespace Fisica.Models
{
    public class EnderecoModel
    {
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public long CidadeId { get; set; }
        public CidadeModel Cidade { get; set; }
        public long? InstituicaoId { get; set; }
    }
}
