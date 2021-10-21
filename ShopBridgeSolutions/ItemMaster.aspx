<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="ShopBridgeSolutions.ItemMaster" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        <!-- Content Header (Page header) -->
        <section class="content-header"><h1>Item Master</h1></section>

        <!-- Main content -->
        <section class="content">
          <div class="row">
            <!-- left column -->
            <div class="col-lg-12">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Add Item</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">
            <asp:HiddenField ID="hdnItemId" runat="server" />
                    <div class="row"><div class="col-xs-6"><label>Name</label></div> </div>
                    <div class="row">
                        <div class="col-xs-6"><asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox></div>                      
                    </div>
                    <div class="row"><div class="col-xs-6"> <asp:Label ID="lblErrItemName"  style="display: none; color:darkred" runat="server" Text="Please Enter Item Name"></asp:Label></div></div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="row"><div class="col-lg-6"><label>Category</label></div></div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="row"><div class="col-lg-6"><label>Unit</label></div></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:DropDownList ID="drCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <%--<select class="form-control" id="drCategorySSS">
                                                <option>option 1</option>
                                                <option>option 2</option>
                                                <option>option 3</option>
                                                <option>option 4</option>
                                                <option>option 5</option>
                                            </select>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:DropDownList ID="drUnit" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <%--<select class="form-control" id="drUnit">
                                                <option>option 1</option>
                                                <option>option 2</option>
                                                <option>option 3</option>
                                                <option>option 4</option>
                                                <option>option 5</option>
                                            </select>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-xs-6"> <asp:Label ID="lblErrCategory"  style="display: none; color:darkred" runat="server" Text="Please Select Category"></asp:Label></div>
                                <div class="col-xs-6"> <asp:Label ID="lblErrUnit"  style="display: none; color:darkred" runat="server" Text="Please Select Unit"></asp:Label></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="row"><div class="col-lg-6"><label>Cost</label></div></div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="row"><div class="col-lg-6"><label>Price</label></div></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6"><asp:TextBox ID="txtCost" CssClass="form-control" runat="server"></asp:TextBox></div>                      
                                <div class="col-xs-6"><asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox></div>                      
                            </div>
                            <div class="row">
                                <div class="col-xs-6"> 
                                    <asp:Label ID="lblErrCost"  style="display: none; color:darkred" runat="server" Text="Please enter amount"></asp:Label>
                                    <asp:Label ID="lblErrCostDecimal"  style="display: none; color:red" runat="server" Text="Please enter amount only"></asp:Label>
                                </div>
                                <div class="col-xs-6"> 
                                    <asp:Label ID="lblErrPrice"  style="display: none; color:darkred" runat="server" Text="Please enter amount"></asp:Label>
                                    <asp:Label ID="lblErrPriceDecimal"  style="display: none; color:darkred" runat="server" Text="Please enter amount only"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6" ><button type="submit" class="btn btn-primary btn-lg pull-right" runat="server" onclick="CallSaveMethod();return false;" OnClientClick="javascript:return Validation();">Submit</button></div>
                                </div>
                            </div>
                        </div>
                  </div>
              </div><!-- /.box -->



             
            </div><!--/.col (left) -->
           
          </div>   <!-- /.row -->
        </section><!-- /.content -->
      

    
   
    <script type="text/javascript">  
        


        function CallSaveMethod() {
            debugger;

            isValid = false;
            if (document.getElementById('<%=txtName.ClientID %>').value == "") {
                document.getElementById('<%=lblErrItemName.ClientID %>').style.display = 'inherit'
                isValid = false;
            }
            else {
                document.getElementById('<%=lblErrItemName.ClientID %>').style.display = 'none'
                isValid = true;

                if (document.getElementById('<%=drCategory.ClientID %>').value == "6") {
                    document.getElementById('<%=lblErrCategory.ClientID %>').style.display = 'inherit'
                    isValid = false;
                }
                else {
                    document.getElementById('<%=lblErrCategory.ClientID %>').style.display = 'none'
                    isValid = true;

                    if (document.getElementById('<%=drUnit.ClientID %>').value == "6") {
                        document.getElementById('<%=lblErrUnit.ClientID %>').style.display = 'inherit'
                        isValid = false;
                    }
                    else {
                        document.getElementById('<%=lblErrUnit.ClientID %>').style.display = 'none'
                        isValid = true;

                        if (document.getElementById('<%=txtPrice.ClientID %>').value == "") {
                            document.getElementById('<%=lblErrPrice.ClientID %>').style.display = 'inherit'
                            isValid = false;
                        }
                        else {
                            document.getElementById('<%=lblErrPrice.ClientID %>').style.display = 'none'

                            var rgexp = new RegExp("^([1-9]{0,2})([0-9]{1})(|.[0-9]{1,2}|,\[0-9]{1,2})?$");
                            var inputPrice = document.getElementById('<%=txtPrice.ClientID %>').value;

                            if (inputPrice.match(rgexp)) {
                                document.getElementById('<%=lblErrPriceDecimal.ClientID %>').style.display = 'none'
                                isValid = true;

                                if (document.getElementById('<%=txtCost.ClientID %>').value == "") {
                                    document.getElementById('<%=lblErrCost.ClientID %>').style.display = 'inherit'
                                    isValid = false;
                                }
                                else {
                                    document.getElementById('<%=lblErrCost.ClientID %>').style.display = 'none'
                                    var rgexpN = new RegExp("^([1-9]{0,2})([0-9]{1})(|.[0-9]{1,2}|,\[0-9]{1,2})?$");
                                    var inputCost = document.getElementById('<%=txtCost.ClientID %>').value;

                                    if (inputCost.match(rgexpN)) {
                                        document.getElementById('<%=lblErrCostDecimal.ClientID %>').style.display = 'none'
                                        isValid = true;
                                    }
                                    else {
                                        document.getElementById('<%=lblErrCostDecimal.ClientID %>').style.display = 'inherit'
                                        isValid = false;
                                    }

                                }
                            }
                            else {
                                document.getElementById('<%=lblErrPriceDecimal.ClientID %>').style.display = 'inherit'
                                isValid = false;
                            }
                        }
                    }
                }
            }

            if (isValid == false)
                return false;




            var _ItemId = document.getElementById('<%=hdnItemId.ClientID %>').value;
            var _ItemName = document.getElementById('<%=txtName.ClientID %>').value;
            var _CategoryId = document.getElementById('<%=drCategory.ClientID %>').value;
            var _UnitId = document.getElementById('<%=drUnit.ClientID %>').value;
            var _ItemCost = document.getElementById('<%=txtCost.ClientID %>').value;
            var _ItemPrice = document.getElementById('<%=txtPrice.ClientID %>').value;



            $.ajax({
                url: 'ItemMaster.aspx/SaveItem',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                cache: false,
                data: JSON.stringify(
                    {
                        ItemId: _ItemId,
                        ItemName: _ItemName,
                        CategoryId: _CategoryId,
                        UnitId: _UnitId,
                        ItemCost: _ItemCost,
                        ItemPrice: _ItemPrice,
                    }),
                success: function (data) {
                    //debugger;
                    alert(data.d);
                    var url = "SearchItem.aspx";
                    $(location).attr('href', url);
                    //$("#MainContent_txtName").val('');
                    //$("#MainContent_txtCost").val('');
                    //$("#MainContent_txtPrice").val('');
                    //$("#MainContent_drCategory").val('1');
                    //$("#MainContent_drUnit").val('1');
                    //$("#MainContent_txtPrice").val('');
                    //$("#MainContent_txtName").focus();

                },
                error: function (xhr) {
                    alert(JSON.stringify(xhr));
                }
            });


        }
</script>
</asp:Content>
