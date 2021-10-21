using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShopBridgeEntities
{
    [DataContract]
    public class UnitModel
    {
        [DataMember]
        public int UnitId { get; set; }

        [DataMember]
        public string UnitName { get; set; }
    }
}
