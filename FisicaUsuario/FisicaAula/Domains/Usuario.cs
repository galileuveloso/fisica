using FisicaUsuario.Enums;

namespace FisicaUsuario.Classes
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
        public TipoUsuario TipoUsuarioEnum => (TipoUsuario)TipoUsuario;

        public long PerfilId { get; set; }
        private Perfil _Perfil;
        public virtual Perfil Perfil { get { return _Perfil; } set { _Perfil = value; SetPerfil(value); } }

        public long? InstituicaoId { get; set; }
        private Instituicao _Instituicao;
        public Instituicao Instituicao { get { return _Instituicao; } set { _Instituicao = value; SetInstituicao(value); } }

        private void SetPerfil(Perfil value)
        {
            PerfilId = value is null ? 0 : value.Id;
        }

        private void SetInstituicao(Instituicao value)
        {
            InstituicaoId = value is null ? 0 : value.Id;
        }
    }
}
