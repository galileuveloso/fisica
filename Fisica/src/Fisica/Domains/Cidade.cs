using Fisica.Classes;

namespace Fisica.Domains
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }
        public string UF { get; set; }
        public IEnumerable<Endereco>? Enderecos { get; set; }
    }
}
