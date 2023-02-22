using Fisica.Website.Extensions;
using Fisica.Website.Features.UsuarioFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.UsuarioFeature
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }
    }
}
