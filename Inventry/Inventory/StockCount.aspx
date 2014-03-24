<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="StockCount.aspx.cs" Inherits="Inventory_StockCount" %>

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
                             DefaultMode="Insert" onitemcommand="FormView1_ItemCommand" 
                            onmodechanging="FormView1_ModeChanging"> 
                           
                         
                            <InsertItemTemplate>
                                 <script type="text/javascript">

                                     function ddlChange() {
                                         var ddl = document.getElementById('<%=((DropDownList)FormView1.FindControl("ddlListIsSupllier")).ClientID %>');
                                         var textBox = document.getElementById('<%=((TextBox)FormView1.FindControl("txtNewDealerName")).ClientID%>');

                                         textBox.value = ddl.options[ddl.selectedIndex].value;
                                     }

                                    
                             </script>
                                 <%
                                     GeneralRelated obj = new GeneralRelated();
                                     string username = Session["username"].ToString();
                                     string password = Session["password"].ToString();
                                     System.Data.DataTable dt = obj.getSubDealers(username, password);
                                     if (dt.Rows.Count > 0)
                                     {
                                         ((DropDownList)FormView1.FindControl("ddlListIsSupllier")).DataSource = dt;
                                         ((DropDownList)FormView1.FindControl("ddlListIsSupllier")).DataTextField = "Name";
                                         ((DropDownList)FormView1.FindControl("ddlListIsSupllier")).DataValueField = "Dealer";
                                         ((DropDownList)FormView1.FindControl("ddlListIsSupllier")).DataBind();
                                         ((DropDownList)FormView1.FindControl("ddlListIsSupllier")).Items.Insert(0, new ListItem("--Select--", "0"));
                                        
                                     }
                                  %>
                                 <table style="width: 450px">
                                  
                                   <tr>
                                        <td>
                                            Dealer Name</td>
                                        <td>
                                             <asp:DropDownList ID="ddlListIsSupllier" runat="server" onchange="ddlChange()" 
                                                 EnableViewState="False">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:TextBox ID="txtNewDealerName" runat="server" Width="109px"></asp:TextBox>
                                        </td>
                                    </tr>
                                     
                                    <tr>
                                        <td>
                                            Item Code</td>
                                        <td>
                                            <asp:TextBox ID="txtNewItemCode" Text='' runat="server" Width="200px" 
                                                 AutoPostBack="True" 
                                                EnableViewState="False" ontextchanged="txtNewItemCode_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Name</td>
                                        <td>
                                            <asp:TextBox ID="txtNewItemName" Text='' runat="server" Width="200px" 
                                                ReadOnly="true" Height="22px"></asp:TextBox>
                                        </td>
                                    </tr>
                                <tr>
                                        <td>
                                            Suppliers</td>
                                        <td>
                                            <asp:TextBox ID="txtNewSupplier" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Type</td>
                                        <td>
                                            <asp:TextBox ID="txtNewItemType" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Previous Count</td>
                                        <td>
                                            <asp:TextBox ID="txtPreviousCount" Text='' runat="server" Width="200px" 
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtNewRate" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td>
                                            Stock Count</td>
                                        <td>
                                            <asp:TextBox ID="txtNewStockCount" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                      <th colspan="2">
                                        <asp:Button ID="btnCreate" runat="server" Text="Update" CommandName="create" />  
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" /> 
                                    </th>
                                  </tr>
                        
                                </table>
                            </InsertItemTemplate>
                           
                        </asp:FormView>
                         <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

