using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace SportsData.Infrastructure.ErrorHandling
{
    // Ref: https://enterprisecraftsmanship.com/posts/advanced-error-handling-techniques/
    public sealed class Error : ProblemDetails
    {
        public IEnumerable<AppErrorDto> ApplicationErrors { get; set; }

        [JsonConstructor] // Might want to remove this and use a custom JsonConverter in tests.
        internal Error(HttpStatusCode status, string title, string detail = null, IEnumerable<AppErrorDto> applicationErrors = null, string instance = null)
        {
            Type = GetType(status);
            Status = (int)status;
            Title = title;
            Detail = detail;
            ApplicationErrors = applicationErrors;
            Instance = instance;
        }

        private string GetType(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest: return "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                case HttpStatusCode.Forbidden: return "https://tools.ietf.org/html/rfc7231#section-6.5.3";
                case HttpStatusCode.NotFound: return "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                case HttpStatusCode.InternalServerError: return "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                case HttpStatusCode.NotImplemented: return "https://tools.ietf.org/html/rfc7231#section-6.6.2";
                case HttpStatusCode.ServiceUnavailable: return "https://tools.ietf.org/html/rfc7231#section-6.6.4";
                default: return null;
            }
        }
    }

    public class AppErrorDto
    {
        public string Code { get; }
        public string Message { get; }
        public object Details { get; }

        public AppErrorDto(string message, string code = null, object details = null)
        {
            Message = message;
            Code = code;
            Details = details;
        }
    }
}
