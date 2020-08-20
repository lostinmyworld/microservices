using Api.Base.DataTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Api.Base.Web.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Title { get; set; }
        public string ExposedDetails { get; set; }
        public ErrorCodeEnum ErrorCode { get; set; }

        protected BaseException(HttpStatusCode statusCode, string title, string details, ErrorCodeEnum errorCode)
            : base(details)
        {
            StatusCode = statusCode;
            Title = title;
            ExposedDetails = details;
            ErrorCode = errorCode;
        }

        protected BaseException(HttpStatusCode statusCode, string title, string details, ErrorCodeEnum errorCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
            Title = title;
            ExposedDetails = details;
            ErrorCode = errorCode;
        }

        protected BaseException(string title, string details, ErrorCodeEnum errorCode, ProblemDetails problemDetails)
            : base(details)
        {
            StatusCode = (HttpStatusCode)problemDetails.Status;
            Title = $"{title} - [Inner problem : {problemDetails?.Status?.ToString()} {problemDetails?.Title}]";
            ExposedDetails = $"{details} - [Inner errorCode: {problemDetails?.Type} - details : {problemDetails?.Detail} - Instance: {problemDetails?.Instance}]";
            ErrorCode = errorCode;
        }

        protected BaseException(HttpStatusCode statusCode, string title, string details, ErrorCodeEnum errorCode, Exception inner)
            : base(details, inner)
        {
            StatusCode = statusCode;
            Title = title;
            ExposedDetails = details;
            ErrorCode = errorCode;
        }
    }
}
