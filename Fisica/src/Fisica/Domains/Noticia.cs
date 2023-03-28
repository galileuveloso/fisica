using Fisica.Classes;

namespace Fisica.Domains
{
    public class Noticia : Entity
    {
        public string Conteudo { get; set; }
        public DateTime DataCadastro { get; set; }

        public long AutorId { get; set; }
        private Usuario _Autor;
        public virtual Usuario Autor { get { return _Autor; } set { _Autor = value; SetAutor(value); } }

        private void SetAutor(Usuario value)
        {
            AutorId = value is null ? 0 : value.Id;
        }
    }
}
