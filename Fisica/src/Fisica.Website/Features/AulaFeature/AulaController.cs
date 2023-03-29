using Fisica.Website.Extensions;
using Fisica.Website.Features.AulaFeature.Commands;
using Fisica.Website.Features.AulaFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.AulaFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AulaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AulaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirAulaCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{aulaId}")]
        public async Task<ActionResult> Delete(long? aulaId)
        {
            return await this.SendAsync(_mediator, new ExcluirAulaCommand() { AulaId = aulaId });
        }

        [HttpGet("selecionar-aulas/{areaFisicaId}")]
        public async Task<ActionResult> Get(long? areaFisicaId)
        {
            return await this.SendAsync(_mediator, new SelecionarAulasByAreaFisicaQuery() { AreaFisicaId = areaFisicaId });
        }

        [HttpGet("selecionar-aula/{aulaId}")]
        public async Task<ActionResult> GetAula(long? aulaId)
        {
            return await this.SendAsync(_mediator, new SelecionarAulaByIdQuery() { AulaId = aulaId });
        }
    }
}
