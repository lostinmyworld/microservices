using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;

namespace Api.Web.DataAccess.Extensions
{
    internal static class SerializationExtensions
    {
        private static readonly JsonSerializer _serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static void WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
        {
            response.ContentType = contentType ?? "application/json";

            using var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8);
            using var jsonWriter = new JsonTextWriter(writer)
            {
                CloseOutput = false,
                AutoCompleteOnClose = false
            };

            _serializer.Serialize(jsonWriter, obj);
        }
    }
}
