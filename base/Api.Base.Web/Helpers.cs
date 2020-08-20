namespace Api.Base.Web
{
    public static class Helpers
    {

        public static string GetErrorType(this ErrorCodeEnum errorCodeEnum)
        {
            return $"{(int)errorCodeEnum}";
        }
    }
}
