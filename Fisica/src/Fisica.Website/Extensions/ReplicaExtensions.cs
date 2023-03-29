using Fisica.Domains;
using Fisica.Models;
using Fisica.Website.Features.ReplicaFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class ReplicaExtensions
    {
        public static Replica ToDomain(this InserirReplicaCommand request)
        {
            return new()
            {
                Descricao = request.Descricao!,
                RespostaTopicoId = request.RespostaTopicoId!.Value,
                DataCadastro = DateTime.Now
            };
        }

        public static ReplicaModel ToResponse(this Replica domain)
        {
            return new()
            {
                Descricao = domain.Descricao!,
                Id = domain.Id,
                RespostaTopicoId = domain.RespostaTopicoId,
                NomeUsuario = domain.Usuario.Nome
            };
        }
    }
}
