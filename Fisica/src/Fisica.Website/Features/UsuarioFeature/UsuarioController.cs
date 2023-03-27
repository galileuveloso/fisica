using Fisica.Website.Extensions;
using Fisica.Website.Features.UsuarioFeature.Commands;
using Fisica.Website.Features.UsuarioFeature.Commands.Login;
using Fisica.Website.Features.UsuarioFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("autocadastro")]
        public async Task<ActionResult> Inserir(AutoCadastroCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpPost("inserir")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Inserir(InserirUsuarioCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(long id)
        {
            return await this.SendAsync(_mediator, new DeletarUsuarioCommand() { UsuarioId = id });
        }

        [HttpGet("buscar-usuarios")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Get()
        {
            return await this.SendAsync(_mediator, new SelecionarUsuariosQuery());
        }
    }
}
