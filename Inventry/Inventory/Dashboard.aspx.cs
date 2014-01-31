using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_Dashboard : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = UppercaseFirst(Session["username"].ToString());
               // string patid = ViewState["patid"].ToString();
                //lblmsg.Text = Session["Name"].ToString();
            }
           
        }
        else
        {
            Response.Redirect("../Error.aspx");
        }
    }
    static string UppercaseFirst(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return string.Empty;
        }
        char[] a = username.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
}