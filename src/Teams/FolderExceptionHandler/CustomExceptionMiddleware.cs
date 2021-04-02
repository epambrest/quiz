using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Teams.FolderExceptionHandler
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

       
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "text/html";
            ErrorDetail errorDetail = new ErrorDetail
            {
                Message = exception.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            await context.Response.WriteAsync(@"<h1>Error.</h1>");
            await context.Response.WriteAsync(@"<h2>An error occurred while processing your request.</h2>");
            await context.Response.WriteAsync("</body><hr></html>\r\n");
            await context.Response.WriteAsync($"<p><strong>Status Code:</strong> {errorDetail.StatusCode} </p>");
            await context.Response.WriteAsync($"<p><strong>Description:</strong> {errorDetail.Message}</p>");

        }
    }
}
