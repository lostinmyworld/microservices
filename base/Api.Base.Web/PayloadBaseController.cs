using Api.Base.DataTypes.Responses;
using Api.Base.Web.Exceptions;
using Api.Base.Web.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadBaseController : ControllerBase
    {
        #region Retrieve payloads
        protected IActionResult RetrievePayload<T>(Response<PagedResult<T>> response)
            where T : class
        {
            return Ok(response);
        }

        protected IActionResult RetrievePayload<T>(Response<T> response)
            where T : class
        {
            return Ok(response);
        }

        protected IActionResult RetrievePayload<T>(PagedResult<T> response)
            where T : class
        {
            return Ok(ToResponseObject(response));
        }

        protected IActionResult RetrievePayload<T>(T response)
            where T : class
        {
            return Ok(ToResponseObject(response));
        }

        private Response<T> ToResponseObject<T>(T payload)
        {
            return new Response<T>
            {
                Payload = payload,
                ResponseCode = RetrieveCode(payload)
            };
        }

        private ResponseCode RetrieveCode<T>(T payload)
        {
            return payload.Equals(default(T)) ? ResponseCode.Invalid : ResponseCode.Valid;
        }
        #endregion

        #region Error Responses
        protected IActionResult InvalidAuthenticationCredentials()
        {
            var exception = new InvalidAuthenticationCredentialsException();

            return ToActionResult(exception);
        }

        protected IActionResult RequestParametersNull()
        {
            var exception = new RequestParamNullException();

            return ToActionResult(exception);
        }

        private IActionResult ToActionResult(BaseException exception)
        {
            var status = (int)exception.StatusCode;
            var problemDetails = new ProblemDetails
            {
                Title = exception.Title,
                Type = exception.ErrorCode.GetErrorType(),
                Detail = exception.ExposedDetails,
                Status = status
            };
            var response = new Response<string>
            {
                ResponseCode = ResponseCode.Invalid,
                ProblemDetails = problemDetails
            };

            return StatusCode(status, response);
        }
        #endregion
    }
}
