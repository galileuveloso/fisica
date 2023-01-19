using FisicaUsuario.Api.Features.InstituicaoFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FisicaUsuario.Api.Features.InstituicaoFeature
{
    [ApiController]
    [Route("instituicao")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstituicaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult> Get(SelecionarInstituicoesQuery request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
