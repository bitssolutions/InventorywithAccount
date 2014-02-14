using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.IO;



public partial class UserLogin : System.Web.UI.Page
{
    UserRelated obj = new UserRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string password = Helper.ComputeHash(txtPassword.Text, "SHA512", null);

        DataTable dt = obj.CheckUserLogin(txtUsername.Text, txtPassword.Text);
        if (dt.Rows.Count > 0)
        {

            if (dt.Rows[0][3].ToString() == "A")
            {
                Session.Add("username", txtUsername.Text);
                Session.Add("password", txtPassword.Text);
                //string password = dt.Rows[0][2].ToString();
                if ((dt.Rows[0][1].ToString() == "Admin") || (dt.Rows[0][2].ToString() == "Admin"))
                {
                    Session.Add("usercode", dt.Rows[0][0].ToString());
                    Response.Redirect("~/ChangePassword.aspx");
                }
                else
                {
                    Session.Add("usercode", dt.Rows[0][0].ToString());
                    Response.Redirect(GetRouteUrl("Login", null));
                   // Response.Redirect("~/Inventory/Login.aspx"); //Inventory ma chirne
                }
            }
            else if (dt.Rows[0][3].ToString() == "U")
            {
                Session.Add("username", txtUsername.Text);
                Session.Add("password", txtPassword.Text);
                Session.Add("usercode", dt.Rows[0][0].ToString());
               // Response.Redirect("~/Inventory/Login.aspx");
                Response.Redirect(GetRouteUrl("Login", null));
            }
            else if (dt.Rows[0][3].ToString() == "R")
            {
                Session.Add("username", txtUsername.Text);
                Session.Add("password", txtPassword.Text);
                Session.Add("usercode", dt.Rows[0][0].ToString());
                lbmMessage.Text = "You can only access our web portal";

            }
        }
        else
        {
            lbmMessage.Text = "Username and Password doesn't exists!";
        }
        //string userexist = obj.CheckUserExists(txtUsername.Text, txtPassword.Text);
        //if (userexist.Length > 0)
        //{
        //    lbmMessage.Text = userexist;
        //    if (userexist.)
        //    {
                
        //    }
        //    //if (userexist.=="A")
        //    //{
                
        //    //}
        //}
        //else
        //{
        //    lbmMessage.Text = userexist;
        //}
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registration.aspx");
    }

    

   
}