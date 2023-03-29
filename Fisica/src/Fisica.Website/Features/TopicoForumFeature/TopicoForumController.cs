using Fisica.Website.Extensions;
using Fisica.Website.Features.TopicoForumFeature.Commands;
using Fisica.Website.Features.TopicoForumFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.TopicoForumFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TopicoForumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicoForumController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirTopicoForumCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{topicoForumId}")]
        public async Task<ActionResult> Delete(long? topicoForumId)
        {
            return await this.SendAsync(_mediator, new ExcluirTopicoForumCommand() { TopicoForumId = topicoForumId });
        }

        [HttpGet("buscar-topicos/{forumId}")]
        public async Task<ActionResult> Get(long forumId)
        {
            return await this.SendAsync(_mediator, new SelecionarTopicosForumByForumQuery() { ForumId = forumId });
        }

        [HttpGet("selecionar-topico/{topicoForumId}")]
        public async Task<ActionResult> GetTopicoForum(long topicoForumId)
        {
            return await this.SendAsync(_mediator, new SelecionarTopicoForumByIdQuery() { TopicoForumId = topicoForumId });
        }

    }
}
