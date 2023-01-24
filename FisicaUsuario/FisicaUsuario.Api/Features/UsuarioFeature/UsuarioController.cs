using FisicaUsuario.Api.Extensions;
using FisicaUsuario.Api.Features.UsuarioFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;

namespace FisicaUsuario.Api.Features.UsuarioFeature
{
    [Route("usuario")]
    [ApiController]
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
