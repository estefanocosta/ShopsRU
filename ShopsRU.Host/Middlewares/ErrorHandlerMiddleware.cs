using ShopsRU.Application.Contract.Request.Log;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Host.Models;
using System.Net;
using System.Net.Mime;

namespace ShopsRU.Host.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _nex;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _nex = next;
        }
        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await _nex(httpContext);
            }
            catch (Exception exception)
            {

                await ExceptionHandleAsync(httpContext, exception, logService);
            }
        }
        private Task ExceptionHandleAsync(HttpContext context, Exception exception, ILogService logService)
        {
            var result = System.Text.Json.JsonSerializer.Serialize(new ExceptionResponseModel() { Message = exception.Message, StatusCode = (int)HttpStatusCode.InternalServerError });
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var createLogRequest = new CreateLogRequest()
            {
                Message = exception.Message,
                Controller = context.Request.RouteValues["controller"].ToString(),
                Method = context.Request.Method,
                PostDate = DateTime.Now,
                Action = context.Request.RouteValues["action"].ToString(),
                Trace = exception.StackTrace,
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                UserID = 5
            };
            var task = logService.CreateAsync(createLogRequest);
            task.Wait();
            return context.Response.WriteAsync(result);
        }
    }
}
