using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopBridgeServiceProvider;
using ShopBridgeEntities;
using System.Web.Script.Serialization;

namespace ShopBridgeSolutions
{
    public partial class ItemMaster : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropData(ShopBridgeProvider.GetDropData());
                hdnItemId.Value = "0";
                if (Request.QueryString.HasKeys())
                {
                    int ItemId = Convert.ToInt32(Request.QueryString["ItemId"]);
                    FillForm(ItemId);
                }
                
                //FillGrid(0);
               
            }
        }

        public void FillDropData(DropFillModel ObjDropData)
        {
            drCategory.Items.Clear();
            drCategory.DataValueField = "CategoryId";
            drCategory.DataTextField = "CategoryName";
            drCategory.DataSource = ObjDropData.CategoryList;
            drCategory.DataBind();
            //drCategory.Items.Insert(0, new ListItem("Select Category", "0"));


            drUnit.Items.Clear();
            drUnit.DataValueField = "UnitId";
            drUnit.DataTextField = "UnitName";
            drUnit.DataSource = ObjDropData.UnitList;
            drUnit.DataBind();
            //drCategory.Items.Insert(0, new ListItem("Select Unit", "0"));
        }

        

        private void FillForm(int ItemId)
        {
            ItemsListModel objResponse = new ItemsListModel();
            ItemModel objModel = new ItemModel();
            objModel.ItemId = ItemId;
            objResponse = ShopBridgeProvider.GetItems(objModel);
            if (objResponse.IsValid)
            {
                foreach (ItemModel objItemModel in objResponse.ItemsList)
                {
                    hdnItemId.Value = objItemModel.ItemId.ToString();
                    txtName.Text = objItemModel.ItemName;
                    drCategory.ClearSelection();
                    drCategory.Items.FindByValue(objItemModel.CategoryId.ToString()).Selected = true;
                    drUnit.ClearSelection();
                    drUnit.Items.FindByValue(objItemModel.UnitId.ToString()).Selected = true;
                    txtCost.Text = objItemModel.ItemCost.ToString();
                    txtPrice.Text = objItemModel.ItemPrice.ToString();
                }
            }
        }

        //protected void lnkEdit_Command(object sender, CommandEventArgs e)
        //{
        //    ItemsListModel objResponse = new ItemsListModel();
        //    ItemModel objModel = new ItemModel();
        //    objModel.ItemId = Convert.ToInt32(e.CommandArgument);
        //    objResponse = ShopBridgeProvider.GetItems(objModel);
        //    if (objResponse.IsValid)
        //    {
        //        foreach(ItemModel objItemModel in objResponse.ItemsList)
        //        {
        //            hdnItemId.Value = objItemModel.ItemId.ToString();
        //            txtName.Text = objItemModel.ItemName;
        //            drCategory.ClearSelection();
        //            drCategory.Items.FindByValue(objItemModel.CategoryId.ToString()).Selected = true;
        //            drUnit.ClearSelection();
        //            drUnit.Items.FindByValue(objItemModel.UnitId.ToString()).Selected = true;
        //            txtCost.Text = objItemModel.ItemCost.ToString();
        //            txtPrice.Text = objItemModel.ItemPrice.ToString();
        //        }
        //    }
        //}

        //protected void lnkDelete_Command(object sender, CommandEventArgs e)
        //{
        //    ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();

        //    ItemModel objModel = new ItemModel();
        //    objModel.ItemId = Convert.ToInt32(e.CommandArgument);
        //    objResponse = ShopBridgeProvider.DeleteItem(objModel);
        //    if (objResponse.IsValid)
        //    {
        //        FillGrid(0);
        //    }
        //}


        [System.Web.Services.WebMethod]
        public static string SaveItem(int ItemId, string ItemName,int CategoryId,int UnitId,float ItemCost,float ItemPrice)
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

            string result = objResponse.ResponseMessage;
            return result;
            
        }

        


    }
}