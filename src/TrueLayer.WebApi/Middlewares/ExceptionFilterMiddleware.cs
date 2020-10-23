using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using TrueLayer.WebApi.Exceptions;

namespace TrueLayer.WebApi
{
    public class ExceptionFilterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionFilterMiddleware> _logger;

        public ExceptionFilterMiddleware(RequestDelegate next, ILogger<ExceptionFilterMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            switch (ex)
            {
                case APIErrorException apiError:
                    code = apiError.ErrorCode;
                    _logger.LogError(ex, "API error exception");
                    break;
                case EmptyListException emptyListException:
                    _logger.LogError(ex, "Trying to access an empty list");
                    break;
                default:
                    _logger.LogError(ex, "Generic exception");
                    break;
            }

            context.Response.StatusCode = (int)code;
            
            return context.Response.WriteAsync(code.ToString());
        }
    }
}
