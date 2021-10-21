using ShopBridgeEntities;
using ShopBridgeServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ShopBridgeSolutions
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string SaveItem(int ItemId, string ItemName, int CategoryId, int UnitId, float ItemCost, float ItemPrice)
        {
            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();
            ItemModel objRequest = new ItemModel();
            objRequest.ItemId = ItemId;
            objRequest.ItemName = ItemName;
            objRequest.CategoryId = CategoryId;
            objRequest.UnitId = UnitId;
            objRequest.ItemCost = ItemCost;
            objRequest.ItemPrice = ItemPrice;
            objResponse = ShopBridgeProvider.SaveItem(objRequest);

            string result = "received";//objResponse.ResponseMessage;
            return result;
        }
    }
}
