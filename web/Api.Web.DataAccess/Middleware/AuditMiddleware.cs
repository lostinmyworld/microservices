using Api.Base.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.DataAccess.Middleware
{
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new UnexpectedErrorException($"{nameof(AuditMiddleware)} {nameof(RequestDelegate)} is NULL.");
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new UnexpectedErrorException($"{nameof(AuditMiddleware)} {nameof(HttpContext)} is NULL.");
            }
            LogContext.PushProperty("UserName", context.User.Identity.Name);

            var requestBody = await LogRequest(context).ConfigureAwait(false);

            using var responseBodyMemoryStream = new MemoryStream();
            var originalResponseBodyReference = await LogResponse(context, responseBodyMemoryStream, requestBody).ConfigureAwait(false);

            await responseBodyMemoryStream.CopyToAsync(originalResponseBodyReference).ConfigureAwait(false);
        }

        private async Task<string> LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            var body = context.Request.Body;
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];

            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            var requestBody = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            context.Request.Body = body;

            Log.ForContext("RequestHeaders", context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                destructureObjects: true)
                .ForContext("RequestBody", requestBody)
                .Debug("Request {RequestMethod} {RequestPath} information", context.Request.Method, context.Request.Path);

            return requestBody;
        }

        private async Task<Stream> LogResponse(HttpContext context, MemoryStream responseBodyMemoryStream, string requestBody)
        {
            var originalResponseBodyReference = context.Response.Body;
            context.Response.Body = responseBodyMemoryStream;

            await _next(context).ConfigureAwait(false);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync().ConfigureAwait(false);
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            Log.ForContext("RequestBody", requestBody)
                .ForContext("ResponseBody", responseBody)
                .Debug("Response {RequestMethod} {RequestPath} {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);

            return originalResponseBodyReference;
        }
    }
}
