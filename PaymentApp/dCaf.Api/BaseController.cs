using dCaf.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace dCaf.Api
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<T> ReturnResult<T>(Response<T> response)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                var problemDetails = CreateValidationProblemDetails(response.Errors);
                return UnprocessableEntity(problemDetails);
            }

            return ReturnResult(response.Result);
        }

        protected ActionResult<T> ReturnResult<T>(T value)
        {
            if (value == null)
                return NotFound();

            return Ok(value);
        }

        protected ValidationProblemDetails CreateValidationProblemDetails(IDictionary<string, string[]> errors)
        {
            return new ValidationProblemDetails(errors)
            {
                Type = "https://httpstatuses.com/422",
                Title = "One or more model validation errors occurred.",
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = "See the errors property for details.",
                Instance = HttpContext?.Request?.Path
            };
        }

        protected ActionResult<T> ReturnCreatedAtRouteResult<T>(Response<T> response, string routeName, object routeValues)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                var problemDetails = CreateValidationProblemDetails(response.Errors);
                return UnprocessableEntity(problemDetails);
            }
            return CreatedAtRoute(routeName, routeValues, response.Result);
        }
    }
}
