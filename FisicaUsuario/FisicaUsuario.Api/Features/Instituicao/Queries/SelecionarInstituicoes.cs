using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Classes;
using FisicaUsuario.Interfaces;
using MediatR;

namespace FisicaUsuario.Api.Features.InstituicaoFeature.Queries
{
    public class SelecionarInstituicoesQuery : IRequest<IEnumerable<Instituicao>>
    {
    }

    public class SelecionarInstituicoes : IRequestHandler<SelecionarInstituicoesQuery, IEnumerable<Instituicao>>
    {
        private readonly IRepository<Instituicao> _repository;

        public SelecionarInstituicoes(IRepository<Instituicao> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Instituicao>> Handle(SelecionarInstituicoesQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarInstituicoesQuery>());

            return await _repository.GetAsync();
        }
    }
}
