using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Data;
using System.Data.Entity.Core;

namespace Fisica.Website.Extensions
{
    public static class ControllerExtensions
    {
        public static long? IdUsuario;
        public static async Task<ActionResult> SendAsync(this ControllerBase controller, IMediator mediator, object request)
        {
            try
            {
                if (controller.Request.Headers.Authorization != StringValues.Empty)
                    IdUsuario = Convert.ToInt64(controller.User.Claims.First(x => x.Type == "idUsuario").Value);
                return controller.Ok(await mediator.Send(request));
            }
            catch (ArgumentNullException ex)
            {
                return controller.BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return controller.NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return controller.StatusCode(403, ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                return controller.Conflict(ex.Message);
            }
        }
    }
}
