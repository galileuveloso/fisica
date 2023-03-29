using Fisica.Domains;
using Fisica.Models;
using Fisica.Website.Features.RespostaTopicoFeature.Commands;

namespace Fisica.Website.Extensions
{
    public static class RespostaTopicoExtensions
    {
        public static RespostaTopico ToDomain(this InserirRespostaTopicoCommand request)
        {
            return new()
            {
                Descricao = request.Descricao!,
                TopicoForumId = request.TopicoForumId!.Value,
                DataCadastro = DateTime.Now
            };
        }

        public static RespostaTopicoModel ToResponse(this RespostaTopico domain)
        {
            return new()
            {
                Descricao = domain.Descricao!,
                Id = domain.Id,
                TopicoForumId = domain.TopicoForumId,
                NomeUsuario = domain.Usuario.Nome
            };
        }

        public static RespostaTopicoModel ToResponseWithReplicas(this RespostaTopico domain)
        {
            RespostaTopicoModel response = new()
            {
                Descricao = domain.Descricao!,
                Id = domain.Id,
                TopicoForumId = domain.TopicoForumId,
                NomeUsuario = domain.Usuario.Nome,
                Replicas = new List<ReplicaModel>()
            };

            foreach (Replica replica in domain.Replicas)
                response.Replicas.Add(replica.ToResponse());

            return response;
        }
    }
}
