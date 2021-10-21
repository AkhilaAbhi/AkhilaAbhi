using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShopBridgeEntities
{
    [DataContract]
    public class ItemsListModel : ShopBridgeResponseModel
    {
        [DataMember]
        public List<ItemModel> ItemsList { get; set; }
    }
}
