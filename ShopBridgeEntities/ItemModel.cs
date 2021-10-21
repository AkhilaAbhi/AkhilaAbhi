using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace ShopBridgeEntities
{
    [DataContract]
    public class ItemModel
    {
        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int UnitId { get; set; }

        [DataMember]
        public string UnitName { get; set; }

        [DataMember]
        public double ItemCost { get; set; }

        [DataMember]
        public double ItemPrice { get; set; }

        [DataMember]
        public string CreatedDate { get; set; }

        [DataMember]
        public string ModifiedDate { get; set; }
    }
}
