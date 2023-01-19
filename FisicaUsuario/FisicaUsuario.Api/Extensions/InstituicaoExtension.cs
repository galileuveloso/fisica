using FisicaUsuario.Api.Features.InstituicaoFeature.Commands;
using FisicaUsuario.Classes;

namespace FisicaUsuario.Api.Extensions
{
    public static class InstituicaoExtension
    {
        public static void Atualizar(this Instituicao instituicao, AtualizarInstituicaoCommand request)
        {
            instituicao.Nome = request.Nome;
            instituicao.Descricao = request.Descricao;
            instituicao.Email = request.Email;
            instituicao.Site = request.Site;
            instituicao.Logradouro = request.Logradouro;
            instituicao.Bairro = request.Bairro;
            instituicao.Numero = request.Numero;
            instituicao.Cidade = request.Cidade;
            instituicao.UF = request.UF;
        }
    }
}
