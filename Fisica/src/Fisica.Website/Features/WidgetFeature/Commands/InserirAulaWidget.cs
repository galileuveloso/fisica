using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.WidgetFeature.Commands
{
    public class InserirAulaWidgetCommand : IRequest
    {
        public long? AulaId { get; set; }
        public long? WidgetId { get; set; }

        public void Validar()
        {

        }
    }

    public class InserirAulaWidgetHandler : IRequestHandler<InserirAulaWidgetCommand>
    {
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<Widget> _repositoryWidget;
        private readonly IRepository<WidgetAula> _repositoryWidgetAula;

        public InserirAulaWidgetHandler(IRepository<Aula> repositoryAula, IRepository<Widget> repositoryWidget, IRepository<WidgetAula> repositoryWidgetAula)
        {
            _repositoryAula = repositoryAula;
            _repositoryWidget = repositoryWidget;
            _repositoryWidgetAula = repositoryWidgetAula;
        }

        public async Task<Unit> Handle(InserirAulaWidgetCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirAulaWidgetCommand>());

            request.Validar();

            Widget widget = await _repositoryWidget.GetSingleAsync(x => x.Id == request.WidgetId!.Value, cancellationToken);

            if (widget is null)
                throw new ObjectNotFoundException("Widget não encontrado.");

            Aula aula = await _repositoryAula.GetSingleAsync(x => x.Id == request.AulaId!.Value, cancellationToken);

            if (aula is null)
                throw new ObjectNotFoundException("Aula não encontrada.");

            if (!await _repositoryWidgetAula.ExistsAsync(x => x.AulaId == aula.Id && x.WidgetId == widget.Id, cancellationToken))
            {
                WidgetAula wid = new()
                {
                    Aula = aula,
                    Widget = widget
                };

                await _repositoryWidgetAula.AddAsync(wid, cancellationToken);
                await _repositoryWidgetAula.SaveChangesAsync(cancellationToken);
            }

            return await Unit.Task;
        }
    }
}
