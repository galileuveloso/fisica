using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FisicaUsuario.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<ActionResult> SendAsync(this ControllerBase controller, IMediator mediator, object request)
        {
            try
            {
                return controller.Ok(await mediator.Send(request));
            }
            catch (ArgumentNullException ex)
            {
                return controller.BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return controller.Forbid(ex.Message);
            }
        }
    }
}
