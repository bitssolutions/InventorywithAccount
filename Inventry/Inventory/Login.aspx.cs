using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_Login : System.Web.UI.Page
{
   
    GeneralRelated obj = new GeneralRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                txtUsername.Text = Session["username"].ToString();
                loadYearList();
                loadSubDealerList();
            }
           
        }
        else
        {
            //Response.Redirect("../Error.aspx");
            Response.Redirect(GetRouteUrl("Error",null));
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text=="")
        {
            lbmMessage.Text = "Password Missing..!"; Session.Add("username", txtUsername.Text);
        }
        else
        {
            Response.Redirect(GetRouteUrl("Dashboard", null));
            //Response.Redirect("Dashboard.aspx");
        }
    }

    public void loadYearList()
    {
        DataTable dt = obj.getAllYearLists();
        if (dt.Rows.Count>0)
        {
            ddlYearList.DataSource = dt;
            ddlYearList.DataTextField = "Years";
            ddlYearList.DataValueField = "Years";
            ddlYearList.DataBind();
            //ddlYearList.Items.Insert(0,new ListItem("--Select--","0"));
        }
    }

    public void loadSubDealerList()
    {
        string username = Session["username"].ToString();
        string password = Session["password"].ToString();
        DataTable dt = obj.getSubDealers(username, password);
        if (dt.Rows.Count>0)
        {
            ddlDealearList.DataSource = dt;
            ddlDealearList.DataTextField = "Name";
            ddlDealearList.DataValueField = "Dealer";
            ddlDealearList.DataBind();
            ddlDealearList.Items.Insert(0,new ListItem("--Select--","0"));
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserLogin.aspx");
        
    }
    protected void ddlDealearList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dealer = ddlDealearList.SelectedValue;
        Session.Add("dealer", dealer);
        //Session["dealer"] = dealer;

        string dealername = ddlDealearList.SelectedItem.Text;
        Session.Add("Name", dealername);
       // Session["Name"] = dealername;

    }
}