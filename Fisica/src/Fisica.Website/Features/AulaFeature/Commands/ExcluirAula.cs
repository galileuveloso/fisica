using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.AulaFeature.Commands
{
    public class ExcluirAulaCommand : IRequest
    {
        public long? AulaId { get; set; }
        public void Validar()
        {

        }
    }

    public class ExcluirAulaHandler : IRequestHandler<ExcluirAulaCommand>
    {
        private readonly IRepository<Aula> _repositoryAula;

        public ExcluirAulaHandler(IRepository<Aula> repositoryAula)
        {
            _repositoryAula = repositoryAula;
        }

        public async Task<Unit> Handle(ExcluirAulaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirAulaCommand>());

            request.Validar();

            Aula aula = await _repositoryAula.GetSingleAsync(x => x.Id == request.AulaId!.Value, cancellationToken);

            if (aula is null)
                throw new ObjectNotFoundException("Aula não encontrada.");

            if (aula.Id != aula.ProfessorId)
                throw new InvalidOperationException("Você não pode excluir esta aula.");

            await _repositoryAula.RemoveAsync(aula);
            await _repositoryAula.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
