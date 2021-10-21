using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShopBridgeEntities;
using System.Data.SqlClient;
using System.Configuration;

namespace ShopBridgeDAL
{
    public static class DAL
    {
        public static ShopBridgeResponseModel SaveItem(ItemModel objRequest)
        {
            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("uspSaveItem", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ItemId", objRequest.ItemId);
                        myCommand.Parameters.AddWithValue("@ItemName", objRequest.ItemName);
                        myCommand.Parameters.AddWithValue("@CategoryId", objRequest.CategoryId);
                        myCommand.Parameters.AddWithValue("@UnitId", objRequest.UnitId);
                        myCommand.Parameters.AddWithValue("@ItemCost", objRequest.ItemCost);
                        myCommand.Parameters.AddWithValue("@ItemPrice", objRequest.ItemPrice);
                        SqlDataReader objReader = myCommand.ExecuteReader();
                        while (objReader.Read())
                        {
                            objResponse.ItemId = Convert.ToInt32(objReader["ID"]);
                        }                        
                        objResponse.IsValid = true;
                        objResponse.ResponseMessage = "Item Added Successfully";
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                objResponse.ItemId = 0;
                objResponse.IsValid = false;
                objResponse.ResponseMessage = ex.Message.ToString();
            }
            
            return objResponse;
        }

        public static ShopBridgeResponseModel DeleteItem(ItemModel objRequest)
        {
            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("uspDeleteItem", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ItemId", objRequest.ItemId);
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.ExecuteNonQuery();

                        objResponse.IsValid = true;
                        objResponse.ResponseMessage = "Success";


                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                objResponse.ItemId = objRequest.ItemId;
                objResponse.IsValid = false;
                objResponse.ResponseMessage = ex.Message.ToString();
            }

            return objResponse;
        }
        
        public static ItemsListModel GetItems(ItemModel objRequest)
        {
            ItemsListModel objResponse = new ItemsListModel();
            List<ItemModel> objItemsList = new List<ItemModel>();

            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("uspGetItem", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ItemId", objRequest.ItemId);
                        SqlDataReader objReader = myCommand.ExecuteReader();
                        while (objReader.Read())
                        {
                            ItemModel objItem = new ItemModel();
                            objItem.ItemId = Convert.ToInt32(objReader["itemId"]);
                            objItem.ItemName = objReader["itemName"].ToString();
                            objItem.CategoryId = Convert.ToInt32(objReader["categoryId"]);
                            objItem.CategoryName = objReader["categoryName"].ToString();
                            objItem.UnitId = Convert.ToInt32(objReader["unitId"]);
                            objItem.UnitName = objReader["unitName"].ToString();
                            objItem.ItemCost = float.Parse(objReader["itemCost"].ToString());
                            objItem.ItemPrice = float.Parse(objReader["itemPrice"].ToString());
                            objItem.CreatedDate = Convert.ToDateTime(objReader["itemCreatedDate"]).ToShortDateString();
                            objItem.ModifiedDate = Convert.ToDateTime(objReader["itemModifiedDate"]).ToShortDateString();
                            objItemsList.Add(objItem);
                        }
                    }
                }

