<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="PurchaseInvoice.aspx.cs" Inherits="Inventory_PurchaseInvoice" %>

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
         <div class="col-lg-10">
               <div class="well">
                     <div class="row">
                                 <%
                                     MasterRelated itemobj = new MasterRelated();
                                 txtEDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                %>                                 <%
                                System.Data.DataTable dt = itemobj.getItemBaseUnit();
                                if (dt.Rows.Count > 0)
                                {
                                    ddlUnit.DataSource = dt;
                                    ddlUnit.DataTextField = "UnitS";
                                    ddlUnit.DataValueField = "UnitS";
                                    ddlUnit.DataBind();
                                    ddlUnit.Items.Insert(0, new ListItem("--Select--", "0"));

                                }
   
                              %>
                              
                               <%
                                  
                                 txtEDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                                %>

                               <%
                                System.Data.DataTable dtt = itemobj.getItemBaseUnit();
                                if (dtt.Rows.Count > 0)
                                {
                                    ddlUnit.DataSource = dtt;
                                    ddlUnit.DataTextField = "UnitS";
                                    ddlUnit.DataValueField = "UnitS";
                                    ddlUnit.DataBind();
                                    ddlUnit.Items.Insert(0, new ListItem("--Select--", "0"));

                                }
   
                              %>
                               
                               <script type="text/javascript">

                                   function ddlChange() {
                                       var ddl = document.getElementById('<%=(ddlSupplierName).ClientID %>');
                                       var textBox = document.getElementById('<%=(txtSupplierCode).ClientID%>');

                                       textBox.value = ddl.options[ddl.selectedIndex].value;
                                   }

                                   function ddlUnitChange() {
                                       var ddl = document.getElementById('<%=(ddlUnit).ClientID %>');
                                       var textBox = document.getElementById('<%=(txtIsUnit).ClientID%>');

                                       textBox.value = ddl.options[ddl.selectedIndex].value;
                                   }

                             </script>

                        <table style="width: 800px">
                                    <tr>
                                       <td>
                                           Invoice No</td>
                                       <td>
                                           <asp:TextBox ID="txtInvoiceNo" runat="server" Width="100px"></asp:TextBox></td>
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
                                               ontextchanged="txtCode_TextChanged" TabIndex="10" />
                                          
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
                                                    AutoPostBack="True" ontextchanged="txtName_TextChanged" TabIndex="11" />
                                        Group
                                       <asp:TextBox ID="txtGroup" runat="server" Width="90px" TabIndex="12"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Pay Type</td>
                                       <td>
                                           <asp:DropDownList ID="ddlPurchaseType" runat="server" TabIndex="3">
                                               <asp:ListItem Value="D">Credit</asp:ListItem>
                                               <asp:ListItem Value="C">Cash</asp:ListItem>
                                               <asp:ListItem Value="Q">Cheque</asp:ListItem>
                                               <asp:ListItem Value="R">Credit Card</asp:ListItem>
                                           </asp:DropDownList>
                                          
                                       </td>
                                       <td>
                                           Qty</td>
                                       <td style="width: 339px">
                                           <asp:TextBox ID="txtQty" runat="server" Width="90px" AutoPostBack="True" 
                                               ontextchanged="txtQty_TextChanged" TabIndex="13"></asp:TextBox>
                                           CRate
                                           <asp:TextBox ID="txtCRate" runat="server" Width="90px" TabIndex="14"></asp:TextBox>
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
                                           Purchase Rate</td>
                                       <td style="width: 339px">
                                            <asp:TextBox ID="txtPurchaseRate" runat="server" Width="90px" AutoPostBack="True" 
                                               ontextchanged="txtPurchaseRate_TextChanged" TabIndex="15" Height="22px"></asp:TextBox>
                                           Wholesale Rate
                                           <asp:TextBox ID="txtWholesaleRate" runat="server" Width="90px" TabIndex="16"></asp:TextBox>
                                           </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           Supplier Bill</td>
                                       <td>
                                            <asp:TextBox ID="txtSupplierBill" runat="server" Width="90px" TabIndex="6"></asp:TextBox>
                                           Date
                                           <asp:TextBox ID="txtSupplierBillDate" runat="server" Width="90px" TabIndex="7"></asp:TextBox>
                                           </td>
                                            <td>
                                           Sales Rate</td>
                                       <td style="width: 339px">
                                           <asp:TextBox ID="txtSalesRate" runat="server"  Width="90px" TabIndex="17"></asp:TextBox>
                                            Amount
                                            <asp:TextBox ID="txtAmount" runat="server"   Width="90px" TabIndex="18"></asp:TextBox>
                                           </td>
                                   
                                   </tr>
                                   <tr>
                                       <td>
                                           Description</td>
                                       <td>
                                           <asp:TextBox ID="txtDescription" runat="server" TabIndex="8"></asp:TextBox></td>
                                         <td>
                                           Unit</td>
                                       <td style="width: 339px">
                                           <asp:TextBox ID="txtUnit" runat="server" Visible="false" Width="90px" 
                                               TabIndex="19"></asp:TextBox>
                                           <asp:DropDownList ID="ddlUnit" runat="server" TabIndex="19" onchange="ddlUnitChange()" >
                                           </asp:DropDownList>
                                           <asp:TextBox ID="txtIsUnit" runat="server" Width="90px" TabIndex="20"></asp:TextBox>
                                           </td>
                                   </tr>
                                  
                         <asp:Panel ID="levelDeatils" runat="server">
                            
                            <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td><asp:Label runat="server" ID="minimumlevel">Minimun Level</asp:Label></td>
                                        <td style="width: 339px">
                                            <asp:TextBox ID="txtIsMinStock" runat="server" Width="200px" TabIndex="20"></asp:TextBox>
                                        </td>
                                   </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td><asp:Label runat="server" ID="maximumlevel">Maximum Level</asp:Label></td>
                                        <td style="width: 339px">
                                            <asp:TextBox ID="txtIsMaxStock" runat="server" Width="200px" TabIndex="21"></asp:TextBox>
                                        </td>
                                   </tr>
                                   
                                   <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label runat="server" ID="distype">Discount Type</asp:Label></td>
                                        <td>
                                             <asp:RadioButton ID="rbdIsFlat" runat="server" Text="Flat" Value="F" 
                                                 GroupName="DiscIsType" AutoPostBack="True" 
                                                 oncheckedchanged="rbdIsFlat_CheckedChanged" TabIndex="22" />
                                             <asp:RadioButton ID="rbdIsPercentage" runat="server" Text="Percentage" 
                                                 Value="P" GroupName="DiscIsType" AutoPostBack="True" 
                                                 oncheckedchanged="rbdIsPercentage_CheckedChanged" TabIndex="23"/>
                                             <asp:RadioButton ID="rbdIsNone" runat="server" Text="None" Value="N" 
                                                 GroupName="DiscIsType" AutoPostBack="True" 
                                                 oncheckedchanged="rbdIsNone_CheckedChanged" TabIndex="24" 
                                                 />
                                           
                                        </td>
                                    </tr>

                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblFlat"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtDFAmount" runat="server" Width="200px" TabIndex="25"></asp:TextBox>  
                                           
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label runat="server" ID="vatnonvat">VAT/None VAT</asp:Label></td></td>
                                        <td>
                                            <asp:RadioButton ID="rbdIsVat" runat="server" Text="VAT" Value="V" 
                                                GroupName="VatNonVat" TabIndex="26" />
                                            <asp:RadioButton ID="rbdIsNonVat" runat="server" Text="None VAT" Value="N" 
                                                GroupName="VatNonVat" TabIndex="27" />
                                           
                                        </td>
                                    </tr>
                         </asp:Panel>          
                      
                                 <tr>
                                       <td>
                                          &nbsp;</td>
                                       <td>
                                          &nbsp;
                                           </td>
                                           <td>
                                          VAT Amount
                                          </td>
                                       <td style="width: 339px">
                                            <asp:TextBox ID="txtIsVat" runat="server"  Width="90px" 
                                                TabIndex="21"></asp:TextBox>
                                           Discount
                                           <asp:TextBox ID="txtIsDiscount" runat="server"  Width="90px" TabIndex="22" 
                                                AutoPostBack="True" ontextchanged="txtIsDiscount_TextChanged"></asp:TextBox>
                                           </td>
                                   </tr>

                                    <tr>
                                       <td>
                                          &nbsp;</td>
                                       <td>
                                         &nbsp;
                                           </td>
                                           <td>
                                        Total Amount
                                       <td style="width: 339px">
                                            <asp:TextBox ID="txtTotalAmount"  runat="server" Width="90px" 
                                                TabIndex="23"></asp:TextBox>
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
                                               TabIndex="28" onclick="btnAddNew_Click"/>
                                           <asp:Button ID="btnAddOld" runat="server" Text="Add" Visible="false" 
                                               onclick="btnAddOld_Click" />
                                           </td>
                                          
                                   </tr>
                 </table>
                  <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                  <asp:Button ID="btnAddDataTable" runat="server" Text="Invoice Submit" Visible="false" 
                             onclick="btnAddDataTable_Click"/>
                       <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                             GridLines="None" Width="420px" AutoGenerateColumns="False" 
                             onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                             ForeColor="#333333">
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
                          Ext Dis:<asp:TextBox ID="txtExtDis" runat="server" AutoPostBack="True" ></asp:TextBox>
                             &nbsp;&nbsp; Total Amount:<asp:TextBox ID="txtAfterExtDisAmount" runat="server"></asp:TextBox>
                         </asp:Panel>

                        
                      </div>
               </div>
            </div>
                       
           <div class="col-lg-2">
                <div class="well">
                <asp:Panel ID="panelTreeView" runat="server" Visible="false">
                     <div class="row">
                        <asp:TreeView ID="TreeView1" runat="server" Target="_blank"  onselectednodechanged="TreeView1_SelectedNodeChanged" Width="151px">
                        </asp:TreeView>
                        <asp:Button ID="btnNewGrp" runat="server" Text="New" 
                             onclick="btnNewGrp_Click" TabIndex="29"  />
                         <asp:Button ID="btnOK" runat="server" 
                             Text="OK" onclick="btnOK_Click" TabIndex="30" />
                    </div>
                </asp:Panel>
                   
                    <asp:Panel ID="paneldetails" runat="server" Visible="false">
                        <div class="row">
                            Parent<asp:TextBox ID="txtParentName" runat="server" TabIndex="31"></asp:TextBox><br />
                            Group Name<asp:TextBox ID="txtGroupName" runat="server" TabIndex="32"></asp:TextBox><br />
                            <asp:Button ID="btnSaveGrp" runat="server" Text="Save" 
                                onclick="btnSaveGrp_Click" TabIndex="33" 
                                />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                onclick="btnCancel_Click" TabIndex="34" 
                                />
                        </div>
                    </asp:Panel>
                   
                   </div>
                   
                </div>
            </div>
         </div>
   </div>
</asp:Content>

