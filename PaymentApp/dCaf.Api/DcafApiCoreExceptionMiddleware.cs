using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace dCaf.Api
{
    public class DcafApiCoreExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public DcafApiCoreExceptionMiddleware(RequestDelegate _next)
        {
            this.next = _next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var activity = Activity.Current;
            //if activity.TraceId is null set "0"
            var uniqueExceptionId = activity?.TraceId.ToString() ?? "0";

            // if activity.TraceId is "0" or "00000000000000000000000000000000", then use guid as the unique string
            if (int.TryParse(uniqueExceptionId, out int traceId) && traceId == 0)
            {
                uniqueExceptionId = Guid.NewGuid().ToString();
            }

            LogException(context, exception, uniqueExceptionId);
            await SendUserFriendlyResponse(context, exception, uniqueExceptionId);
        }

        private void LogException(HttpContext context, Exception ex, string uniqueExceptionId)
        {
            var logger = context.RequestServices.GetService<ILogger<DcafApiCoreExceptionMiddleware>>();
            logger.LogError(ex, "Unhandled exception Id: {uniqueExceptionId}", uniqueExceptionId);
        }

        private async Task SendUserFriendlyResponse(HttpContext context, Exception exception, string uniqueExceptionId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var apiError = new ApiError
            {
                Message = "Something went wrong, please try again after some time or reach out to helpdesk with Error Reference Number: " + uniqueExceptionId,
                ExceptionId = uniqueExceptionId
            };

            if (CanShowException(context))
            {
                apiError.Exception = exception;
            }
            
            var serializedObject = JsonConvert.SerializeObject(apiError, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            await context.Response.WriteAsync(serializedObject);
        }

        private bool CanShowException(HttpContext context)
        {
            var env = context.RequestServices.GetService<IWebHostEnvironment>();
            return env.IsDevelopment() || env.IsStaging();
        }
    }
}
