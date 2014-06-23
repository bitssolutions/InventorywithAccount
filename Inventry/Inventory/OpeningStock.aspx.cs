using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Inventory_OpeningStock : System.Web.UI.Page
{
    MasterRelated obj = new MasterRelated();
    Helper help = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = UppercaseFirst(Session["username"].ToString());
                //lblDetail.Text = "N";
                DataTable dtSource = new DataTable();
                dtSource.Columns.Add("Item Code");
                dtSource.Columns.Add("Quantity");
                dtSource.Columns.Add("Rate");
                dtSource.Columns.Add("Owner");
                dtSource.Columns.Add("UserCode");
                ViewState["dtSource"] = dtSource;
                GridView1.DataSource = dtSource;
                GridView1.DataBind();
            }
        }
        else
        {
            Response.Redirect(GetRouteUrl("Error", null));
            //Response.Redirect("../Error.aspx");
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

    protected void txtNewItemCode_TextChanged(object sender, EventArgs e)
    {
        string icode = ((TextBox)FormView1.FindControl("txtNewItemCode")).Text;
        DataTable dt = obj.OpenItemInfo(Session["dealer"].ToString(), icode);
        if (dt.Rows.Count>0)
        {
            ((TextBox)FormView1.FindControl("txtNewItemName")).Text = dt.Rows[0][2].ToString();
            ((TextBox)FormView1.FindControl("txtNewSupplier")).Text = dt.Rows[0][5].ToString()+" ("+ dt.Rows[0][4].ToString()+")";
            ((TextBox)FormView1.FindControl("txtNewItemType")).Text = dt.Rows[0][1].ToString();
            ((TextBox)FormView1.FindControl("txtPreviousStock")).Text = dt.Rows[0][7].ToString();
            ((TextBox)FormView1.FindControl("txtNewRate")).Text = dt.Rows[0][6].ToString();
        }
    }

    

    protected void clearnloadformview(object sender, FormViewCommandEventArgs e)
    {
        FormView1.ChangeMode(FormViewMode.Insert);
        ((TextBox)FormView1.FindControl("txtNewItemCode")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtNewItemName")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtNewSupplier")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtNewItemType")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtPreviousStock")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtNewRate")).Text = string.Empty;
        ((TextBox)FormView1.FindControl("txtNewOpeningStock")).Text = string.Empty;
    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        //only fired for crud operation
    }

    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        string icode, owner, ucode;
        double qty, rate;
        if (e.CommandName == "create")
        {
            icode = ((TextBox)FormView1.FindControl("txtNewItemCode")).Text;
            qty = Convert.ToDouble(((TextBox)FormView1.FindControl("txtNewOpeningStock")).Text);
            rate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtNewRate")).Text);
            owner = ((TextBox)FormView1.FindControl("txtNewDealerName")).Text;
            ucode = Session["usercode"].ToString();
            string msg = obj.OpenItemRelated(icode, qty, rate, owner, ucode);

            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
               
                //loadOpenStockGrid();
                DataTable dtSource = ViewState["dtSource"] as DataTable;

                DataRow dr = dtSource.NewRow();
                dr["Item Code"] = icode;
                dr["Quantity"] = qty;
                dr["Rate"] = rate;
                dr["Owner"] = owner;
                dr["UserCode"] = ucode;
                dtSource.Rows.Add(dr);
                GridView1.DataSource = dtSource;
                GridView1.DataBind();

                
 

            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }

        if (e.CommandName == "cancel")
        {
            clearnloadformview(sender, e);
        }
    }
    protected void ddlListIsSupllier_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)FormView1.FindControl("txtNewDealerName")).Text = ((DropDownList)FindControl("ddlListIsSupllier")).SelectedValue;
        //((DropDownList)FindControl("ddlListIsSupllier")).SelectedIndex = ;
    }
}