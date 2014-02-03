<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="AccountRelated.aspx.cs" Inherits="Inventory_AccountRelated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="well">
             <asp:Label ID="Label1" runat="server" Text="WelCome"></asp:Label>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2">
               <div class="well">
                    <div class="row">
                        <asp:TreeView ID="TreeView1" runat="server" Target="_blank" onselectednodechanged="TreeView1_SelectedNodeChanged" Width="151px">
                        </asp:TreeView>
                    </div>
               </div>
            </div>
                       
           <div class="col-lg-10">
                <div class="well">
                    <div class="row">
                        <asp:Label ID="lblType" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblDetail" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblIsDetail" runat="server" Text="" Visible="false"></asp:Label>
                     
                       <asp:FormView ID="FormView1" runat="server" 
                            onmodechanging="FormView1_ModeChanging"
                            onitemcommand="FormView1_ItemCommand" Width="488px" 
                            onitemupdating="FormView1_ItemUpdating" DefaultMode="ReadOnly" 
                            onitemdeleting="FormView1_ItemDeleting">
                            
                            <ItemTemplate>
                                <table width="450px">
                                <tr>
                                    <th colspan="2">
                                        <asp:Button ID="btnAgHead" runat="server" Text="Add A/C Group" 
                                            CommandName="AcGrp" onclick="btnAgHead_Click" TabIndex="1" />  
                                        <asp:Button ID="btnAcHead" runat="server" Text="Add A/C Head" 
                                            CommandName="AcHead" onclick="btnAcHead_Click" TabIndex="2" />  
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" 
                                            TabIndex="3" Width="88px" /> 
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" 
                                            TabIndex="4" Width="88px" OnClientClick="return confirm('Are you sure want to delete?');"/>  
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            Account Group</td>
                                        <td>
                                            <asp:Label ID="lblAccountgrp" Text='<%#Eval("PName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Code</td>
                                        <td>
                                            <asp:Label ID="lblAccountCode" Text='<%#Eval("Code") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Description</td>
                                        <td>
                                            <asp:Label ID="lblAccountDescription" Text='<%#Eval("AName") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                          <% if(lblType.Text=="A") { %>
                                    <tr>
                                        <td>
                                            Address Temporary</td>
                                        <td>
                                            <asp:Label ID="lblTempAddress" Text='<%#Eval("AddT") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address Permanent</td>
                                        <td>
                                            <asp:Label ID="lblPermanentAddress" Text='<%#Eval("AddP") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contact Person</td>
                                        <td>
                                            <asp:Label ID="lblContactPerson" Text='<%#Eval("ConPerson") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telephone</td>
                                        <td>
                                            <asp:Label ID="lblTelephone" Text='<%#Eval("Telephone") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile</td>
                                        <td>
                                            <asp:Label ID="lblMobile" Text='<%#Eval("Mobile") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email</td>
                                        <td>
                                            <asp:Label ID="lblEmail" Text='<%#Eval("EMail") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Web Page</td>
                                        <td>
                                            <asp:Label ID="lblWebpage" Text='<%#Eval("WebPage") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks</td>
                                        <td>
                                            <asp:Label ID="lblRemarks" Text='<%#Eval("Remarks") %>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                        <% } %>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:RadioButton ID="rbdIndividual" runat="server" Text="Individual" 
                                                GroupName="Owner" onclick="return false;"/>
                                             <asp:RadioButton ID="rbdSubDealer" runat="server"  Text="Sub Dealer" 
                                                onclick="return false;"/>
                                              <asp:RadioButton ID="rbdCommon" runat="server" Text="Common" 
                                                GroupName="Owner" onclick="return false;"/>
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
                                            Account Group</td>
                                        <td>
                                            <asp:TextBox ID="txtEditAccountGrp" Text='<%#Bind("PName") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Code</td>
                                        <td>
                                            <asp:TextBox ID="txtEditAccountCode" Text='<%#Bind("Code") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Description</td>
                                        <td>
                                            <asp:TextBox ID="txtEditAccountDescription" Text='<%#Bind("AName") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                          <% if (lblType.Text == "A")
                             { %>
                             <tr>
                                    <td>
                                        <asp:CheckBox ID="chkIsDetail" runat="server" 
                                            OnCheckedChanged="chkIsDetail_CheckedChanged" Text="Is Details" 
                                            AutoPostBack="True" />
                                    </td><td></td>
                                 </tr>
                                 <% if (lblDetail.Text == "Y")
                                    {%>
                                    <tr>
                                        <td>
                                            Address Temporary</td>
                                        <td>
                                            <asp:TextBox ID="txtEditTempAddress" Text='<%#Bind("AddT") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address Permanent</td>
                                        <td>
                                            <asp:TextBox ID="txtEditPermanentAddress" Text='<%#Bind("AddP") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contact Person</td>
                                        <td>
                                            <asp:TextBox ID="txtEditConPerson" Text='<%#Bind("ConPerson") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telephone</td>
                                        <td>
                                            <asp:TextBox ID="txtEditTelephone" Text='<%#Bind("Telephone") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txtEditMobile" Text='<%#Bind("Mobile") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email</td>
                                        <td>
                                            <asp:TextBox ID="txtEditEmail" Text='<%#Bind("EMail") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Web Page</td>
                                        <td>
                                            <asp:TextBox ID="txtEditWebPage" Text='<%#Bind("WebPage") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks</td>
                                        <td>
                                            <asp:TextBox ID="txtEditRemarks" Text='<%#Bind("Remarks") %>' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rbdEditOwner" runat="server" 
                                                RepeatDirection="Horizontal" SelectedValue='<%#Bind("Owner") %>'>
                                                <asp:ListItem Value="HO">Individual</asp:ListItem>
                                                <asp:ListItem Value="Sub">Sub Dealer</asp:ListItem>
                                                <asp:ListItem Value="Comm">Common</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                         <% } %>

                          <% if (lblDetail.Text == "N")
                                    {%>
                                    <tr>
                                        <td>
                                            Address Temporary</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadAddT" Text='<%#Bind("AddT") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address Permanent</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadAddP" Text='<%#Bind("AddP") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contact Person</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadConP" Text='<%#Bind("ConPerson") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telephone</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadTel" Text='<%#Bind("Telephone") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadMob" Text='<%#Bind("Mobile") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadEmail" Text='<%#Bind("EMail") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Web Page</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadWeb" Text='<%#Bind("WebPage") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks</td>
                                        <td>
                                            <asp:TextBox ID="txtEditReadRem" Text='<%#Bind("Remarks") %>' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:RadioButton ID="rbdIndividual" runat="server" Text="Individual" 
                                                GroupName="Owner"  />
                                             <asp:RadioButton ID="rbdSubDealer" runat="server"  Text="Sub Dealer" 
                                               />
                                              <asp:RadioButton ID="rbdCommon" runat="server" Text="Common" 
                                                GroupName="Owner" />
                                        </td>
                                    </tr>

                                     <%--<tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                RepeatDirection="Horizontal" SelectedValue='<%#Bind("Owner") %>'>
                                                <asp:ListItem Value="HO">Individual</asp:ListItem>
                                                <asp:ListItem Value="Sub">Sub Dealer</asp:ListItem>
                                                <asp:ListItem Value="Comm">Common</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>--%>
                         <% } %>

                         <%} %>
                                </table>
                            </EditItemTemplate>

                            <InsertItemTemplate>
                            
                            <%
                                AccountRelated accountobj = new AccountRelated();
                                
                                string[] Diff = TreeView1.SelectedNode.Value.Split('-');
                               if (Diff[1] == "A")
                                {
                                    string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
                                    ((TextBox)FormView1.FindControl("txtNewAccountGrp")).Text = TreeView1.SelectedNode.Parent.Text;
                                  }
                                else
                                {
                                    string[] DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
                                    ((TextBox)FormView1.FindControl("txtNewAccountGrp")).Text = TreeView1.SelectedNode.Text;
                                }
                             %>
                                <%
                                    System.Data.DataTable accode = accountobj.generateMaxNumber("AC", "HO");
                                    if (accode.Rows.Count > 0)
                                    {
                                        ((TextBox)FormView1.FindControl("txtNewAccountCode")).Text = accode.Rows[0][0].ToString();
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
                                            Account Group</td>
                                        <td>
                                            <asp:TextBox ID="txtNewAccountGrp" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Code</td>
                                        <td>
                                            <asp:TextBox ID="txtNewAccountCode" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Account Description</td>
                                        <td>
                                            <asp:TextBox ID="txtNewAccountDescription" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                             
                          <% if (lblType.Text == "A")
                             { %>
                                 <tr>
                                    <td>
                                        <asp:CheckBox ID="chkIsDetail" runat="server" 
                                            OnCheckedChanged="chkIsDetail_CheckedChanged" Text="Is Details" 
                                            AutoPostBack="True" />
                                    </td><td></td>
                                 </tr>
                                 <% if (lblDetail.Text == "Y")
                                    {%>
                                 <tr>
                                        <td>
                                            Address Temporary</td>
                                        <td>
                                            <asp:TextBox ID="txtNewTempAddress" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address Permanent</td>
                                        <td>
                                            <asp:TextBox ID="txtNewPermanentAddress" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contact Person</td>
                                        <td>
                                            <asp:TextBox ID="txtNewConPerson" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telephone</td>
                                        <td>
                                            <asp:TextBox ID="txtNewTelephone" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txtNewMobile" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email</td>
                                        <td>
                                            <asp:TextBox ID="txtNewEmail" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Web Page</td>
                                        <td>
                                            <asp:TextBox ID="txtNewWebPage" Text='' runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks</td>
                                        <td>
                                            <asp:TextBox ID="txtNewRemarks" Text='' runat="server" Width="200px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                 <%} %>


                                  <% else if(lblDetail.Text == "N")
                                    {%>
                                 <tr>
                                        <td>
                                            Address Temporary</td>
                                        <td>
                                            <asp:TextBox ID="txtNullTempA" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address Permanent</td>
                                        <td>
                                            <asp:TextBox ID="txtNullPAdd" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Contact Person</td>
                                        <td>
                                            <asp:TextBox ID="txtNullCPerson" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telephone</td>
                                        <td>
                                            <asp:TextBox ID="txtNullTel" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txtNullMob" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email</td>
                                        <td>
                                            <asp:TextBox ID="txtNullEmail" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Web Page</td>
                                        <td>
                                            <asp:TextBox ID="txtNullWeb" Text='' runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks</td>
                                        <td>
                                            <asp:TextBox ID="txtNullRem" Text='' runat="server" Width="200px" ReadOnly="true" ></asp:TextBox>
                                        </td>
                                    </tr>
                                 <%} %>


                                     <% } %>

                                    <%-- <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rbdnewOwner" runat="server" 
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem>Individual</asp:ListItem>
                                                <asp:ListItem Value="Sub">Sub Dealer</asp:ListItem>
                                                <asp:ListItem Value="Comm">Common</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>--%>
                                      <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:RadioButton ID="rbdIndividual" runat="server" Text="Individual" 
                                                GroupName="Owner"/>
                                             <asp:RadioButton ID="rbdSubDealer" runat="server"  Text="Sub Dealer" 
                                               />
                                              <asp:RadioButton ID="rbdCommon" runat="server" Text="Common" 
                                                GroupName="Owner"/>
                                        </td>
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

