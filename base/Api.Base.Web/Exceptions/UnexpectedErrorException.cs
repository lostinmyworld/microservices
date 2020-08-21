using Api.Base.DataTypes;
using System;
using System.Net;

namespace Api.Base.Web.Exceptions
{
    public class UnexpectedErrorException : BaseException
    {
        private const HttpStatusCode STATUS = HttpStatusCode.InternalServerError;
        private const string TITLE = "Unexpected error";
        private const string DETAILS = "Sorry, an unexpected error has occurred.";
        private const ErrorCodeEnum ERROR_CODE = ErrorCodeEnum.Unexpected;

        public UnexpectedErrorException() : base(STATUS, TITLE, DETAILS, ERROR_CODE) { }
        public UnexpectedErrorException(string message) : base(STATUS, TITLE, DETAILS, ERROR_CODE, message) { }
        public UnexpectedErrorException(Exception inner) : base(STATUS, TITLE, DETAILS, ERROR_CODE, inner) { }
    }
}
