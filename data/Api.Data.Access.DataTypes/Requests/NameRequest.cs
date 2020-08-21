using System.Runtime.Serialization;

namespace Api.Data.Access.DataTypes.Requests
{
    [DataContract]
    public class NameRequest
    {
        [DataMember]
        public string Name { get; set; }
    }
}
