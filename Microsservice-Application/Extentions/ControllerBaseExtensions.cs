using Microsoft.AspNetCore.Mvc;
using Microsservice_Domain.Models;
using System.Security.Claims;

namespace Microsservice_Application.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult HandleStatusCode(this ControllerBase controller, ResponseBaseModel model)
        {
            return model.Codigo switch
            {
                200 => controller.Ok(model),
                
                204 => controller.NoContent(),

                400 => controller.BadRequest(model), 

                401 => controller.Unauthorized(),
                
                403 => controller.Forbid(),
                
                404 => controller.NotFound(model),
                
                409 => controller.Conflict(model), 

                _ => controller.BadRequest(model),
            };
        }
    }
}