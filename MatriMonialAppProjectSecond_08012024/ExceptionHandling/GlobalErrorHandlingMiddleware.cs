using MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions.KeyNotFoundException;
using NotImplementedException = MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions.NotImplementedException;
using UnauthorizedAccessException = MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions.UnauthorizedAccessException;

namespace MatriMonialAppProjectSecond_08012024.ExceptionHandling
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate)
        {

            this. _requestDelegate = requestDelegate;

        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = String.Empty;
            string message;
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            var exceptionResult = JsonSerializer.Serialize(new
            {
                error = message,
                stackTrace
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
