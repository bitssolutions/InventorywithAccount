<%@ Page Title="" Language="C#" MasterPageFile="~/Resourses/template/Main.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Inventory_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
			<div class="well">
				Welcome :
				
				<%--<p class="pull-right">Signed in as <a href="#">User</a></p>--%>
			    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
			</div>
		</div>
		<div class="container-fluid">
			<div class="row">
				<div class="col-lg-8">
					<div class="well">
					<div class="row">
						<div class="col-md-2">
							<a href="#">
								<center>
                                    <div class="big">
									    <h1 class="glyphicon glyphicon-user"></h1>
								    </div>
                                </center>				
							<p class="text-center">User</p></a>
						</div>
						<div class="col-md-2">
							<a href="#">
								<center><div class="big">
									<h1 class="glyphicon glyphicon-info-sign"></h1>
								</div>	</center>				
							<p class="text-center">Info</p></a>
							
						</div>
						<div class="col-md-2">
                            
							<img class="img-thumbnail" src="../Resourses/images/image.jpg" alt="My image" />
							
						</div>
						<div class="col-md-2">
							<img class="img-thumbnail" src="../Resourses/images/image.jpg" alt="My image" />
							
						</div>
						</div>
					</div>
				</div>
			</div>
		</div>
</asp:Content>

