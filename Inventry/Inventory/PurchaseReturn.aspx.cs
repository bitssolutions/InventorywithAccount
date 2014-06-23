using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DipeshNepaliDateConversion;
using System.Data;


public partial class Inventory_PurchaseReturn : System.Web.UI.Page
{
    Helper help = new Helper();
    MasterRelated obj = new MasterRelated();
    GeneralRelated generalobj = new GeneralRelated();
    Entry entryobj = new Entry();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = UppercaseFirst(Session["username"].ToString());
                txtNDate.Text = DipeshNepaliDateConverter.convertToBS(Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")));

                DataTable dtSource = new DataTable();

                dtSource.Columns.Add("VName");
                dtSource.Columns.Add("Sn");
                dtSource.Columns.Add("Item Code");
                dtSource.Columns.Add("Quantity");
                dtSource.Columns.Add("Rate");
                dtSource.Columns.Add("Disc");
                dtSource.Columns.Add("VAT");
                dtSource.Columns.Add("EDate");
                dtSource.Columns.Add("Owner");
                dtSource.Columns.Add("UserCode");
                ViewState["dtSource"] = dtSource;
                GridView1.DataSource = dtSource;
                GridView1.DataBind();
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
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        string icode = txtCode.Text;
        ddlistType.Visible = false;
        txtType.Visible = true;
        string owner = Session["dealer"].ToString();
        DataTable dt = obj.LoadItemDetails(icode);
        if (dt.Rows.Count>0)
        {
            txtType.Text = dt.Rows[0][8].ToString();
            txtName.Text = dt.Rows[0][9].ToString();
            if (owner=="HO")
            {
                txtRate.Text = dt.Rows[0][11].ToString(); 
            }
            else
            {
                txtRate.Text = dt.Rows[0][12].ToString(); 
            }
            
        }
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtRate.Text != "")
        {
            txtAmount.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text)).ToString();
        }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        double txtamt = Convert.ToDouble(txtAmount.Text);
        double txtdis = Convert.ToDouble(txtDiscount.Text);
        txtTotalAmount.Text = (txtamt - txtdis).ToString();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string icode, iname, itname, ucode, isex, owner, vat;
        double  prate,  amount, discount;
        int qty;

        icode = txtCode.Text;
        iname = txtName.Text;
        itname = txtName.Text;
        isex = ddlistType.Text;
        qty = Convert.ToInt32(txtQty.Text);
        discount = Convert.ToDouble(txtDiscount.Text);
        vat = txtVatAmount.Text; 
        prate = Convert.ToDouble(txtRate.Text);
        ucode = Session["usercode"].ToString();
        owner = Session["dealer"].ToString();

        amount = Convert.ToDouble(txtAmount.Text);
        
        DataTable dtSource = ViewState["dtSource"] as DataTable;

        DataRow dr = dtSource.NewRow();

        dr["VName"] = "PR";
        dr["Sn"] = txtInvoiceNo.Text;
        dr["Item Code"] = icode;
        dr["Quantity"] = qty;
        dr["Rate"] = prate;
        dr["Disc"] = discount;
        dr["VAT"] = vat;
        dr["EDate"] = DateTime.Today.ToShortDateString();
        dr["Owner"] = owner;
        dr["UserCode"] = ucode;
        dtSource.Rows.Add(dr);
        GridView1.DataSource = dtSource;
        GridView1.DataBind();
        btnAddDataTable.Visible = true;
        txtQty.Text = "";
        txtAmount.Text = "";
        panelExtDis.Visible = true;

    }

    decimal totalQty = 0M;
    decimal totalamt = 0;
    decimal totaldisamt = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty = (Label)e.Row.FindControl("lblQuantity");

            decimal qty = Decimal.Parse(lblqty.Text);

            totalQty += qty;

            Label ltlrate = (Label)e.Row.FindControl("lblRate");

            decimal rate = Decimal.Parse(ltlrate.Text);

            Label lblamt = (Label)e.Row.FindControl("lblAmount");
            lblamt.Text = Convert.ToString(rate * qty);

            totalamt += Convert.ToDecimal(lblamt.Text);

            Label lblDis = (Label)e.Row.FindControl("lblDisc");
            decimal dis = Decimal.Parse(lblDis.Text);


            Label lbmtotaldisamt = (Label)e.Row.FindControl("lblDisTotalAmount");

            lbmtotaldisamt.Text = (Convert.ToDecimal(lblamt.Text) - dis).ToString();

            totaldisamt += Convert.ToDecimal(lbmtotaldisamt.Text);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalQuantity = (Label)e.Row.FindControl("lblTotalQty");
            lblTotalQuantity.Text = totalQty.ToString();

            Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
            lblTotalAmount.Text = totalamt.ToString();

            Label lblDisTotalAmt = (Label)e.Row.FindControl("lblDisTotalAmt");
            lblDisTotalAmt.Text = totaldisamt.ToString();
        }
    }
  

    protected void btnAddDataTable_Click(object sender, EventArgs e)
    {
        DataTable TableInitial = (DataTable)ViewState["dtSource"];
        string hasnote, owner, ucode, acode, paytype, note;
        int vnum;
        double extdisc;
        DateTime edate;
        vnum = Convert.ToInt32(txtInvoiceNo.Text);
        edate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

        acode = txtSupplierCode.Text;

        paytype = ddlPurchaseType.Text;
        note = txtDescription.Text;
        owner = Session["dealer"].ToString();
        ucode = Session["usercode"].ToString();
        extdisc = Convert.ToDouble(txtExtDis.Text);
        if (txtDescription.Text == "" && txtDescription.Text == null)
        {
            hasnote = "N";
        }
        else
        {
            hasnote = "Y";
        }

        string msg = entryobj.PurchaseReturnI(vnum, owner, edate, ucode, acode, extdisc, hasnote, paytype, note, TableInitial);
        lblMsg.Text = msg;
        GridView1.DataSource = null;
        GridView1.DataBind();
        panelExtDis.Visible = false;
        btnAddDataTable.Visible = false;
    }
}