using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShopBridgeEntities
{
    [DataContract]
    public class SearchRequestModel
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public int UnitId { get; set; }

        [DataMember]
        public string SearchText { get; set; }

        [DataMember]
        public string SortOrder { get; set; }
    }
}
