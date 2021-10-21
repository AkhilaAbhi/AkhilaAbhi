using ShopBridgeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeDAL;

namespace ShopBridgeBAL
{
    public static class BAL
    {
        public static ShopBridgeResponseModel SaveItem(ItemModel objRequest)
        {
            return DAL.SaveItem(objRequest);
        }

        public static ShopBridgeResponseModel DeleteItem(ItemModel objRequest)
        {
            return DAL.DeleteItem(objRequest);
        }

        public static ItemsListModel GetItems(ItemModel objRequest)
        {
            return DAL.GetItems(objRequest);
        }

        public static ItemsListModel SearchItems(SearchRequestModel objRequest)
        {
            return DAL.SearchItems(objRequest);
        }

        #region DROPFILL

        public static DropFillModel GetDropData()
        {
            DropFillModel objResponse = new DropFillModel();
            List<CategoryModel> categoryList = new List<CategoryModel>();
            List<UnitModel> Unitlist = new List<UnitModel>();
            try
            {
                categoryList = DAL.GetDropCategory();
                Unitlist = DAL.GetDropUnit();
            }
            catch (Exception ex)
            {
                objResponse.IsValid = false;
                objResponse.ResponseMessage = ex.Message;
            }


            objResponse.CategoryList = categoryList;
            objResponse.UnitList = Unitlist;

            return objResponse;

        }

        #endregion

        #region LOGDATA
        public static bool LogData(ShopBridgeLog objLog)
        {
            return DAL.LogData(objLog);
        }
        #endregion
    }
}
