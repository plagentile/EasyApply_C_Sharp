using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middelware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> iLogger;
        private readonly IHostEnvironment env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> iLogger, IHostEnvironment env)
        {
            this.env = env;
            this.iLogger = iLogger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context){
            try
            {
                await this.next(context);
            }
            catch(Exception e)
            {
                this.iLogger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;   

                var response  = this.env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, e.Message, e.StackTrace?.ToString()) //development
                    : new ApiException(context.Response.StatusCode, "Internal Server Error.");      //production
            
                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json  = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
        
            }
        }
    }
}