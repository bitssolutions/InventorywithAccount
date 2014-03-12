﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link href="Resourses/dist/css/bootstap.min.css" rel="stylesheet" type="text/css" />
   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>
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
				width: 425px;
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
				font: bold 200%/100% "Lucida Grande", Arial, sans-serif;
				position: relative;
				margin: 15px 5px 6px;
				color: #012000;
			}
			
			.gradient1 h1 span {
				background: url('Resourses/images/gradient-white.png') repeat-x;
				position: absolute;
				display: block;
				width: 35%;
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
							<legend><div class="gradient1"><h1><span></span>Forgot Password</h1></div></legend>
								<form id="form1" runat="server" class="form-horizontal">
								  <div class="form-group">
									<label for="txtUsername" class="col-lg-3 control-label"><strong style="color: #666666;">Username</strong></label>
									<div class="col-lg-8">
									<div class="input-group">
										<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                      <asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox>
									  </div>
									</div>
								  </div>
								  <div class="form-group">
									<label for="txtNewPassword" class="col-lg-3 control-label"><strong style="color: #666666;">New Password</strong></label>
									<div class="col-lg-8">
										<div class="input-group">
										<span class="input-group-addon"><i class="glyphicon glyphicon-certificate"></i></span>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
									  </div>
									</div>
								  </div>
								
								  <div class="form-group">
									<div class="col-lg-offset-3 col-lg-10">
                                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
                                            class="btn btn-default" onclick="btnChangePassword_Click" 
                                             />
							 &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                            class="btn btn-default"  />
                                ><asp:Label ID="lbmMessage" runat="server" Text="" class="textcolor"></asp:Label>
                                   </div>
								  </div>
                                </form>
							</div>	<!--well-->
							</div>  <!--box-->
					
			</div><!--row-fluid-->
		</div><!--container--fluid-->

</body>
</html>