using Api.Base.DataTypes;
using System;
using System.Net;

namespace Api.Base.Web.Exceptions
{
    public class RequestParamNullException : BaseException
    {
        private const HttpStatusCode STATUS = HttpStatusCode.BadRequest;
        private const string TITLE = "Wrong request parameter";
        private const string DETAILS = "The given request parameters are empty. The request parameters are mandatory for the requested endpoint.";
        private const ErrorCodeEnum ERROR_CODE = ErrorCodeEnum.RequestParameterNull;

        public RequestParamNullException()
            : base(STATUS, TITLE, DETAILS, ERROR_CODE) { }
        public RequestParamNullException(string message)
            : base(STATUS, TITLE, DETAILS, ERROR_CODE, message) { }
        public RequestParamNullException(Exception inner)
            : base(STATUS, TITLE, DETAILS, ERROR_CODE, inner) { }
    }
}
