﻿using Fisica.Website.Extensions;
using Fisica.Website.Features.AulaFeature.Commands;
using Fisica.Website.Features.ComentarioAulaFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.ComentarioAulaFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ComentarioAulaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComentarioAulaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirComentarioAulaCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{comentarioAulaId}")]
        public async Task<ActionResult> Delete(long? comentarioAulaId)
        {
            return await this.SendAsync(_mediator, new ExcluirComentarioAulaCommand() { ComentarioAulaId = comentarioAulaId });
        }
    }
}
