using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeEntities;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ShopBridgeServiceProvider
{

    public static class ShopBridgeProcessRequest
    {
        public static ServiceResultModel<T> Get<T>(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = int.MaxValue;
            //request.Accept = "application/json";
            request.Accept = "application/octet-stream";


            request.Headers.Add("Accept-Charset", "UTF-8");
            request.Headers.Add("Authorization", "Basic R0FEJiFAIw==");
            try
            {
                var response = request.GetResponse();
                return ProcessServiceResult<T>(response);
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                var statusCode = (ex.Response as HttpWebResponse).StatusCode;

                if (statusCode == HttpStatusCode.Ambiguous)
                {
                    return ProcessServiceResult<T>(errorResponse);
                }
                else
                {
                    using (var responseStream = errorResponse.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        var errorText = reader.ReadToEnd();
                        // log errorText
                    }
                    return new ServiceResultModel<T>
                    {
                        Data = default(T),
                        Response = statusCode
                    };
                }
            }
        }

        private static ServiceResultModel<T> ProcessServiceResult<T>(WebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream, true);
                var str = reader.ReadToEnd();
                var serializer = new JavaScriptSerializer();// { MaxJsonLength = Int32.MaxValue, RecursionLimit = 5000 };
                return new ServiceResultModel<T>
                {
                    Data = JsonConvert.DeserializeObject<T>(str),
                    Response = ((HttpWebResponse)response).StatusCode
                };
            }
        }

        // POST a JSON string
        public static ServiceResultModel<T> Post<T>(string url, string jsonContent)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = Int32.MaxValue;
            request.Method = "POST";
            request.KeepAlive = false;
            //request.ProtocolVersion = HttpVersion.Version10;
            //request.ServicePoint.ConnectionLimit = 24;
            var encoding = new System.Text.UTF8Encoding();
            var byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    return ProcessServiceResult<T>(response);
                }
            }
            catch (WebException ex)
            {
                {
                    var errorResponse = ex.Response;
                    var statusCode = (ex.Response as HttpWebResponse).StatusCode;

                    if (statusCode == HttpStatusCode.Ambiguous)
                    {
                        return ProcessServiceResult<T>(errorResponse);
                    }
                    else
                    {
                        using (var responseStream = errorResponse.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                            var errorText = reader.ReadToEnd();
                            // log errorText
                        }
                        return new ServiceResultModel<T>
                        {
                            Data = default(T),
                            Response = statusCode
                        };
                    }
                }
            }
        }
    }
}
