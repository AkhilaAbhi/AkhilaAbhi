using ShopBridgeEntities;
using ShopBridgeServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopBridgeSolutions
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropData(ShopBridgeProvider.GetDropData());
                BindGrid();
                //FillGrid(0);
            }
        }


        public void FillGrid(int ItemId)
        {
            ItemsListModel objResponse = new ItemsListModel();
            ItemModel objModel = new ItemModel();
            objModel.ItemId = ItemId;
            objResponse = ShopBridgeProvider.GetItems(objModel);
            if (objResponse.IsValid)
            {
                gdItems.DataSource = objResponse.ItemsList;
                gdItems.DataBind();
            }
        }

        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            ShopBridgeResponseModel objResponse = new ShopBridgeResponseModel();

            ItemModel objModel = new ItemModel();
            objModel.ItemId = Convert.ToInt32(e.CommandArgument);
            objResponse = ShopBridgeProvider.DeleteItem(objModel);
            if (objResponse.IsValid)
            {
                FillGrid(0);
            }
        }

        protected void lnkEdit_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect(string.Format("~/ItemMaster.aspx?ItemId={0}", Convert.ToInt32(e.CommandArgument)));
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            ItemsListModel objResponse = new ItemsListModel();
            SearchRequestModel objRequest = new SearchRequestModel();
            objRequest.CategoryId = Convert.ToInt32(drCategory.SelectedValue);
            objRequest.UnitId = Convert.ToInt32(drUnit.SelectedValue);
            objRequest.SearchText = txtName.Text;
            objRequest.SortOrder = drSortOrder.SelectedItem.Value;
            objResponse = ShopBridgeProvider.SearchItems(objRequest);
            if (objResponse.IsValid)
            {
                gdItems.DataSource = objResponse.ItemsList;
                gdItems.DataBind();
            }
        }

        private void FillDropData(DropFillModel ObjDropData)
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
    }
}