namespace Api.Base.DataTypes
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
