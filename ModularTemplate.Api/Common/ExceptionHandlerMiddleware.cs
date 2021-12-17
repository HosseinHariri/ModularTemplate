using ModularTemplate.Framework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModularTemplate.Presentation.Server.Common
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly IWebHostEnvironment environment;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate,
                                          IWebHostEnvironment environment)
        {
            this.requestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception exception)
            {
                //await ravenClient.CaptureAsync(new SentryEvent(exception));

                await HandleExceptionHelperAsync(exception, context);
            }
        }
        async Task HandleExceptionHelperAsync(Exception exception,
                                              HttpContext context)
        {
            if (context.Response.HasStarted)
            {
                throw new InvalidOperationException(
                   "The response has already started, the http status code middleware will not be executed.");
            }
            else if (exception is BadRequestException)
            {
                await CreateResponse(context, exception.Message, 200);
            }
            else if (environment.IsDevelopment() &&
                exception.InnerException != null &&
                exception.InnerException.Message.StartsWith("Cannot insert duplicate key row in object"))
            {
                await CreateResponse(context, exception.InnerException.Message, 200);
            }
            else if (environment.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["Exception"] = exception.Message,
                    ["StackTrace"] = exception.StackTrace,
                };

                if (exception.InnerException != null)
                {
                    dic.Add("InnerException.Exception", exception.InnerException.Message);
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                }

                var message = JsonConvert.SerializeObject(dic);

                await CreateResponse(context, message, 500);
            }
            else
            {
                var message = "There is a problem in server.";

                await CreateResponse(context, message, 500);
            }
        }

        private static async Task CreateResponse(HttpContext context, string message, int code)
        {
            var result = new ApiResponse
            {
                message = JsonConvert.SerializeObject(message),
                isSuccess = false
            };

            var jsonResponse = JsonConvert.SerializeObject(result);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}