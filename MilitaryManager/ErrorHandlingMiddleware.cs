using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MilitaryManager.Core.Exceptions;
using Newtonsoft.Json;


namespace MilitaryManager
{
    public class ErrorHandlingMiddleware
    {
        #region Data members

        private const string ClientResetMessage = "The client reset the request stream.";
        private const string UpstreamResetMessage = "Request failed with status code 503.";

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates ErrorHandlingMiddleware
        /// </summary>
        /// <param name="next">Delegate contains request</param>
        /// <param name="logger">Instance of ILogger</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        #endregion

        #region Private Methods

        private string FormatRequest(HttpRequest request)
        {
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString}";
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
        {
            _logger.LogError(ex, "Exception name: {{ExceptionName}}, Request: {{request}}", ex.Message, FormatRequest(context.Request));
            var (responseBody, responseContentType) = GerErrorResponse(ex);
            await WriteResponse(context, (int)statusCode, responseContentType, responseBody);
        }

        private static async Task WriteResponse(HttpContext context, int code, string responseContentType,
            string responseBody)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = code;
                context.Response.ContentType = responseContentType;
                await context.Response.WriteAsync(responseBody);
            }
        }

        /// <summary>
        /// Creates response body for Exception
        /// </summary>
        /// <param name="ex">Exception object</param>
        /// <returns>Response body and content type</returns>
        public static (string body, string contentType) GerErrorResponse(Exception ex)
        {
            var responseBody = JsonConvert.SerializeObject(new
            {
                Message = ex.Message
            });
            return (responseBody, "application/json");
        }

        #endregion

        /// <summary>
        /// Execute HTTP request
        /// </summary>
        /// <param name="context">Http Context</param>
        /// <returns>Result of request</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                // Ignore the task cancellation-based exceptions
                if (ex is TaskCanceledException
                 || ex is OperationCanceledException
                 || ex.Message.Contains(ClientResetMessage)
                 || ex.Message.Contains(UpstreamResetMessage))
                    return;

                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }
    }
}
