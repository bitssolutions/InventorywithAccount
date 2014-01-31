<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
        <link href="Resourses/dist/css/bootstap.min.css" rel="stylesheet" type="text/css" />
   
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        <script src="Resourses/dist/js/bootstrap.js" type="text/javascript"></script>
		<style>
		@font-face
			{
			font-family: myFirstFont;
			src: url('fonts/glyphicons-halflings-regular.ttf'),
				 url('fonts/glyphicons-halflings-regular.eot'); /* IE9 */
			} 
		body{
			padding-top: 135px;
			background-color: #DFE1E2;
		
			font-family: myFirstFont;
			
		}
			.box{
				height: 425px;
				width: 450px;
				margin-left:auto;
				margin-right:auto;
			}
			.well{
				background-image: url('Resourses/images/d.jpg');
				background-repeat: no-repeat;
				border: none;
				border-radius: 9px;
				box-shadow: 0px 0px 50px #7C908A;
			}
			input[type=text]
			{
				background: -webkit-radial-gradient(circle, #6FE6E8, #CFDFF2);
				background: -moz-radial-gradient(circle, #6FE6E8, #CFDFF2);
			}
			input[type=password]
			{
				background: -webkit-radial-gradient(circle, #6FE6E8, #CFDFF2);
				background: -moz-radial-gradient(circle, #6FE6E8, #CFDFF2);
			}
			.gradient1 h1 {
				font: bold 135%/100% "Lucida Grande", Arial, sans-serif;
				position: relative;
				margin: 15px 5px 6px;
				color: #012000;
			}
			.gradient1 h1 span {
				background: url('Resourses/images/gradient-white.png') repeat-x;
				position: absolute;
				display: block;
				width: 80%;
				height: 40px;
			}
			.textcolor
			{
			    color:Black;
		    }
		</style>
</head>
<body>
    <div class="container">
			<div class="row">
				<div class="box">
							<div class="well">
								<legend><div class="gradient1"><h1><span></span>Customer Registration</h1></div></legend>
								<form class="form-horizontal" role="form" id="form1" runat="server">
								  <div class="form-group">
									<label for="inputUsername" class="col-lg-4 control-label"><strong style="color: #666666;">Customer Name</strong></label>
									<div class="col-lg-8">
                                        <asp:TextBox ID="txtCustomerName" runat="server" class="form-control"></asp:TextBox>
									</div>
								  </div>
								  <div class="form-group">
									<label for="inputPassword1" class="col-lg-4 control-label"><strong style="color: #666666;">Password</strong></label>
									<div class="col-lg-8">
									  <asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox>
									</div>
								  </div>
								  <div class="form-group">
									<label for="inputPassword1" class="col-lg-4 control-label"><strong style="color: #666666;">Re-Password</strong></label>
									<div class="col-lg-8">
									  <asp:TextBox ID="txtRepassword" runat="server" class="form-control"></asp:TextBox>	
									</div>
								  </div>
								  
								  <div class="form-group">
									<label for="inputEmail" class="col-lg-4 control-label"><strong style="color: #666666;">Email Address</strong></label>
									<div class="col-lg-8">
									  <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>	
									</div>
								  </div><div class="form-group">
									<label for="inputMobile" class="col-lg-4 control-label"><strong style="color: #666666;">Mobile Number</strong></label>
									<div class="col-lg-8">
									  <asp:TextBox ID="txtMobile" runat="server" class="form-control"></asp:TextBox>	
									</div>
								  </div>
								  <div class="form-group">
									<div class="col-lg-offset-4 col-lg-10">
                                      <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                            class="btn btn-default" onclick="btnRegister_Click"/>
									  &nbsp;&nbsp;&nbsp;
                                      <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-default" 
                                            onclick="btnCancel_Click"/>
                                        <asp:Label ID="lblMsg" runat="server" Text="" class="textcolor"></asp:Label>
                                    </div>
								  </div>
								</form>
							</div>	
					</div><!--well-->
					
			</div><!--row-fluid-->
		</div><!--container--fluid-->
    
</body>
</html>
