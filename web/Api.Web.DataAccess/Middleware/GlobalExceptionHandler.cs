using Api.Base.DataTypes;
using Api.Base.Web.Exceptions;
using Api.Base.Web.Responses;
using Api.Web.DataAccess.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using System;
using System.Reflection;

namespace Api.Web.DataAccess.Middleware
{
    internal static class GlobalExceptionHandler
    {
        private static readonly Guid _responseKey = Guid.NewGuid();

        internal static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            _ = app.UseExceptionHandler(a =>
                  a.Run(async context =>
                  {
                      var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                      var problemDetails = feature.Error.Demystify();

                      context.Response.StatusCode = problemDetails.Status.Value;

                      var response = new Response<string>
                      {
                          ResponseKey = _responseKey,
                          ResponseCode = ResponseCode.Invalid,
                          ProblemDetails = problemDetails
                      };

                      context.Response.WriteJson(response, "application/json");
                  }));
        }

        private static ProblemDetails Demystify(this Exception exception)
        {
            if (exception is BaseException baseException)
            {
                return RetrieveBase(baseException);
            }
            else if (exception is BadHttpRequestException badHttpRequestException)
            {
                RetrieveKestrelCommon(badHttpRequestException);
            }

            return RetrieveUnexpected(exception);
        }

        private static ProblemDetails RetrieveBase(BaseException exception)
        {
            Log.ForContext("Type", "Error").ForContext("Exception", exception, destructureObjects: true)
                .Error(exception, exception.Message + ". {@errorId}" + " exposedDetails " + exception.ExposedDetails, _responseKey);

            return new ProblemDetails
            {
                Title = exception.Title,
                Type = exception.ErrorCode.GetErrorType(),
                Status = (int)exception.StatusCode,
                Detail = exception.ExposedDetails,
                Instance = $"errorId:{_responseKey}"
            };
        }

        private static ProblemDetails RetrieveKestrelCommon(BadHttpRequestException exception)
        {
            Log.ForContext("Type", "Error").ForContext("Exception", exception, destructureObjects: true)
                .Error(exception, exception.Message + ". {@errorId}", _responseKey);

            return new ProblemDetails
            {
                Title = "Invalid request",
                Type = ErrorCodeEnum.BadCoreRequest.GetErrorType(),
                Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                    BindingFlags.NonPublic | BindingFlags.Instance).GetValue(exception),
                Detail = exception.Message,
                Instance = $"errorId:{_responseKey}",
            };
        }

        private static ProblemDetails RetrieveUnexpected(Exception exception)
        {
            Log.ForContext("Type", "Error").ForContext("Exception", exception, destructureObjects: true)
                .Error(exception, exception.Message + ". {@errorId}", _responseKey);

            var unexpectedError = new UnexpectedErrorException(exception);

            return new ProblemDetails
            {
                Title = unexpectedError.Title,
                Type = ErrorCodeEnum.Unexpected.GetErrorType(),
                Status = (int)unexpectedError.StatusCode,
                Detail = unexpectedError.ExposedDetails,
                Instance = $"errorId:{_responseKey}"
            };
        }
    }
}
