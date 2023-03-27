using Fisica.Website.Extensions;
using Fisica.Website.Features.CidadeFeature.Queries;
using Fisica.Website.Features.UsuarioFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.CidadeFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CidadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CidadeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("buscar-cidades")]
        public async Task<ActionResult> Get()
        {
            return await this.SendAsync(_mediator, new BuscarCidadesQuery());
        }
    }
}
