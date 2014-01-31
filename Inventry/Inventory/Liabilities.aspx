<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="Liabilities.aspx.cs" Inherits="Inventory_Liabilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container-fluid">
        <div class="well">
             <asp:Label ID="Label1" runat="server" Text="WelCome"></asp:Label>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
               <div class="well">
                    <div class="row">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" Width="299px" 
                            >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCode" Text='<%#Eval("Code") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Liabilities">
                                    <ItemTemplate>
                                        <%#Eval("AName") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLiabilitiesEdit" runat="server" Text='<%#Eval("AName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowEditButton="True" />
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                   <br />

                    </div>
               </div>
            </div>
        </div>
    </div>
</asp:Content>

