<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="PurchaseReturn.aspx.cs" Inherits="Inventory_PurchaseReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
        <div class="well">
             Welcome :
				<asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2">
               <div class="well">
                    <div class="row">
                       <%-- <asp:TreeView ID="TreeView1" runat="server" Target="_blank" onselectednodechanged="TreeView1_SelectedNodeChanged" Width="151px">
                        </asp:TreeView>--%>
                    </div>
               </div>
            </div>
                       
           <div class="col-lg-10">
                <div class="well">
                    <div class="row">
                       <asp:FormView ID="FormView1" runat="server" 
                             Width="488px" 
                             DefaultMode="Insert">
                           <InsertItemTemplate>
                               <table style="width: 500px" dir="ltr">
                                   <tr>
                                       <td>
                                           Invoice No</td>
                                       <td>
                                           <asp:TextBox ID="txtInvoiceNo" runat="server"></asp:TextBox></td>
                                        <td>
                                           Code</td>
                                       <td>
                                           <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           EDate</td>
                                       <td>
                                           <asp:TextBox ID="txtEDate" runat="server"></asp:TextBox>
                                           NDate
                                           <asp:TextBox ID="txtNDate" runat="server"></asp:TextBox>
                                           </td>
                                        <td>
                                           Name</td>
                                       <td>
                                           <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Supplier Name</td>
                                       <td>
                                           <asp:DropDownList ID="ddlSupplierName" runat="server">
                                           </asp:DropDownList>
                                           Code
                                           <asp:TextBox ID="txtSupplierCode" runat="server"></asp:TextBox>
                                       </td>
                                       <td>
                                           Group</td>
                                       <td>
                                           <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Supplier Bill</td>
                                       <td>
                                           <asp:TextBox ID="txtSupplierBill" runat="server"></asp:TextBox>
                                           Date
                                           <asp:TextBox ID="txtSupplierBillDate" runat="server"></asp:TextBox>
                                           </td>
                                           <td>
                                           Qty</td>
                                       <td>
                                           <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                                           PRate
                                           <asp:TextBox ID="txtPRate" runat="server"></asp:TextBox>
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Description</td>
                                       <td>
                                           <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                           </td>
                                            <td>
                                           Purchase Rate</td>
                                       <td>
                                           <asp:TextBox ID="txtPurchaseRate" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                           <td>
                                           Wholesale Rate</td>
                                       <td>
                                           <asp:TextBox ID="txtWholesaleRate" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                           <td>
                                           Sales Rate</td>
                                       <td>
                                           <asp:TextBox ID="txtSalesRate" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                           <td>
                                           Amount</td>
                                       <td>
                                           <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                           <td>
                                           Unit</td>
                                       <td>
                                           <asp:DropDownList ID="ddlUnit" runat="server">
                                           </asp:DropDownList>
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                            <td>
                                           &nbsp;</td>
                                       <td>
                                           <asp:Button ID="btnAdd" runat="server" Text="Add" /></td>
                                   </tr>
                               </table>
                          </InsertItemTemplate>
                           
                        </asp:FormView>
                         <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

