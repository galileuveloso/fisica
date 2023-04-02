using Fisica.Website.Extensions;
using Fisica.Website.Features.FavoritoFeature.Commands;
using Fisica.Website.Features.FavoritoFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisica.Website.Features.FavoritoFeature
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoritoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoritoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult> Post(InserirFavoritoCommand request)
        {
            return await this.SendAsync(_mediator, request);
        }

        [HttpDelete("excluir/{favoritoId}")]
        public async Task<ActionResult> Delete(long favoritoId)
        {
            return await this.SendAsync(_mediator, new ExcluirFavoritoCommand() { FavoritoId = favoritoId });
        }

        //[HttpGet("selecionar-favoritos")]
        //public async Task<ActionResult> GetFavoritos(long favoritoId)
        //{
        //    return await this.SendAsync(_mediator, new SelecionarFavoritosQuery() { FavoritoId = favoritoId });
        //}
    }
}
