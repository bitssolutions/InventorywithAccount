using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_ItemRelated : System.Web.UI.Page
{
    MasterRelated itemobj = new MasterRelated();
    GeneralRelated generalobj = new GeneralRelated();
    Helper help = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = UppercaseFirst(Session["username"].ToString());
                TreeView1.Nodes.Clear();
                AddTopTreeViewNodes();

                //loadFormView();
                
                //lblDetail.Text = "N";
            }
        }
        else
        {
            //Response.Redirect("../Error.aspx");
            Response.Redirect(GetRouteUrl("Error",null));
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
        string pcode = Request.QueryString["Products"].ToString();
        TreeNode newNodes = new TreeNode("Products", "G1-G-3");
        TreeView1.Nodes.Add(newNodes);
        TreeView1.Nodes[0].Selected = true;
        TreeView1.SelectedNode.ChildNodes.Clear();
        AddChildTreeViewNodes(pcode);
        TreeView1.ExpandAll();
        loadFormView();
        lblMsg.Text = "";

    }

    private void AddChildTreeViewNodes(string parentCode)
    {
        DataTable treeViewDatas = itemobj.LoadItemListTreeView(parentCode);
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

    public void loadFormView()
    {
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        DataTable iteminfo = itemobj.LoadItemDetails(Diff[0]);
        if (iteminfo.Rows.Count > 0)
        {
            FormView1.DataSource = iteminfo;
            FormView1.DataBind();
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //lblMsg.Text = GetFullValueOfTreeView();
        if (TreeView1.SelectedNode != null)
        {
            string[] Diff = TreeView1.SelectedNode.Value.Split('-');
            lblType.Text = Diff[1];
            if (Diff[1] == "G")
            {
                TreeView1.SelectedNode.ChildNodes.Clear();
                AddChildTreeViewNodes(Diff[0]);
                loadFormView();
                lblMsg.Text = "";
               // lblMsg.Text = TreeView1.SelectedNode.ValuePath;
            }
            else
            {
                loadFormView();
                lblMsg.Text = "";
                //lblMsg.Text =TreeView1.SelectedNode.ValuePath;
            }

        }
    }

    protected string GetFullValueOfTreeView()
    {
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        if (Diff[1]=="A")
        {
            TreeView1.SelectedNode.Parent.Selected = true;
        }
        TreeNode node = TreeView1.SelectedNode;
        String pathStr = node.Text;
        string separator = " ";

        TreeView1.PathSeparator = Convert.ToChar(separator);

        while (node.Parent != null)
        {
            pathStr = node.Parent.Text + TreeView1.PathSeparator + pathStr;
            node = node.Parent;
        }
        string itemroot="products ";
        return help.Right(pathStr,pathStr.Length-itemroot.Length );
    }

    
    protected void clearnloadformview(object sender, FormViewCommandEventArgs e)
    {
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        TreeView1_SelectedNodeChanged(sender, e);
    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        //this modechanging event should be fired before to perform add edit and deleted command.
       
    }

    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        string parent = "",icode, iname="", itype="",isex="", itname="",disctype="",baseunit="",scode="",vat="";
        double crate=0,prate=0,wrate=0,srate=0, amount=0;
        int ilevels, minstock=0, maxstock=0;

        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        string[] DiffUpDt;

        if (Diff[0] != Request.QueryString["Products"].ToString())
        {
            DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
        }
        else
        {
            DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
        }

        if (e.CommandName == "Edit")
        {
            FormView1.ChangeMode(FormViewMode.Edit);
            DataTable iteminfo = itemobj.LoadItemDetails(Diff[0]);
            if (iteminfo.Rows.Count > 0)
            {
                FormView1.DataSource = iteminfo;
                FormView1.DataBind();
            }   
        }

        if (e.CommandName == "edit")
        {
            // string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-'); 
            parent = DiffUpDt[0];
            icode = ((TextBox)FormView1.FindControl("txtEditCode")).Text;
            ilevels = Convert.ToInt32(Diff[2]);
            string ucode = Session["usercode"].ToString();
            itype = Diff[1];
            iname = ((TextBox)FormView1.FindControl("txtEditIName")).Text;

            if (Diff[1] == "A")                                                   //Diff[1] == "G"
            {
                isex = ((DropDownList)FormView1.FindControl("ddlEditSex")).Text;
                itname = ((TextBox)FormView1.FindControl("txtEditItName")).Text;
                crate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtEditCRate")).Text);
                prate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtEditPRate")).Text);
                srate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtEditSRate")).Text);
                wrate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtEditWRate")).Text);
                scode = ((TextBox)FormView1.FindControl("txtEditACode")).Text;
                baseunit = ((TextBox)FormView1.FindControl("txtEditBaseUnit")).Text;
                minstock = Convert.ToInt32(((TextBox)FormView1.FindControl("txtEditMinStock")).Text);
                maxstock = Convert.ToInt32(((TextBox)FormView1.FindControl("txtEditMaxStock")).Text);

            }
            else if(Diff[1]=="G")
            {
                isex = null;
                itname = null;
                crate = 0;
                prate = 0;
                srate = 0;
                wrate = 0;
                scode = null;
                baseunit = null;
                minstock = 0;
                maxstock = 0;

            }
            lblMsg.Text = itype;
            string msg = itemobj.AllItemRelated(parent, icode, iname, itype, ilevels, ucode, "E", isex, itname, crate, prate, srate, baseunit, minstock, maxstock, disctype, amount, vat, scode);

            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);

        }

        if (e.CommandName == "cancel")
        {
            clearnloadformview(sender, e);
        }

        if (e.CommandName == "CreateItemGroup")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            DataTable iteminfo = itemobj.LoadItemDetails(Diff[0]);
            if (iteminfo.Rows.Count > 0)
            {
                FormView1.DataSource = iteminfo;
                FormView1.DataBind();
                lblMsg.Text = " ";
                ((Label)FormView1.FindControl("lblProductGrp")).Visible = true;
            }
        }


        if (e.CommandName == "CreateItemList")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            DataTable iteminfo = itemobj.LoadItemDetails(Diff[0]);
            if (iteminfo.Rows.Count > 0)
            {
                FormView1.DataSource = iteminfo;
                FormView1.DataBind();
                lblMsg.Text = " ";
                ((Label)FormView1.FindControl("lblProductItm")).Visible = true;
            }
        }

        if (e.CommandName == "create")
        {
            if (Diff[1] == "A")
            {
                ilevels = Convert.ToInt32(DiffUpDt[2]) + 1;
                parent = DiffUpDt[0];
            }
            else
            {
                ilevels = Convert.ToInt32(Diff[2]) + 1;
                parent = Diff[0];
            }

            iname = ((TextBox)FormView1.FindControl("txtIsIName")).Text;
            itype = lblType.Text;
           
            if (lblType.Text == "G")
            {
                DataTable accode = generalobj.generateMaxNumber("IG", "HO");
                icode = accode.Rows[0][0].ToString();
            }
            else
            {
                DataTable accode = generalobj.generateMaxNumber("II", "HO");
                icode = accode.Rows[0][0].ToString();
                isex = ((DropDownList)FormView1.FindControl("ddlIsSex")).Text;
                itname = ((TextBox)FormView1.FindControl("txtIsItName")).Text;
                crate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtIsCRate")).Text);
                prate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtIsPRate")).Text);
                srate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtIsSRate")).Text);
                wrate = Convert.ToDouble(((TextBox)FormView1.FindControl("txtIsWRate")).Text);
                scode = ((TextBox)FormView1.FindControl("txtIsACode")).Text;
                baseunit = ((TextBox)FormView1.FindControl("txtIsBaseUnit")).Text;
                minstock = Convert.ToInt32(((TextBox)FormView1.FindControl("txtIsMinStock")).Text);
                maxstock = Convert.ToInt32(((TextBox)FormView1.FindControl("txtIsMaxStock")).Text);
               
                if (((RadioButton)FormView1.FindControl("rbdIsFlat")).Checked)
                {
                    disctype = "F";
                }
                else if (((RadioButton)FormView1.FindControl("rbdIsPercentage")).Checked)
                {
                    disctype = "P";
                }
                else if (((RadioButton)FormView1.FindControl("rbdIsNone")).Checked)
                {
                    disctype = "N";
                    amount = 0;
                }

                amount = Convert.ToDouble(((TextBox)FormView1.FindControl("txtIsAmount")).Text);

                if (((RadioButton)FormView1.FindControl("rbdIsVat")).Checked)
                {
                    vat = "V";
                }
                else if (((RadioButton)FormView1.FindControl("rbdIsNonVat")).Checked)
                {
                    vat = "N";
                }
            }
            
           
            string ucode = Session["usercode"].ToString();
            string msg = itemobj.AllItemRelated(parent, icode, iname, itype, ilevels, ucode, "I", isex,itname,crate,prate,srate,baseunit,minstock,maxstock,disctype,amount,vat,scode);

            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }

        if (e.CommandName == "Delete")
        {
            ilevels=0;
            parent =null;
            iname = null;
            itype = null;
            icode = Diff[0];
            isex = null;
            itname = null;
            crate = 0;
            prate = 0;
            srate = 0;
            wrate = 0;
            scode = null;
            baseunit =null;
            minstock =0;
            maxstock = 0;
            string ucode = Session["usercode"].ToString();
            string msg = itemobj.AllItemRelated(parent, icode, iname, itype, ilevels, ucode, "D", isex, itname, crate, prate, srate, baseunit, minstock, maxstock, disctype, amount, vat, scode);
            
            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }
    }


    protected void btnItemGroup_Click(object sender, EventArgs e)
    {
        lblType.Text = "G";
    }

    protected void btnItemList_Click(object sender, EventArgs e)
    {
        lblType.Text = "A";
        
    }

    
    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        //
    }

    protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {
        //
    }

    protected void txtIsIName_TextChanged(object sender, EventArgs e)
    {
        ((TextBox)FormView1.FindControl("txtIsItName")).Text = GetFullValueOfTreeView()+ " " + ((TextBox)FormView1.FindControl("txtIsIName")).Text;
    }
    protected void txtIsPRate_TextChanged(object sender, EventArgs e)
    {
        string purchaserate = ((TextBox)FormView1.FindControl("txtIsPRate")).Text;
        double wr = Convert.ToDouble(purchaserate);
        DataTable wholesalerate = itemobj.getWholeSaleRate(wr);
        ((TextBox)FormView1.FindControl("txtIsWRate")).Text = wholesalerate.Rows[0][0].ToString();

    }

    protected void txtEditIName_TextChanged(object sender, EventArgs e)
    {
        ((TextBox)FormView1.FindControl("txtEditItName")).Text = GetFullValueOfTreeView() + " " + ((TextBox)FormView1.FindControl("txtEditIName")).Text;
    }

    protected void txtEditPRate_TextChanged(object sender, EventArgs e)
    {
        string editpurchaserate = ((TextBox)FormView1.FindControl("txtEditPRate")).Text;
        double ewr = Convert.ToDouble(editpurchaserate);
        DataTable editwholesalerate = itemobj.getWholeSaleRate(ewr);
        ((TextBox)FormView1.FindControl("txtEditWRate")).Text = editwholesalerate.Rows[0][0].ToString();
    }
}