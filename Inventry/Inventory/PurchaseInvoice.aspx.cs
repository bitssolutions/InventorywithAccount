using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DipeshNepaliDateConversion;
using System.Data;


public partial class Inventory_PurchaseInvoice : System.Web.UI.Page
{
    Helper help = new Helper();
    MasterRelated obj = new MasterRelated();
    GeneralRelated generalobj = new GeneralRelated();
    Entry entryobj = new Entry();
    Boolean ChkByNameOrCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        ChkByNameOrCode = false;
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = UppercaseFirst(Session["username"].ToString());
                TreeView1.Nodes.Clear();
                AddTopTreeViewNodes();
                txtNDate.Text = DipeshNepaliDateConverter.convertToBS(Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")));
                string owner = Session["dealer"].ToString();
                DataTable icode = generalobj.generateMaxNumber("II", owner);
                if (icode.Rows.Count > 0)
                {
                    txtCode.Text = icode.Rows[0][0].ToString();
                }

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

    private void AddTopTreeViewNodes()
    {
        string pcode = "G1";
        TreeNode newNodes = new TreeNode("Products", "G1-G-3");
        TreeView1.Nodes.Add(newNodes);
        TreeView1.Nodes[0].Selected = true;
        TreeView1.SelectedNode.ChildNodes.Clear();
        AddChildTreeViewNodes(pcode);
        TreeView1.ExpandAll();
        // loadFormView();
        lblMsg.Text = "";

    }

    private void AddChildTreeViewNodes(string parentCode)
    {
        DataTable treeViewDatas = obj.LoadItemListTreeView(parentCode, "G");
        if (treeViewDatas.Rows.Count > 0)
        {
            DataView view = new DataView(treeViewDatas);
            foreach (DataRowView row in view)
            {
                TreeNode newNodes = new TreeNode(row["IName"].ToString(), row["Diff"].ToString());
                TreeView1.SelectedNode.ChildNodes.Add(newNodes);
            }
            TreeView1.SelectedNode.Expand();   //to expand each child on click
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

        if (TreeView1.SelectedNode != null)
        {
            string[] Diff = TreeView1.SelectedNode.Value.Split('-');
            if (Diff[1] == "G")
            {
                TreeView1.SelectedNode.ChildNodes.Clear();
                AddChildTreeViewNodes(Diff[0]);
                //lblMsg.Text = TreeView1.SelectedNode.Text;
                txtGroup.Text = TreeView1.SelectedNode.Text;
                txtParentName.Text = TreeView1.SelectedNode.Text;

            }
            else
            {
                lblMsg.Text = "";
            }

        }
    }

    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        string icode = txtCode.Text;
        DataTable dt = obj.LoadItemDetails(icode);
        if (dt.Rows.Count > 0)
        {
            NewOrOldCode(true);
            MakeAddTextBoxEmpty(false, dt);
            panelTreeView.Visible = false;
            txtBoxReadOnly(true);
            btnAddNew.Visible = false;
            btnAddOld.Visible = true;
        }
        else
        {
            NewOrOldCode(false);
            MakeAddTextBoxEmpty(true, dt);
            txtBoxReadOnly(false);
            //panelTreeView.Visible = true;
            btnAddNew.Visible = true;
            btnAddOld.Visible = false;
        }
    }

    private void txtBoxReadOnly(Boolean TrueOrFalse) 
    {
        txtType.ReadOnly = TrueOrFalse;
        txtName.ReadOnly = TrueOrFalse;
        txtGroup.ReadOnly = TrueOrFalse;
        txtCRate.ReadOnly = TrueOrFalse;
        txtPurchaseRate.ReadOnly = TrueOrFalse;
        txtWholesaleRate.ReadOnly = TrueOrFalse;
        txtSalesRate.ReadOnly = TrueOrFalse;
        txtUnit.ReadOnly = TrueOrFalse;
       
    }

    private void NewOrOldCode(Boolean TrueOfFalse)
    {
        txtType.Visible = TrueOfFalse;
        ddlistType.Visible = !TrueOfFalse;
        txtUnit.Visible = TrueOfFalse;
        ddlUnit.Visible = !TrueOfFalse;
        txtIsUnit.Visible = !TrueOfFalse;
        levelDeatils.Visible = !TrueOfFalse;
    }

    private void MakeAddTextBoxEmpty(Boolean MakeTrue, DataTable dt)
    {
        if (MakeTrue == true)
        {
            txtType.Text = "";
            txtUnit.Text = "";
            if (ChkByNameOrCode==false)
            {
                txtName.Text = String.Empty;  
            }
            ChkByNameOrCode = false;
            txtGroup.Text = "";
            txtCRate.Text = "";
            txtPurchaseRate.Text = "";
            txtWholesaleRate.Text = "";
            txtSalesRate.Text = "";
        }
        else
        {
            txtType.Text = dt.Rows[0][8].ToString();
            txtUnit.Text = dt.Rows[0][14].ToString();
            txtName.Text = dt.Rows[0][4].ToString();
            txtGroup.Text = dt.Rows[0][9].ToString();
            txtCRate.Text = dt.Rows[0][10].ToString();
            txtPurchaseRate.Text = dt.Rows[0][11].ToString();
            txtWholesaleRate.Text = dt.Rows[0][12].ToString();
            txtSalesRate.Text = dt.Rows[0][13].ToString();
        }
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        ChkByNameOrCode = true;
        panelTreeView.Visible = true;
    }
    protected void btnNewGrp_Click(object sender, EventArgs e)
    {
        paneldetails.Visible = true;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void btnSaveGrp_Click(object sender, EventArgs e)
    {
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        string parent = Diff[0];
        int levels = Convert.ToInt32(Diff[2]) + 1;
        string ucode = Session["usercode"].ToString();
        string iname = txtGroupName.Text;

        string msg = obj.AllItemRelated(parent, "BR", iname, "G", levels, ucode, "I", "", "", 0, 0, 0, "", 0, 0, "", 0, "", "");

        string chkmsg = help.Right(msg, 1);
        if (chkmsg == "1")
        {
            paneldetails.Visible = false;
            AddChildTreeViewNodes(parent);
        }
        lblMsg.Text = help.Left(msg, msg.Length - 1);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        paneldetails.Visible = false;
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtPurchaseRate.Text!="")
        {
            txtAmount.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtPurchaseRate.Text)).ToString();
        }

    }
    protected void txtPurchaseRate_TextChanged(object sender, EventArgs e)
    {
        string purchaserate = txtPurchaseRate.Text;
        double wr = Convert.ToDouble(purchaserate);
        DataTable wholesalerate = obj.getWholeSaleRate(wr);
        txtWholesaleRate.Text = wholesalerate.Rows[0][0].ToString();

        if (txtQty.Text!="")
        {
            txtAmount.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtPurchaseRate.Text)).ToString();
        }
    }
    protected void rbdIsFlat_CheckedChanged(object sender, EventArgs e)
    {
        FlatPercentageVisible(true);
        lblFlat.Text = "Flat Amount";
    }
    protected void rbdIsPercentage_CheckedChanged(object sender, EventArgs e)
    {
        FlatPercentageVisible(true);
        lblFlat.Text = "Percentage Value";
    }
    protected void rbdIsNone_CheckedChanged(object sender, EventArgs e)
    {
        FlatPercentageVisible(false);
    }

    private void FlatPercentageVisible(Boolean TrueOfFalse)
    {
        lblFlat.Visible = TrueOfFalse;
        txtDFAmount.Visible = TrueOfFalse;
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string[] Diff = TreeView1.SelectedNode.Parent.Value.Split('-');
        string parent, icode, iname, itype, ucode, status, isex, itname,baseunit,disctype="",vat="",scode="",owner;
        double crate, prate, srate,amount,discount;
        int minstock, maxstock,ilevels,qty;
        parent = Diff[0];
        ilevels = Convert.ToInt32(Diff[2] + 1);
        itype = "A";
        qty = Convert.ToInt32(txtQty.Text);
        icode = txtCode.Text;
        iname = txtName.Text;
        discount = Convert.ToDouble(txtIsDiscount.Text);
        vat = txtIsVat.Text;
        ucode = Session["usercode"].ToString();
        owner = Session["dealer"].ToString();
        status = "I";
        isex = ddlistType.Text;
        itname = txtGroup.Text;
        baseunit = txtIsUnit.Text;
        scode = txtSupplierCode.Text;

        if (rbdIsFlat.Checked)
        {
            disctype = "F";
        }
        else if (rbdIsPercentage.Checked)
        {
            disctype = "P";
        }
        else if (rbdIsNone.Checked)
        {
            disctype = "N";
            amount = 0;
        }

        amount = Convert.ToDouble(txtDFAmount.Text);

        if (rbdIsVat.Checked)
        {
            vat = "V";
        }
        else if (rbdIsNonVat.Checked)
        {
            vat = "N";
        }

        crate = Convert.ToDouble(txtCRate.Text);
        prate = Convert.ToDouble(txtPurchaseRate.Text);
        srate = Convert.ToDouble(txtSalesRate.Text);
        minstock = Convert.ToInt32(txtIsMinStock.Text);
        maxstock = Convert.ToInt32(txtIsMaxStock.Text);

        string msg = obj.AllItemRelated(parent, icode, iname, itype, ilevels, ucode, status, isex, itname, crate, prate, srate, baseunit, minstock, maxstock, disctype, amount, vat, scode);

        string chkmsg = help.Right(msg, 1);
        if (chkmsg == "1")
        {
            //clearnloadformview(sender, e);
            DataTable dtSource = ViewState["dtSource"] as DataTable;

            DataRow dr = dtSource.NewRow();
            
            dr["VName"] = "PI";
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
            panelExtDis.Visible = true;
            
        }
        lblMsg.Text = help.Left(msg, msg.Length - 1);
    }
    protected void btnAddOld_Click(object sender, EventArgs e)
    {
        string icode, iname, itname, ucode, isex,  baseunit,owner,vat;
        double crate, prate, srate, amount,discount;
        int qty;
        icode = txtCode.Text;
        iname = txtName.Text;
        itname = txtGroup.Text;
        isex = ddlistType.Text;
        baseunit = txtUnit.Text;
        qty = Convert.ToInt32(txtQty.Text);
        discount = Convert.ToDouble(txtIsDiscount.Text);
        vat = txtIsVat.Text;
        crate = Convert.ToDouble(txtCRate.Text);
        prate = Convert.ToDouble(txtPurchaseRate.Text);
        srate = Convert.ToDouble(txtSalesRate.Text);
        ucode = Session["usercode"].ToString();
        owner=Session["dealer"].ToString();
        amount = Convert.ToDouble(txtAmount.Text);
       // string msg = obj.OpenItemRelated(icode, qty, rate, owner, ucode);

       // string chkmsg = help.Right(msg, 1);
      //  if (chkmsg == "1")
      //  {
            //clearnloadformview(sender, e);

            //loadOpenStockGrid();
            DataTable dtSource = ViewState["dtSource"] as DataTable;

            DataRow dr = dtSource.NewRow();
            
            dr["VName"] = "PI";
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

            //clearTextBoxs();

        

       // }
       // lblMsg.Text = help.Left(msg, msg.Length - 1);
    }

    public void clearTextBoxs()
    {
        
        txtType.Text = "";
        txtCode.Text = "";
        txtName.Text = "";
        txtGroup.Text = "";
        txtCRate.Text = "";
        txtPurchaseRate.Text = "";
        txtWholesaleRate.Text = "";
        txtSalesRate.Text = "";
        txtAmount.Text = "";
        txtUnit.Text = "";
        txtIsVat.Text = "";
        txtIsDiscount.Text = "";
        txtTotalAmount.Text = "";
    }
   
    protected void btnAddDataTable_Click(object sender, EventArgs e)
    {
        DataTable TableInitial = (DataTable)ViewState["dtSource"];
        string hasnote,owner,ucode,acode,paytype,note,bdate,billno;
        int vnum,extdisc;
        DateTime edate;
        vnum = Convert.ToInt32(txtInvoiceNo.Text);
        edate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
        
        acode = txtSupplierCode.Text;
        
        paytype = ddlPurchaseType.Text;
        note = txtDescription.Text;
        owner=Session["dealer"].ToString();
        ucode = Session["usercode"].ToString();
        bdate = txtSupplierBillDate.Text;
        billno = txtSupplierBill.Text;
        extdisc = Convert.ToInt32(txtExtDis.Text);
        if (txtDescription.Text=="" && txtDescription.Text==null)
	    {
		    hasnote="N";
	    }else
	    {
            hasnote="Y";
	    }
        string msg = entryobj.PurchaseInvoiceI(vnum, owner, edate, ucode, acode, extdisc, hasnote, paytype, note, TableInitial, bdate, billno);
       
        lblMsg.Text = msg;
        GridView1.DataSource = null;
        GridView1.DataBind();
        panelExtDis.Visible = false;
        btnAddDataTable.Visible = false;
      
    }

    decimal totalQty = 0M;
    decimal totalamt = 0;
    decimal totaldisamt = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
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

        if (e.Row.RowType==DataControlRowType.Footer)
        {
            Label lblTotalQuantity = (Label)e.Row.FindControl("lblTotalQty");
            lblTotalQuantity.Text = totalQty.ToString();

            Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
            lblTotalAmount.Text = totalamt.ToString();

            Label lblDisTotalAmt = (Label)e.Row.FindControl("lblDisTotalAmt");
            lblDisTotalAmt.Text = totaldisamt.ToString();
        }
    }
    protected void txtIsDiscount_TextChanged(object sender, EventArgs e)
    {
        double txtamt = Convert.ToDouble(txtAmount.Text);
        double txtdis = Convert.ToDouble(txtIsDiscount.Text);
        txtTotalAmount.Text = (txtamt - txtdis).ToString();
    }

   
}
