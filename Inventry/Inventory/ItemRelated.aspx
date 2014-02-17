﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="ItemRelated.aspx.cs" Inherits="Inventory_ItemRelated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="well">
              Welcome :
				
				<%-- <tr>
                                        <td>
                                            Product Name</td>
                                        <td>
                                            <asp:Label ID="lblProductName" Text='<%# Eval("AddT") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
			    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2">
               <div class="well">
                    <div class="row">
                        <asp:TreeView ID="TreeView1" runat="server" onselectednodechanged="TreeView1_SelectedNodeChanged" Target="_blank"  Width="151px">
                        </asp:TreeView>
                    </div>
               </div>
            </div>
            <%-- <tr>
                                        <td>
                                            Product Name</td>
                                        <td>
                                            <asp:Label ID="lblProductName" Text='<%# Eval("AddT") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
           <div class="col-lg-10">
                <div class="well">
                    <div class="row">
                      
                      <asp:Label ID="lblType" runat="server" Visible="False"></asp:Label>
                      <asp:Label ID="lblDetail" runat="server" Text="" Visible="false"></asp:Label>
                       <asp:FormView ID="FormView1" runat="server" Width="488px" DefaultMode="ReadOnly"
                            onmodechanging="FormView1_ModeChanging"
                            onitemcommand="FormView1_ItemCommand"  
                            onitemupdating="FormView1_ItemUpdating" 
                            onitemdeleting="FormView1_ItemDeleting">
                            
                            <ItemTemplate>
                                <table width="450px">
                                <tr>
                                    <th colspan="2">
                                        <asp:Button ID="btnItemGroup" runat="server" Text="Create Product Group" 
                                            CommandName="CreateItemGroup" onclick="btnItemGroup_Click" />  
                                        <asp:Button ID="btnItemList" runat="server" Text="Create Product" 
                                            CommandName="CreateItemList" onclick="btnItemList_Click" />  
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" 
                                            TabIndex="3" Width="88px" /> 
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" 
                                            TabIndex="4" Width="88px" OnClientClick="return confirm('Are you sure want to delete?');"/>  
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            Parent</td>
                                        <td>
                                            <asp:Label ID="lblProductParent" Text='<%#Eval("PName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Product Code</td>
                                        <td>
                                             <asp:Label ID="lblProductSex" Text='<%#Eval("Sex") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblProductCode" Text='<%#Eval("Code") %>' runat="server"></asp:Label>
                                           
                                        </td>
                                    </tr>
                                   <%
                                       string[] Diff = TreeView1.SelectedNode.Value.Split('-');
                                       string[] DiffUpDt;
                                       if (Diff[1] == "A")
                                        {
                                            DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
                                            lblType.Text = DiffUpDt[1];
                                        }
                                        else
                                        {
                                            DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
                                            lblType.Text = DiffUpDt[1];
                                        }

                                       if (DiffUpDt[1]=="A")
                                       {
                                           ((Label)FormView1.FindControl("lblProductItm")).Visible = true;
                                       }
                                       else if(DiffUpDt[1]=="G")
                                       {
                                           ((Label)FormView1.FindControl("lblProductGrp")).Visible = true;
                                       }
                                      
                                    %>
                                   
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProductItm" Text="Product Name" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblProductGrp" Text="Product Group" runat="server" Visible="false"></asp:Label>
                                           
                                           <%-- Product Group/Name--%></td>
                                        <td>
                                            <asp:Label ID="lblProductGroup" Text='<%#Eval("IName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                          
                                    <tr>
                                        <td>
                                            Product Name Details</td>
                                        <td>
                                            <asp:Label ID="lblProductDeatils" Text='<%#Eval("ItName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Company Rate</td>
                                        <td>
                                            <asp:Label ID="lblCRate" Text='<%#Eval("CRate") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Purchase Rate</td>
                                        <td>
                                            <asp:Label ID="lblPRate" Text='<%#Eval("PRate") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Wholesale Rate</td>
                                        <td>
                                            <asp:Label ID="lblWRate" Text='<%#Eval("WRate") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Selling Rate</td>
                                        <td style="height: 22px">
                                            <asp:Label ID="lblSRate" Text='<%#Eval("SRate") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Provider (Supllier)</td>
                                        <td>
                                            <asp:Label ID="lblProvider" Text='<%#Eval("SCode") %>' runat="server"></asp:Label>
                                            <asp:Label ID="lblSupllier" Text='<%#Eval("SName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Base Unit</td>
                                        <td>
                                            <asp:Label ID="lblBaseUnit" Text='<%#Eval("BaseUnit") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                           
                                    <tr>
                                        <td>
                                            Minimum Level</td>
                                        <td>
                                            <asp:Label ID="lblMinStock" runat="server" Text='<%#Eval("MinStock") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Maximum Level</td>
                                        <td>
                                            <asp:Label ID="lblMaxStock" runat="server" Text='<%#Eval("MaxStock") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discount Type</td>
                                        <td>
                                            <asp:Label ID="lblDiscType" runat="server" Text='<%#Eval("DiscType") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Amount/Percentage</td>
                                        <td>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            VAT/None VAT</td>
                                        <td>
                                            <asp:Label ID="lblVat" runat="server" Text=''></asp:Label>
                                        </td>
                                    </tr>
                                 
                                </table>
                            </ItemTemplate>

                            <EditItemTemplate>
                                 <table style="width: 450px">
                                   <tr>
                                    <th colspan="2">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="edit" />  
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" /> 
                                    </th>
                                </tr>
                                   
                                    <tr>
                                        <td>
                                            Parent</td>
                                        <td>
                                            <asp:TextBox ID="txtEditProductParent" runat="server" Width="200px" Text='<%# Bind("PName") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Product Code</td>
                                        <td>
                                            <asp:TextBox ID="txtEditCode" runat="server" Width="200px" Text='<%# Bind("Code") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Product Group/Name</td>
                                        <td>
                                            <asp:TextBox ID="txtEditIName" runat="server" Width="200px" Text='<%# Bind("IName") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                          
                                    <tr>
                                        <td>
                                            Product Name Details</td>
                                        <td>
                                            <asp:TextBox ID="txtEditItName" runat="server" Width="200px" Text='<%# Bind("ItName") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                 <% if (lblType.Text == "A")
                                    { %>
                                    <tr>
                                        <td>
                                            Company Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtEditCRate" runat="server" Width="200px" Text='<%# Bind("CRate") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Purchase Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtEditPRate" runat="server" Width="200px" Text='<%# Bind("PRate") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Wholesale Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtEditWRate" runat="server" Width="200px" Text='<%# Bind("WRate") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px">
                                            Selling Rate</td>
                                        <td style="height: 22px">
                                            <asp:TextBox ID="txtEditSRate" runat="server" Width="200px" Text='<%# Bind("SRate") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Provider (Supllier)</td>
                                        <td>
                                            <%--<asp:DropDownList ID="ddlListEditSupllier" runat="server">
                                            </asp:DropDownList>--%>
                                            &nbsp;
                                            <asp:TextBox ID="txtEditACode" runat="server" Width="100px" Text='<%# Bind("Code") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Base Unit</td>
                                        <td>
                                           <%-- <asp:DropDownList ID="ddlListEditBaseUnit" runat="server" Text='<%# Bind("BaseUnit") %>'>
                                            </asp:DropDownList>--%>
                                        </td>
                                    </tr>
                        
                                
                                    <tr>
                                        <td>
                                            Minimum Level</td>
                                        <td>
                                            <asp:TextBox ID="txtEditMinStock" runat="server" Width="200px" Text='<%# Bind("MinStock") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Maximum Level</td>
                                        <td>
                                            <asp:TextBox ID="txtEditMaxStock" runat="server" Width="200px" Text='<%# Bind("MaxStock") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discount Type</td>
                                        <td>
                                            <asp:RadioButtonList ID="rbdListEditDiscType" runat="server" 
                                                RepeatDirection="Horizontal"><%-- SelectedValue='<%#Bind("DiscType") %>'--%>
                                                <asp:ListItem Value="F">Flat</asp:ListItem>
                                                <asp:ListItem Value="P">Percentage</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Amount/Percentage</td>
                                        <td>
                                            <asp:TextBox ID="txtEditAmount" runat="server" Width="200px" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            VAT/None VAT</td>
                                        <td>
                                            <asp:RadioButtonList ID="rbdlistEditVat" runat="server" 
                                                RepeatDirection="Horizontal"> <%--SelectedValue='<%#Bind("VAT") %>'--%>
                                                <asp:ListItem Value="V">VAT</asp:ListItem>
                                                <asp:ListItem Value="N">None VAT</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                  <%} %>
                                </table>
                            </EditItemTemplate>

                            <InsertItemTemplate>
                            
                            <%
                                MasterRelated subdealerobj = new MasterRelated();
                                
                                string[] Diff = TreeView1.SelectedNode.Value.Split('-');
                                if (Diff[1] == "A")
                                {
                                    string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
                                    ((TextBox)FormView1.FindControl("txtIsProductParent")).Text = TreeView1.SelectedNode.Parent.Text;
                                }
                                else
                                {
                                    string[] DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
                                    ((TextBox)FormView1.FindControl("txtIsProductParent")).Text = TreeView1.SelectedNode.Text;
                                }
                             %>
                                <%
                                    System.Data.DataTable accode = subdealerobj.generateMaxNumber("II", "HO");
                                    if (accode.Rows.Count > 0)
                                    {
                                        ((TextBox)FormView1.FindControl("txtIsICode")).Text = accode.Rows[0][0].ToString();
                                    }
                                    
                                %>
                            
                                 <table style="width: 450px">
                                   <tr>
                                    <th colspan="2">
                                        <asp:Button ID="btnCreate" runat="server" Text="Create" CommandName="create" />  
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" /> 
                                    </th>
                                </tr>
                                 
                                    <tr>
                                        <td>
                                            Parent</td>
                                        <td>
                                            <asp:TextBox ID="txtIsProductParent" runat="server" Width="200px" Text='' ReadOnly="true"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Product Code</td>
                                        <td>
                                            <asp:TextBox ID="txtIsICode" runat="server" Width="200px" Text='' ReadOnly="true"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblProductGrp" Text="Product Group" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblProductItm" Text="Product Name" runat="server" Visible="false"></asp:Label>
                                         </td>
                                        <td>
                                            <asp:TextBox ID="txtIsIName" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                          
                                    <tr>
                                        <td>
                                            Product Name Details</td>
                                        <td>
                                            <asp:TextBox ID="txtIsItName" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                        <% if (lblType.Text == "A")
                          { %>
                                    <tr>
                                        <td>
                                            Company Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtIsCRate" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Purchase Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtIsPRate" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Wholesale Rate</td>
                                        <td>
                                            <asp:TextBox ID="txtIsWRate" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px">
                                            Selling Rate</td>
                                        <td style="height: 22px">
                                            <asp:TextBox ID="txtIsSRate" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Provider (Supllier)</td>
                                        <td>
                                            <asp:DropDownList ID="ddlListIsSupllier" runat="server">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:TextBox ID="txtIsACode" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Base Unit</td>
                                        <td>
                                            <asp:DropDownList ID="ddlListIsBaseUnit" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                        
                                
                                    <tr>
                                        <td>
                                            Minimum Level</td>
                                        <td>
                                            <asp:TextBox ID="txtIsMinStock" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Maximum Level</td>
                                        <td>
                                            <asp:TextBox ID="txtIsMaxStock" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discount Type</td>
                                        <td>
                                            <asp:RadioButtonList ID="rbdListIsDiscType" runat="server" 
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="F">Flat</asp:ListItem>
                                                <asp:ListItem Value="P">Percentage</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Amount/Percentage</td>
                                        <td>
                                            <asp:TextBox ID="txtIsAmount" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            VAT/None VAT</td>
                                        <td>
                                            <asp:RadioButtonList ID="rbdlistIsVat" runat="server" 
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="V">VAT</asp:ListItem>
                                                <asp:ListItem Value="N">None VAT</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <%} %>
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

