using Fisica.Website.Extensions;
using Fisica.Website.Features.ReplicaFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.ReplicaFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReplicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReplicaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirReplicaCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{replicaId}")]
        public async Task<ActionResult> Delete(long? replicaId)
        {
            return await this.SendAsync(_mediator, new ExcluirReplicaCommand() { ReplicaId = replicaId });
        }
    }
}
