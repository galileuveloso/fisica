using Fisica.Website.Extensions;
using Fisica.Website.Features.NoticiaFeature.Commands;
using Fisica.Website.Features.NoticiaFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.NoticiaFeature
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoticiaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("inserir")]
        public async Task<ActionResult> Post(CadastrarNoticiaCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("buscar-noticias")]
        public async Task<ActionResult> Get()
        {
            return await this.SendAsync(_mediator, new SelecionarNoticiasQuery());
        }

        [HttpGet("ultimas-noticias")]
        public async Task<ActionResult> GetUltimasNoticias()
        {
            return await this.SendAsync(_mediator, new SelecionarNoticiasQuery());
        }
    }
}
