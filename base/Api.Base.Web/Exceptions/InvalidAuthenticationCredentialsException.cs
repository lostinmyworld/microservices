using System;
using System.Net;

namespace Api.Base.Web.Exceptions
{
    public class InvalidAuthenticationCredentialsException : BaseException
    {
        private const HttpStatusCode STATUS = HttpStatusCode.BadRequest;
        private const string TITLE = "Could not authenticate user";
        private const string DETAILS = "Authentication credentials are incorrect. Try again with valid credentials.";
        private const ErrorCodeEnum ERROR_CODE = ErrorCodeEnum.InvalidAuthenticationCredentials;

        public InvalidAuthenticationCredentialsException()
            : base(STATUS, TITLE, DETAILS, ERROR_CODE) { }
        public InvalidAuthenticationCredentialsException(string message)
            : base(STATUS, TITLE, DETAILS, ERROR_CODE, message) { }
        public InvalidAuthenticationCredentialsException(Exception inner)
            : base(STATUS, TITLE, DETAILS, ERROR_CODE, inner) { }
    }
}
