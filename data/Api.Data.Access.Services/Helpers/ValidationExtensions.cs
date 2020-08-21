using Api.Base.Web.Exceptions;
using Api.Data.Access.DataTypes.Requests;

namespace Api.Data.Access.Services.Helpers
{
    internal static class ValidationExtensions
    {
        internal static void Validate(this NameRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                throw new RequestParamNullException($"{nameof(NameRequest)} request and/or parameters NULL.");
            }
        }
    }
}
