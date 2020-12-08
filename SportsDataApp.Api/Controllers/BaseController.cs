using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using SportsData.Infrastructure;
using SportsData.Infrastructure.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SportsDataApp.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult FromResult<T>(Result<T, Error> result, string identifier = null)
            where T : class
        {
            if (result.IsSuccess)
            {
                return ActionResultFromStatusCode(HttpStatusCode.OK, result.Value, identifier);
            }

            return StatusCode((int)result.Error.Status, result.Error);
        }

        private IActionResult ActionResultFromStatusCode<T>(HttpStatusCode statusCode, T value = null, string identifier = null)
            where T : class
        {
            return statusCode switch
            {
                HttpStatusCode.OK => value != null ? (IActionResult)Ok(value) : Ok(),
                HttpStatusCode.Accepted => Accepted(),
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.BadRequest => BadRequest(),
                _ => throw new ArgumentException("Unsupported response returned", nameof(statusCode))
            };
        }
    }
}
