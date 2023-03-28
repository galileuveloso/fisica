using Fisica.Classes;

namespace Fisica.Domains
{
    public class Forum : Entity
    {
        public string Titulo { get; set; }

        public IEnumerable<TopicoForum>? Topicos { get; set; }
    }
}