                objResponse.IsValid = true;
                objResponse.ResponseMessage = "Success";
                objResponse.ItemsList = objItemsList;
            }
            catch (Exception ex)
            {
                objResponse.ItemId = 0;
                objResponse.IsValid = false;
                objResponse.ResponseMessage = ex.Message.ToString();
                objResponse.ItemsList = new List<ItemModel>();
            }
            return objResponse;
        }


        public static ItemsListModel SearchItems(SearchRequestModel objRequest)
        {
            ItemsListModel objResponse = new ItemsListModel();
            List<ItemModel> objItemsList = new List<ItemModel>();

            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("uspSearchItem", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@CategoryId", objRequest.CategoryId);
                        myCommand.Parameters.AddWithValue("@UnitId", objRequest.UnitId);
                        myCommand.Parameters.AddWithValue("@ItemName", objRequest.SearchText);
                        myCommand.Parameters.AddWithValue("@SortOrder", objRequest.SortOrder);
                        SqlDataReader objReader = myCommand.ExecuteReader();
                        while (objReader.Read())
                        {
                            ItemModel objItem = new ItemModel();
                            objItem.ItemId = Convert.ToInt32(objReader["itemId"]);
                            objItem.ItemName = objReader["itemName"].ToString();
                            objItem.CategoryId = Convert.ToInt32(objReader["categoryId"]);
                            objItem.CategoryName = objReader["categoryName"].ToString();
                            objItem.UnitId = Convert.ToInt32(objReader["unitId"]);
                            objItem.UnitName = objReader["unitName"].ToString();
                            objItem.ItemCost = float.Parse(objReader["itemCost"].ToString());
                            objItem.ItemPrice = float.Parse(objReader["itemPrice"].ToString());
                            objItem.CreatedDate = Convert.ToDateTime(objReader["itemCreatedDate"]).ToShortDateString();
                            objItem.ModifiedDate = Convert.ToDateTime(objReader["itemModifiedDate"]).ToShortDateString();
                            objItemsList.Add(objItem);
                        }
                    }
                }

                objResponse.IsValid = true;
                objResponse.ResponseMessage = "Success";
                objResponse.ItemsList = objItemsList;
            }
            catch (Exception ex)
            {
                objResponse.ItemId = 0;
                objResponse.IsValid = false;
                objResponse.ResponseMessage = ex.Message.ToString();
                objResponse.ItemsList = new List<ItemModel>();
            }
            return objResponse;
        }


        #region DROPFILL

        public static List<CategoryModel> GetDropCategory()
        {
           
            List<CategoryModel> objCategoryList = new List<CategoryModel>();
            

            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("SELECT * FROM tbl_CategoryMaster ORDER BY categoryId DESC", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.Text;
                        SqlDataReader objReader = myCommand.ExecuteReader();
                        while (objReader.Read())
                        {
                            CategoryModel objItem = new CategoryModel();
                            objItem.CategoryId = Convert.ToInt32(objReader["categoryId"]);
                            objItem.CategoryName = objReader["categoryName"].ToString();

                            objCategoryList.Add(objItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objCategoryList = new List<CategoryModel>();
            }
            return objCategoryList;
        }

        public static List<UnitModel> GetDropUnit()
        {

            List<UnitModel> objUnitList = new List<UnitModel>();


            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("SELECT * FROM tbl_UnitMaster ORDER BY unitId DESC", myConnection))
                    {
                        myConnection.Open();
                        myCommand.CommandType = CommandType.Text;
                        SqlDataReader objReader = myCommand.ExecuteReader();
                        while (objReader.Read())
                        {
                            UnitModel objItem = new UnitModel();
                            objItem.UnitId = Convert.ToInt32(objReader["unitId"]);
                            objItem.UnitName = objReader["unitName"].ToString();

                            objUnitList.Add(objItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUnitList = new List<UnitModel>();
            }
            return objUnitList;
        }

        #endregion

        #region LOGDATA
        public static bool LogData(ShopBridgeLog objLog)
        {
            bool IsLogged = false;
            try
            {
                string ssql = "INSERT INTO tbl_ServiceLogs(serviceName,methodName,deviceId,logData,logType,createdDate) VALUES (@serviceName,@methodName,@deviceId,@logData,@logType,GETDATE()) set @id=scope_identity()";
                using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand(ssql, myConnection))
                    {
                        myConnection.Open();
                        myCommand.Parameters.AddWithValue("@serviceName", objLog.ServiceName);
                        myCommand.Parameters.AddWithValue("@methodName", objLog.MethodName);
                        myCommand.Parameters.AddWithValue("@deviceId", objLog.DeviceId);
                        myCommand.Parameters.AddWithValue("@logData", objLog.LogData);
                        myCommand.Parameters.AddWithValue("@logType", objLog.LogType);

                        myCommand.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                        IsLogged = myCommand.ExecuteNonQuery() == 1 ? true : false;

                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                IsLogged = false;
            }
            return IsLogged;
        }
        #endregion

    }
}
