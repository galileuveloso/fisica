using Fisica.Website.Extensions;
using Fisica.Website.Features.WidgetFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.WidgetFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WidgetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WidgetController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir-aula")]
        public async Task<ActionResult> Post(InserirAulaWidgetCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir-aula/{widgetAulaId}")]
        public async Task<ActionResult> Delete(long? widgetAulaId)
        {
            return await this.SendAsync(_mediator, new ExcluirWidgetAulaCommand() { WidgetAulaId = widgetAulaId });
        }
    }
}
