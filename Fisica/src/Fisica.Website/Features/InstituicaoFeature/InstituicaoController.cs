using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Commands;
using Fisica.Website.Features.InstituicaoFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.InstituicaoFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InstituicaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstituicaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("buscar-instituicoes")]
        public async Task<ActionResult> Get()
        {
            return await this.SendAsync(_mediator, new SelecionarInstituicoesQuery());
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirInstituicaoCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> Put(AtualizarInstituicaoCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return await this.SendAsync(_mediator, new DeletarInstituicaoCommand() { InstituicaoId = id });
        }
    }
}
