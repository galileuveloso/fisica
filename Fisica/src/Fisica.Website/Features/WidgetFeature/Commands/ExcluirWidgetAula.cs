using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.WidgetFeature.Commands
{
    public class ExcluirWidgetAulaCommand : IRequest
    {
        public long? WidgetAulaId { get; set; }

        public void Validar()
        {

        }
    }

    public class ExcluirWidgetAulaHandler : IRequestHandler<ExcluirWidgetAulaCommand>
    {
        private readonly IRepository<WidgetAula> _repositoryWidgetAula;

        public ExcluirWidgetAulaHandler(IRepository<WidgetAula> repositoryWidgetAula)
        {
            _repositoryWidgetAula = repositoryWidgetAula;
        }

        public async Task<Unit> Handle(ExcluirWidgetAulaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<ExcluirWidgetAulaCommand>());

            request.Validar();

            WidgetAula widgetAula = await _repositoryWidgetAula.GetSingleAsync(x => x.Id == request.WidgetAulaId!.Value, cancellationToken);

            if (widgetAula is null)
                throw new ObjectNotFoundException("WidgetAula não encontrado.");

            await _repositoryWidgetAula.RemoveAsync(widgetAula);
            await _repositoryWidgetAula.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
