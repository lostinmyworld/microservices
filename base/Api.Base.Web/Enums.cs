namespace Api.Base.Web
{
    public enum ResponseCode
    {
        Ambiguous,
        Valid,
        Invalid
    }

    public enum ErrorCodeEnum
    {
        Unexpected,
        RequestParameterNull,
        InvalidAuthenticationCredentials,
        UnauthorizedUser,
        MissingConfiguration,
        EmptyResponse,
        InsertAlreadyExists,
        BadCoreRequest
    }
}
