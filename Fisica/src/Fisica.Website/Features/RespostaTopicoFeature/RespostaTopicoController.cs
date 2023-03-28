using Fisica.Website.Extensions;
using Fisica.Website.Features.RespostaTopicoFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.RespostaTopicoFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RespostaTopicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RespostaTopicoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirRespostaTopicoCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{respostaTopicoId}")]
        public async Task<ActionResult> Delete(long? respostaTopicoId)
        {
            return await this.SendAsync(_mediator, new ExcluirRespostaTopicoCommand() { RespostaTopicoId = respostaTopicoId });
        }
    }
}
