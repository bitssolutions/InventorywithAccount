using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;



public partial class _Default : System.Web.UI.Page
{
    GeneralRelated obj = new GeneralRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    private void Cleartexbox()
    {
        txtCustomerName.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtRepassword.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtMobile.Text = string.Empty;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
         
        if (txtPassword.Text==txtRepassword.Text)
        {
            string ePass = Helper.ComputeHash(txtPassword.Text, "SHA512", null);

            int j = obj.RegisterCustomer(txtCustomerName.Text, ePass, txtEmail.Text, txtMobile.Text);
            if (j>0)
            {
                Cleartexbox();
                lblMsg.Text = "Registration Sucess..!!";
            }
        }
        else
        {
            lblMsg.Text = "Password Mismatch..!";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCustomerName.Text = "";
        txtPassword.Text = "";
        txtRepassword.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
    }

   
   
   
}