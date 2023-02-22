using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.CidadeFeature.Queries
{
    public class BuscarCidadesQuery : IRequest<IEnumerable<CidadeResponse>>
    {
    }

    public class CidadeResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string DescricaoFormatada => Nome + " - " + UF;
    }

    public class BuscarCidadesHandle : IRequestHandler<BuscarCidadesQuery, IEnumerable<CidadeResponse>>
    {
        private readonly IRepository<Cidade> _repositoryCidade;

        public BuscarCidadesHandle(IRepository<Cidade> repositoryCidade)
        {
            _repositoryCidade = repositoryCidade;
        }

        public async Task<IEnumerable<CidadeResponse>> Handle(BuscarCidadesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<BuscarCidadesQuery>());

            IEnumerable<Cidade> response = await _repositoryCidade.GetAsync(cancellationToken);

            return ToResponse(response);
        }

        private static IEnumerable<CidadeResponse> ToResponse(IEnumerable<Cidade> response)
        {
            IList<CidadeResponse> result = new List<CidadeResponse>();

            foreach (Cidade cidade in response)
                result.Add(new()
                {
                    Id = cidade.Id,
                    Nome = cidade.Nome,
                    UF = cidade.UF
                });

            return result;
        }
    }
}
