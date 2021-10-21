using Newtonsoft.Json;
using ShopBridgeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeServiceProvider
{
    public static class ShopBridgeProvider
    {
        public static ShopBridgeResponseModel SaveItem(ItemModel objRequest)
        {
            string jsonUserModel = JsonConvert.SerializeObject(objRequest, Formatting.Indented);
            var res = ShopBridgeProcessRequest.Post<ShopBridgeResponseModel>("http://localhost:53790/" + "/ItemService.svc/SaveItem", jsonUserModel);

            if (res.Data != null)
                return res.Data;

            return res.Data;
        }

        public static ShopBridgeResponseModel DeleteItem(ItemModel objRequest)
        {
            string jsonUserModel = JsonConvert.SerializeObject(objRequest, Formatting.Indented);
            var res = ShopBridgeProcessRequest.Post<ShopBridgeResponseModel>("http://localhost:53790/" + "/ItemService.svc/DeleteItem", jsonUserModel);

            if (res.Data != null)
                return res.Data;

            return res.Data;
        }

        public static ItemsListModel GetItems(ItemModel objRequest)
        {
            string jsonUserModel = JsonConvert.SerializeObject(objRequest, Formatting.Indented);
            var res = ShopBridgeProcessRequest.Post<ItemsListModel>("http://localhost:53790/" + "/ItemService.svc/GetItems", jsonUserModel);

            if (res.Data != null)
                return res.Data;

            return res.Data;
        }

        public static ItemsListModel SearchItems(SearchRequestModel objRequest)
        {
            string jsonUserModel = JsonConvert.SerializeObject(objRequest, Formatting.Indented);
            var res = ShopBridgeProcessRequest.Post<ItemsListModel>("http://localhost:53790/" + "/ItemService.svc/SearchItems", jsonUserModel);

            if (res.Data != null)
                return res.Data;

            return res.Data;
        }


        public static DropFillModel GetDropData()
        {
            var res = ShopBridgeProcessRequest.Get<DropFillModel>("http://localhost:53790/" + "/ItemService.svc/GetDropData");

            if (res.Data != null)
                return res.Data;

            return res.Data;
        }
    }
}
