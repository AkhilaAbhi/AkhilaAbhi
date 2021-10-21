using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShopBridgeEntities
{
    [DataContract]
    public class ShopBridgeResponseModel
    {
        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }
    }
}
