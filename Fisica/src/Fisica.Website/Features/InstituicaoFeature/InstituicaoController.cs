using Fisica.Website.Extensions;
using Fisica.Website.Features.InstituicaoFeature.Commands;
using Fisica.Website.Features.InstituicaoFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.InstituicaoFeature
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstituicaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("selecionar/{usuarioid}")]
        public async Task<ActionResult> Get(long? usuarioId)
        {
            return await this.SendAsync(_mediator, new SelecionarInstituicoesQuery() { UsuarioId = usuarioId });
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

        [HttpDelete("deletar")]
        public async Task<ActionResult> Delete(DeletarInstituicaoCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }
    }
}
