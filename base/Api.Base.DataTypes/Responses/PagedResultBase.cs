using System.Runtime.Serialization;

namespace Api.Base.DataTypes.Responses
{
    [DataContract]
    public abstract class PagedResultBase
    {
        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int CurrentPageSize { get; set; }
        [DataMember]
        public int TotalPages { get; set; }
        [DataMember]
        public int TotalEntries { get; set; }
    }
}
