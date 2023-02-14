using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;
using System.Data;

namespace Fisica.Api.Extensions
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
