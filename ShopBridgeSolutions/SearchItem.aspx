<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchItem.aspx.cs" Inherits="ShopBridgeSolutions.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header"><h1>Item Master</h1></section>

        <!-- Main content -->
        <section class="content">
          <div class="row">
            <!-- left column -->
            <div class="col-lg-12">
             
             <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Items</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">
                  <div class="row">
                      <div class="col-xs-2"><label>Category</label></div> 
                      <div class="col-xs-2"><label>Unit</label></div> 
                      <div class="col-xs-4"><label>Search Here</label></div>
                      <div class="col-xs-2"><label>Sort Order</label></div> 

                  </div>
                        <div class="row">
                            <div class="col-xs-2"><asp:DropDownList ID="drCategory" runat="server" CssClass="form-control"></asp:DropDownList></div>
                            <div class="col-xs-2"> <asp:DropDownList ID="drUnit" runat="server" CssClass="form-control"></asp:DropDownList></div>
                            <div class="col-xs-4"><asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox></div>   
                            <div class="col-xs-2">
                                <asp:DropDownList ID="drSortOrder" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="itemModifiedDate Desc">Date Desc</asp:ListItem>
                                    <asp:ListItem Value="itemModifiedDate Asc">Date Asc</asp:ListItem>
                                    <asp:ListItem Value="itemName Desc">Name Desc</asp:ListItem>
                                    <asp:ListItem Value="itemName ASC">Name Asc</asp:ListItem>
                                    <asp:ListItem Value="itemPrice Desc">Price Desc</asp:ListItem>
                                    <asp:ListItem Value="itemPrice Asc">Price Asc</asp:ListItem>
                                    <asp:ListItem Value="itemCost Desc">Cost Desc</asp:ListItem>
                                    <asp:ListItem Value=" itemCost Asc">Cost Asc</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-2"><asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-lg pull-right" Text="Search" OnClick="btnSearch_Click" /></div>                   
                        </div>
                      <br />
                     <asp:GridView ID="gdItems" runat="server" CssClass="table table-bordered table-hover dataTable" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField DataField="ItemName" HeaderText="Name" />
                             <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                             <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                             <asp:BoundField DataField="ItemPrice" HeaderText="Price" />
                             <asp:BoundField DataField="ItemCost" HeaderText="Cost" />
                             <asp:BoundField DataField="CreatedDate" HeaderText="Created On" />
                             <asp:BoundField DataField="ModifiedDate" HeaderText="Modified On" />
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("ItemId") %>' OnCommand="lnkEdit_Command" >Edit</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("ItemId") %>' OnCommand="lnkDelete_Command">Delete</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                      </asp:GridView> 
                    
                  </div><!-- /.box-body -->

                  
              </div><!-- /.box -->

             
            </div><!--/.col (left) -->
           
          </div>   <!-- /.row -->
        </section><!-- /.content -->
      

   
        


        
</asp:Content>
