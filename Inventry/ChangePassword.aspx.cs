using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Change_Password : System.Web.UI.Page
{
    GeneralRelated ob = new GeneralRelated();
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
            string ePass = Helper.ComputeHash(txtNewPassword.Text, "SHA512", null);
            int i = ob.UpdateAdminTypeUser(txtUsername.Text, ePass);
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