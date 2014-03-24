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
    GeneralRelated obj = new GeneralRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        DataTable dt = obj.CheckUserName(txtUsername.Text);
        if (dt.Rows.Count > 0)
        {
            string uid = dt.Rows[0][1].ToString();
            string pwd = dt.Rows[0][2].ToString();
            bool flag = Helper.VerifyHash(txtPassword.Text, "SHA512", pwd);
            if (uid == txtUsername.Text && flag == true)
            {
                if (dt.Rows[0][3].ToString() == "A")
                {
                    Session.Add("username", txtUsername.Text);
                    Session.Add("password", pwd);
                    //string password = dt.Rows[0][2].ToString();
                    if ((dt.Rows[0][1].ToString() == "Admin") || (dt.Rows[0][2].ToString() == "Admin"))
                    {
                        Session.Add("usercode", dt.Rows[0][0].ToString());
                        Response.Redirect("~/ChangePassword.aspx");
                    }
                    else
                    {
                        Session.Add("usercode", dt.Rows[0][0].ToString());
                       // Response.Redirect(GetRouteUrl("Login", null));
                         Response.Redirect("~/Inventory/Login.aspx"); //Inventory ma chirne
                    }
                }
                else if (dt.Rows[0][3].ToString() == "U")
                {
                    Session.Add("username", txtUsername.Text);
                    Session.Add("password", pwd);
                    Session.Add("usercode", dt.Rows[0][0].ToString());
                    Response.Redirect("~/Inventory/Login.aspx");
                   // Response.Redirect(GetRouteUrl("Login", null));
                }
                else if (dt.Rows[0][3].ToString() == "R")
                {
                    Session.Add("username", txtUsername.Text);
                    Session.Add("password", pwd);
                    Session.Add("usercode", dt.Rows[0][0].ToString());
                    lbmMessage.Text = "You can only access our web portal";

                }
            }
            else
            {
                lbmMessage.Text = "Username and Password Mismatch!";
            }
        }
        
        //DataTable dt = obj.CheckUserLogin(txtUsername.Text, txtPassword.Text);

        //if (dt.Rows.Count > 0)
        //{

        //    if (dt.Rows[0][3].ToString() == "A")
        //    {
        //        Session.Add("username", txtUsername.Text);
        //        Session.Add("password", txtPassword.Text);
        //        //string password = dt.Rows[0][2].ToString();
        //        if ((dt.Rows[0][1].ToString() == "Admin") || (dt.Rows[0][2].ToString() == "Admin"))
        //        {
        //            Session.Add("usercode", dt.Rows[0][0].ToString());
        //            Response.Redirect("~/ChangePassword.aspx");
        //        }
        //        else
        //        {
        //            Session.Add("usercode", dt.Rows[0][0].ToString());
        //            Response.Redirect(GetRouteUrl("Login", null));
        //            // Response.Redirect("~/Inventory/Login.aspx"); //Inventory ma chirne
        //        }
        //    }
        //    else if (dt.Rows[0][3].ToString() == "U")
        //    {
        //        Session.Add("username", txtUsername.Text);
        //        Session.Add("password", txtPassword.Text);
        //        Session.Add("usercode", dt.Rows[0][0].ToString());
        //        // Response.Redirect("~/Inventory/Login.aspx");
        //        Response.Redirect(GetRouteUrl("Login", null));
        //    }
        //    else if (dt.Rows[0][3].ToString() == "R")
        //    {
        //        Session.Add("username", txtUsername.Text);
        //        Session.Add("password", txtPassword.Text);
        //        Session.Add("usercode", dt.Rows[0][0].ToString());
        //        lbmMessage.Text = "You can only access our web portal";

        //    }
        //}
        //else
        //{
        //    lbmMessage.Text = "Username and Password doesn't exists!";
        //}
       
    }
    
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registration.aspx");
    }




   
}