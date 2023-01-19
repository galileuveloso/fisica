using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Classes;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Data.Entity.Core;

namespace FisicaUsuario.Api.Features.InstituicaoFeature.Commands
{
    public class DeletarInstituicaoCommand : IRequest
    {
        public long? Id { get; set; }

        public void Validate()
        {
            if (Id == null) throw new ArgumentNullException("Nenhuma Instituição informada.");
        }
    }

    public class DeletarInstituicaoHandler : IRequestHandler<DeletarInstituicaoCommand>
    {
        private readonly IRepository<Instituicao> _repository;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public DeletarInstituicaoHandler(IRepository<Instituicao> repository, IRepository<Usuario> repositoryUsuario)
        {
            _repository = repository;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Unit> Handle(DeletarInstituicaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<DeletarInstituicaoCommand>());

            request.Validate();

            Instituicao? instituicao = await _repository.GetSingleAsync(x => x.Id == request.Id);

            if (instituicao == null)
                throw new ObjectNotFoundException(MessageHelper.NotFoundFor<Instituicao>());

            IEnumerable<Usuario> usuarios = await _repositoryUsuario.GetAsync(x => x.Instituicao.Id == instituicao.Id);

            foreach (Usuario usuario in usuarios)
                usuario.Instituicao = null;

            await _repositoryUsuario.UpdateCollectionAsync(usuarios);

            await _repository.RemoveAsync(instituicao);

            return await Unit.Task;
        }
    }
}
