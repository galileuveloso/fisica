using Fisica.Interfaces;

namespace Fisica.Domains
{
    public class SessaoAula : Entity, IFavoritavel
    {
        public int Ordem { get; set; }
        public string Conteudo { get; set; }
        public int TipoSessao { get; set; }

        //VER O QUE FAZER COM OS ARQUIVOS

        public long AulaId { get; set; }
        private Aula _Aula;
        public virtual Aula Aula { get { return _Aula; } set { _Aula = value; SetAula(value); } }

        public IList<Favorito>? Favoritos { get; set; }

        private void SetAula(Aula value)
        {
            AulaId = value is null ? 0 : value.Id;
        }
    }
}
