using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeEntities
{
    public class ServiceResultModel<T>
    {
        public ServiceResultModel()
        {
            Errors = new string[] { };

        }

        public T Data { get; set; }
        public string[] Errors { get; set; }
        public HttpStatusCode Response { get; set; }
    }

    public class StaticServiceResultModel
    {
        public StaticServiceResultModel()
        {
            Errors = new string[] { };

        }

        public string Data { get; set; }
        public string[] Errors { get; set; }
        public HttpStatusCode Response { get; set; }
    }
}
