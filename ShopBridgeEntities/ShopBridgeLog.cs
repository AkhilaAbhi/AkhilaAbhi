using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShopBridgeEntities
{
    [DataContract]
    public class ShopBridgeLog
    {
        [DataMember]
        public int LogId { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string MethodName { get; set; }

        [DataMember]
        public string DeviceId { get; set; }

        [DataMember]
        public string LogData { get; set; }

        [DataMember]
        public bool LogType { get; set; }
    }
}
