using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.Base.DataTypes.Responses
{
    [DataContract]
    public class PagedResult<T> : PagedResultBase
    {
        [DataMember]
        public List<T> Items { get; set; } = new List<T>();
    }
}
