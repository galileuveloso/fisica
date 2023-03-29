using Fisica.Website.Extensions;
using Fisica.Website.Features.AreaFisicaFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.AreaFisicaFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AreaFisicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreaFisicaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("selecionar-areas")]
        public async Task<ActionResult> Get()
        {
            return await this.SendAsync(_mediator, new SelecionarAreasFisicaQuery());
        }
    }
}
