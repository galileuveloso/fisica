using Fisica.Api.Features.InstituicaoFeature.Commands;
using Fisica.Api.Features.InstituicaoFeature.Queries;
using Fisica.Classes;

namespace Fisica.Api.Extensions
{
    public static class InstituicaoExtension
    {
        public static void Atualizar(this Instituicao instituicao, AtualizarInstituicaoCommand request)
        {
            instituicao.Nome = request.Nome!;
            instituicao.Descricao = request.Descricao!;
            instituicao.Email = request.Email!;
            instituicao.Site = request.Site!;
            instituicao.Endereco.CidadeId = request.CidadeId!.Value;
            instituicao.Endereco.Bairro = request.Bairro!;
            instituicao.Endereco.Logradouro = request.Logradouro!;
            instituicao.Endereco.Numero = request.Numero!.Value;
        }

        public static Instituicao ToDomain(this InserirInstituicaoCommand request)
        {
            return new()
            {
                Nome = request.Nome!,
                Descricao = request.Descricao!,
                Email = request.Email!,
                Site = request.Site!,
                Endereco = new()
                {
                    Bairro = request.Endereco.Bairro!,
                    Logradouro = request.Endereco.Logradouro!,
                    Numero = request.Endereco.Numero,
                    CidadeId = request.Endereco.CidadeId
                }
            };
        }

        public static InstituicaoResponse ToResponse(this Instituicao domain)
        {
            return new()
            {
                Nome = domain.Nome,
                Descricao = domain.Descricao,
                Email = domain.Email,
                Site = domain.Site,
                Logradouro = domain.Endereco.Logradouro,
                Bairro = domain.Endereco.Bairro,
                Cidade = domain.Endereco.Cidade?.Nome,
                Numero = domain.Endereco.Numero,
                UF = domain.Endereco.Cidade?.UF
            };
        }

        public static IEnumerable<InstituicaoResponse> ToResponse(this IEnumerable<Instituicao> instituicoes)
        {
            IList<InstituicaoResponse> resultado = new List<InstituicaoResponse>();

            foreach (Instituicao instituicao in instituicoes)
                resultado.Add(instituicao.ToResponse());

            return resultado;
        }
    }
}
