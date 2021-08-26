using Hahn.ApplicatonProcess.July2021.Domain.Exceptions;
using Hahn.ApplicatonProcess.July2021.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Extentions
{
    public class CustomErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public CustomErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, IWebHostEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            string[] message = new[] { ex.Message };

            if (ex is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (ex is ValidationException)
            {
                code = HttpStatusCode.BadRequest;
                var exception = ex as ValidationException;
                message = exception.Errors.SelectMany(x => x.Value).ToArray();
            }

            var error = new ErrorDetails
            {
                StatusCode = (int)code,
                StatusCodeText = code.ToString(),
                Messages = message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsJsonAsync(error);
        }
    }
}
