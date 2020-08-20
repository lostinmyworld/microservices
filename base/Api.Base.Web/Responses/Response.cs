using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.Serialization;

namespace Api.Base.Web.Responses
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public Guid? ResponseKey { get; set; } = Guid.NewGuid();
        [DataMember]
        public ResponseCode ResponseCode { get; set; }
        [DataMember]
        public T Payload { get; set; }
        [DataMember]
        public ProblemDetails ProblemDetails { get; set; }
    }
}
