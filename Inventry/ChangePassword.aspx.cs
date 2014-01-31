using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Change_Password : System.Web.UI.Page
{
    UserRelated obj = new UserRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                txtUsername.Text = Session["username"].ToString();
            }    
        }
        else 
        {
            Response.Redirect("Error.aspx");
        }
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text==txtConfirmPassword.Text)
        {
            int i = obj.UpdateAdminTypeUser(txtUsername.Text, txtNewPassword.Text);
            if (i>0)
            {
                Response.Redirect("~/UserLogin.aspx");

            }
            else
            {
                Response.Redirect("~/UserLogin.aspx");
            }
        }
        else
        {
            lblMsg.Text = "Password Mismatch..";
        }
    }
}