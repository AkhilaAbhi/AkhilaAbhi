using ShopBridgeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using ShopBridgeBAL;


namespace ShopBridgeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ItemService.svc or ItemService.svc.cs at the Solution Explorer and start debugging.
    public class ItemService : IItemService
    {
        public void DoWork()
        {
        }

        public ShopBridgeResponseModel SaveItem(ItemModel objRequest)
        {
            //LOG REQUEST CLASS
            ShopBridgeLog objLog = new ShopBridgeLog();
            objLog.ServiceName = "ItemService";
            objLog.MethodName = "SaveItem";
            objLog.DeviceId = "WEB";
            var json = new JavaScriptSerializer().Serialize(objRequest);
            objLog.LogData = json;
            objLog.LogType = true; //true for request Log and false for response log
            BAL.LogData(objLog);

            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();

            try
            {
                objResponse = BAL.SaveItem(objRequest);
            }
            catch (Exception ex)
            {
                //LOG ERROR
                objResponse.IsValid = false;
                objResponse.ResponseMessage = "Error in Saving the Item" + "|Exception : " + ex.Message;
            }

            //LOG RESPONSE CLASS
            var jsonResponse = new JavaScriptSerializer().Serialize(objResponse);
            objLog.LogData = jsonResponse;
            objLog.LogType = false; //true for request Log and false for response log
            BAL.LogData(objLog);

            return objResponse;
        }


        public ShopBridgeResponseModel DeleteItem(ItemModel objRequest)
        {
            //LOG REQUEST CLASS
            ShopBridgeLog objLog = new ShopBridgeLog();
            objLog.ServiceName = "ItemService";
            objLog.MethodName = "DeleteItem";
            objLog.DeviceId = "WEB";
            var json = new JavaScriptSerializer().Serialize(objRequest);
            objLog.LogData = json;
            objLog.LogType = true; //true for request Log and false for response log
            BAL.LogData(objLog);

            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();

            try
            {
                objResponse = BAL.DeleteItem(objRequest);
            }
            catch (Exception ex)
            {
                //LOG ERROR
                objResponse.IsValid = false;
                objResponse.ResponseMessage = "Error in Deleting the Item" + "|Exception : " + ex.Message;
            }

            //LOG RESPONSE CLASS
            var jsonResponse = new JavaScriptSerializer().Serialize(objResponse);
            objLog.LogData = jsonResponse;
            objLog.LogType = false; //true for request Log and false for response log
            BAL.LogData(objLog);

            return objResponse;
        }

        public ItemsListModel GetItems(ItemModel objRequest)
        {
            //LOG REQUEST CLASS
            ShopBridgeLog objLog = new ShopBridgeLog();
            objLog.ServiceName = "ItemService";
            objLog.MethodName = "GetItems";
            objLog.DeviceId = "WEB";
            var json = new JavaScriptSerializer().Serialize(objRequest);
            objLog.LogData = json;
            objLog.LogType = true; //true for request Log and false for response log
            BAL.LogData(objLog);

            ItemsListModel objResponse = new ItemsListModel();

            try
            {
                objResponse = BAL.GetItems(objRequest);
            }
            catch (Exception ex)
            {
                //LOG ERROR
                objResponse.IsValid = false;
                objResponse.ResponseMessage = "Error infetching Items" + "|Exception : " + ex.Message;
            }

            //LOG RESPONSE CLASS
            var jsonResponse = new JavaScriptSerializer().Serialize(objResponse);
            objLog.LogData = jsonResponse;
            objLog.LogType = false; //true for request Log and false for response log
            BAL.LogData(objLog);

            return objResponse;
        }

        public ItemsListModel SearchItems(SearchRequestModel objRequest)
        {
            //LOG REQUEST CLASS
            ShopBridgeLog objLog = new ShopBridgeLog();
            objLog.ServiceName = "ItemService";
            objLog.MethodName = "SearchItems";
            objLog.DeviceId = "WEB";
            var json = new JavaScriptSerializer().Serialize(objRequest);
            objLog.LogData = json;
            objLog.LogType = true; //true for request Log and false for response log
            BAL.LogData(objLog);

            ItemsListModel objResponse = new ItemsListModel();

            try
            {
                objResponse = BAL.SearchItems(objRequest);
            }
            catch (Exception ex)
            {
                //LOG ERROR
                objResponse.IsValid = false;
                objResponse.ResponseMessage = "Error infetching Items" + "|Exception : " + ex.Message;
            }

            //LOG RESPONSE CLASS
            var jsonResponse = new JavaScriptSerializer().Serialize(objResponse);
            objLog.LogData = jsonResponse;
            objLog.LogType = false; //true for request Log and false for response log
            BAL.LogData(objLog);

            return objResponse;
        }

        public DropFillModel GetDropData()
        {
            //LOG REQUEST CLASS
            ShopBridgeLog objLog = new ShopBridgeLog();
            objLog.ServiceName = "ItemService";
            objLog.MethodName = "GetItems";
            objLog.DeviceId = "WEB";
            var json = "DopFill No data with request";
            objLog.LogData = json;
            objLog.LogType = true; //true for request Log and false for response log
            BAL.LogData(objLog);

            DropFillModel objResponse = new DropFillModel();

            try
            {
                objResponse = BAL.GetDropData();
            }
            catch (Exception ex)
            {
                //LOG ERROR
                objResponse.IsValid = false;
                objResponse.ResponseMessage = "Error in fetching drop down Items" + "|Exception : " + ex.Message;
            }

            //LOG RESPONSE CLASS
            var jsonResponse = new JavaScriptSerializer().Serialize(objResponse);
            objLog.LogData = jsonResponse;
            objLog.LogType = false; //true for request Log and false for response log
            BAL.LogData(objLog);

            return objResponse;
        }

    }
}
