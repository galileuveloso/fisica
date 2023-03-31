using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.WidgetFeature.Queries
{
    public class SelecionarWidgetsAulaQuery : IRequest<IEnumerable<WidgetAulaModel>>
    {
    }

    public class SelecionarWidgetsAulaHandler : IRequestHandler<SelecionarWidgetsAulaQuery, IEnumerable<WidgetAulaModel>>
    {
        private readonly IRepository<Widget> _repositoryWidget;

        public SelecionarWidgetsAulaHandler(IRepository<Widget> repositoryWidget)
        {
            _repositoryWidget = repositoryWidget;
        }

        public async Task<IEnumerable<WidgetAulaModel>> Handle(SelecionarWidgetsAulaQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarWidgetsAulaQuery>());

            IEnumerable<Widget> widgets = await _repositoryWidget.GetAsync(x => x.UsuarioId == ControllerExtensions.IdUsuario!.Value, cancellationToken, x => x.Aulas);

            IList<WidgetAulaModel> response = new List<WidgetAulaModel>();

            foreach (Widget widget in widgets)
            {
                WidgetAulaModel wid = new()
                {
                    Id = widget.Id,
                    Descricao = widget.Descricao,
                    UsuarioId = widget.UsuarioId
                };

                foreach (WidgetAula aula in widget.Aulas)
                    wid.Aulas.Add(aula.Aula.ToResponse());

                response.Add(wid);
            }

            return response;
        }
    }
}
