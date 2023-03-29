using Fisica.Website.Extensions;
using Fisica.Website.Features.SegueFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.SegueFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SegueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SegueController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("seguir")]
        public async Task<ActionResult> Post(SeguirProfessorCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("deixar-de-seguir/{professorId}")]
        public async Task<ActionResult> Delete(long? professorId)
        {
            return await this.SendAsync(_mediator, new DeixarDeSeguirCommand() { ProfessorId = professorId });
        }
    }
}
