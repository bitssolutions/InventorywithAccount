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
         <div class="col-lg-12">
               <div class="well">
                     <div class="row">
     <%
         
                                    string owner = Session["dealer"].ToString();
                                    MasterRelated itemobj = new MasterRelated();
                                    GeneralRelated generalobj = new GeneralRelated();
                                    System.Data.DataTable accode = generalobj.generateMaxNumber("PR", owner);
                                    if (accode.Rows.Count > 0)
                                    {
                                        txtInvoiceNo.Text = accode.Rows[0][0].ToString();
                                    }

                                  
                                   
                                %>
                                 <%
                                  string usercode = Session["usercode"].ToString();
                                  System.Data.DataTable suplier = itemobj.AccountListforPurchase(owner, usercode);
                                  if (suplier.Rows.Count > 0)
                                  {
                                      ddlSupplierName.DataSource = suplier;
                                      ddlSupplierName.DataTextField = "Name";
                                      ddlSupplierName.DataValueField = "Code";
                                      ddlSupplierName.DataBind();
                                      ddlSupplierName.Items.Insert(0, new ListItem("--Select--", "0"));
                                  }
                               %>
                              
                               <%
                                  
                                 txtEDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                %>

                              
                               
                               <script type="text/javascript">

                                   function ddlChange() {
                                       var ddl = document.getElementById('<%=(ddlSupplierName).ClientID %>');
                                       var textBox = document.getElementById('<%=(txtSupplierCode).ClientID%>');

                                       textBox.value = ddl.options[ddl.selectedIndex].value;
                                   }

                                  

                             </script>

                     <table style="width: 800px">
                                  <tr>
                                       <td>
                                           Invoice No</td>
                                       <td>
                                           <asp:TextBox ID="txtInvoiceNo" runat="server"></asp:TextBox></td>
                                        <td>
                                           Code</td>
                                       <td>
                                           <asp:TextBox ID="txtType" runat="server" Visible="false" Width="90px" 
                                               TabIndex="9"></asp:TextBox>
                                            <asp:DropDownList ID="ddlistType" runat="server" TabIndex="9">
                                               <asp:ListItem Value="M">M</asp:ListItem>
                                               <asp:ListItem Value="L">L</asp:ListItem>
                                               <asp:ListItem Value="C">C</asp:ListItem>
                                               
                                           </asp:DropDownList>
                                           <asp:TextBox ID="txtCode" runat="server" Width="90px"
                                               Font-Bold="False" AutoPostBack="True" 
                                                TabIndex="10" ontextchanged="txtCode_TextChanged" />
                                          
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           EDate</td>
                                       <td>
                                           <asp:TextBox ID="txtEDate" runat="server" ReadOnly="true" Width="80px" 
                                               TabIndex="1"></asp:TextBox>
                                           NDate
                                           <asp:TextBox ID="txtNDate" runat="server" ReadOnly="true"  Width="80px" 
                                               TabIndex="2"></asp:TextBox>
                                           </td>
                                        <td>
                                           Name</td>
                                            <td style="width: 339px">
                                            <asp:TextBox ID="txtName" runat="server"  Width="90px"
                                                    AutoPostBack="True"  TabIndex="11" />
                                        Qty
                                       <asp:TextBox ID="txtQty" runat="server" Width="90px" TabIndex="12" AutoPostBack="True" 
                                                    ontextchanged="txtQty_TextChanged"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Purchase Type</td>
                                       <td>
                                           <asp:DropDownList ID="ddlPurchaseType" runat="server" TabIndex="3">
                                               <asp:ListItem Value="D">Credit</asp:ListItem>
                                               <asp:ListItem Value="C">Cash</asp:ListItem>
                                               <asp:ListItem Value="Q">Cheque</asp:ListItem>
                                               <asp:ListItem Value="R">Credit Card</asp:ListItem>
                                           </asp:DropDownList>
                                           
                                       </td>
                                       <td>
                                           Rate</td>
                                       <td style="width: 339px">
                                           <asp:TextBox ID="txtRate" runat="server" Width="90px" AutoPostBack="True" 
                                                TabIndex="13"></asp:TextBox>
                                           Amount
                                           <asp:TextBox ID="txtAmount" runat="server" Width="90px" TabIndex="14"></asp:TextBox>
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Supplier Name</td>
                                       <td>
                                          <asp:DropDownList ID="ddlSupplierName" runat="server" onchange="ddlChange()" 
                                               Width="90px" TabIndex="4">
                                           </asp:DropDownList>
                                           <asp:TextBox ID="txtSupplierCode" runat="server" Width="90px" TabIndex="5"></asp:TextBox>
                                           </td>
                                           <td>
                                           Discount</td>
                                       <td style="width: 339px">
                                            <asp:TextBox ID="txtDiscount" runat="server" Width="90px" AutoPostBack="True" 
                                               TabIndex="15" Height="22px" ontextchanged="txtDiscount_TextChanged"></asp:TextBox>
                                          Total Amount
                                           <asp:TextBox ID="txtTotalAmount" runat="server" Width="90px" TabIndex="16"></asp:TextBox>
                                           </td>
                                   </tr>
                               
                                   <tr>
                                       <td>
                                           Description</td>
                                       <td>
                                           <asp:TextBox ID="txtDescription" runat="server" TabIndex="8"></asp:TextBox></td>
                                         <td>
                                           VAT Amount</td>
                                       <td style="width: 339px">
                                           <asp:TextBox ID="txtVatAmount" runat="server"  Width="90px" 
                                               TabIndex="19"></asp:TextBox>
                                          </td>
                                   </tr>
                                  
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                            <td>
                                           &nbsp;</td>
                                       <td style="width: 339px">
                                           <asp:Button ID="btnAddNew" runat="server" Text="Add"  CommandName="create" 
                                               TabIndex="28" onclick="btnAddNew_Click" />
                                           <asp:Button ID="btnAddOld" runat="server" Text="Add" Visible="false" 
                                                />
                                           </td>
                                           
                                   </tr>
                 </table>
                  <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                  <asp:Button ID="btnAddDataTable" runat="server" Text="Invoice Submit" Visible="false" 
                             onclick="btnAddDataTable_Click" />
                       <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                             GridLines="None" Width="420px" AutoGenerateColumns="False" 
                              ShowFooter="True" 
                             ForeColor="#333333" onrowdatabound="GridView1_RowDataBound">
                           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                           <Columns>
                               <asp:TemplateField HeaderText="VName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVName" runat="server" Text='<%# Eval("VName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                    </FooterTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sn">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSn" runat="server" Text='<%# Eval("Sn")%>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Item Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("Item Code")%>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalQty" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%# Eval("Rate")%>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Discount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisc" runat="server" Text='<%# Eval("Disc")%>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="VAT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVAT" runat="server" Text='<%# Eval("VAT")%>'></asp:Label>
                                    </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisTotalAmount" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblDisTotalAmt" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                               </asp:TemplateField>
                           </Columns>
                           <EditRowStyle BackColor="#999999" />
                           <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                           <SortedAscendingCellStyle BackColor="#E9E7E2" />
                           <SortedAscendingHeaderStyle BackColor="#506C8C" />
                           <SortedDescendingCellStyle BackColor="#FFFDF8" />
                           <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView> 
                     <asp:Panel ID="panelExtDis" runat="server" Visible="false">
                          Ext Dis:<asp:TextBox ID="txtExtDis" runat="server" ></asp:TextBox>
                         </asp:Panel>
                      </div>
               </div>
            </div>
                       
      <!--     <div class="col-lg-2">
                <div class="well">
                <asp:Panel ID="panelTreeView" runat="server" Visible="false">
                     <div class="row">
                    </div>
                </asp:Panel>
                   
                   </div>-->
                   
                </div>
            </div>
         
</asp:Content>

