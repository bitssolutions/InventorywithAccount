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
                //lblDetail.Text = "N";
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
            }
            else
            {
                loadFormView();
                lblMsg.Text = "";
            }

        }
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
        //parent, icode, iname, itype, ilevels, ucode, "E",isex,itname, crate, prate, srate, baseunit, minstock, maxstock, disctype, amount, vat, acode

        string parent = "", iname="", itype="",isex="", itname="",disctype="F", baseunit="", acode="";
        double crate,prate,srate, amount, vat;
        int ilevels, minstock, maxstock;
        string chkValue = TreeView1.SelectedNode.Value;
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');

        if (e.CommandName == "Edit")
        {
            if (Diff[3] == "Y")
            {
                FormView1.ChangeMode(FormViewMode.Edit);
                DataTable iteminfo = itemobj.LoadItemDetails(Diff[0]);
                if (iteminfo.Rows.Count > 0)
                {
                    FormView1.DataSource = iteminfo;
                    FormView1.DataBind();
                }
            }
            else
            {
                lblMsg.Text = "Master Account can't Edit.";
            }
        }

        if (e.CommandName == "edit")
        {
            ilevels = Convert.ToInt32(Diff[2]);
            // string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
            parent = DiffUpDt[0];
            itype = Diff[1];
            if (lblDetail.Text == "Y")
            {
                //TAdd = ((TextBox)FormView1.FindControl("txtEditTempAddress")).Text;
                //PAdd = ((TextBox)FormView1.FindControl("txtEditPermanentAddress")).Text;
                //CPerson = ((TextBox)FormView1.FindControl("txtEditConPerson")).Text;
                //Tel = ((TextBox)FormView1.FindControl("txtEditTelephone")).Text;
                //Mob = ((TextBox)FormView1.FindControl("txtEditMobile")).Text;
                //Email = ((TextBox)FormView1.FindControl("txtEditEmail")).Text;
                //Web = ((TextBox)FormView1.FindControl("txtEditWebPage")).Text;
                //Rem = ((TextBox)FormView1.FindControl("txtEditRemarks")).Text;
            }
            else
            {
                //TAdd = null;
                //PAdd = null;
                //CPerson = null;
                //Tel = null;
                //Mob = null;
                //Email = null;
                //Web = null;
                //Rem = null;
            }

           
            string icode = ((TextBox)FormView1.FindControl("txtEditAccountCode")).Text;
            iname = ((TextBox)FormView1.FindControl("txtEditAccountDescription")).Text;
            string ucode = Session["usercode"].ToString();
           // string msg = itemobj.AllItemRelated(parent, icode, iname, itype, ilevels, ucode, "E",isex,itname, crate, prate, srate, baseunit, minstock, maxstock, disctype, amount, vat, acode);

            //string chkmsg = help.Right(msg, 1);
            //if (chkmsg == "1")
            //{
            //    clearnloadformview(sender, e);
            //}
            //lblMsg.Text = help.Left(msg, msg.Length - 1);

        }

        if (e.CommandName == "cancel")
        {
            clearnloadformview(sender, e);
        }

        if (e.CommandName == "CreateItemGroup")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            DataTable accountinfo = itemobj.LoadItemDetails(Diff[0]);
            if (accountinfo.Rows.Count > 0)
            {
                FormView1.DataSource = accountinfo;
                FormView1.DataBind();
                lblMsg.Text = " ";
            }
        }


        if (e.CommandName == "CreateItemList")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            DataTable accountinfo = itemobj.LoadItemDetails(Diff[0]);
            if (accountinfo.Rows.Count > 0)
            {
                FormView1.DataSource = accountinfo;
                FormView1.DataBind();
                lblMsg.Text = " ";
            }
            
        }

        if (e.CommandName == "create")
        {
            if (Diff[1] == "A")
            {
                //string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
               // alevels = Convert.ToInt32(DiffUpDt[2]) + 1;
                parent = DiffUpDt[0];
            }
            else
            {
                //  string[] DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
               // alevels = Convert.ToInt32(Diff[2]) + 1;
                parent = Diff[0];
            }
            if (lblDetail.Text == "Y")
            {
                //TAdd = ((TextBox)FormView1.FindControl("txtNewTempAddress")).Text;
                //PAdd = ((TextBox)FormView1.FindControl("txtNewPermanentAddress")).Text;
                //CPerson = ((TextBox)FormView1.FindControl("txtNewConPerson")).Text;
                //Tel = ((TextBox)FormView1.FindControl("txtNewTelephone")).Text;
                //Mob = ((TextBox)FormView1.FindControl("txtNewMobile")).Text;
                //Email = ((TextBox)FormView1.FindControl("txtNewEmail")).Text;
                //Web = ((TextBox)FormView1.FindControl("txtNewWebPage")).Text;
                //Rem = ((TextBox)FormView1.FindControl("txtNewRemarks")).Text;

            }
            else
            {
                //TAdd = null;
                //PAdd = null;
                //CPerson = null;
                //Tel = null;
                //Mob = null;
                //Email = null;
                //Web = null;
                //Rem = null;
            }
           
           // atype = lblType.Text;
            DataTable accode = itemobj.generateMaxNumber("AC", "HO");
           // string acode = accode.Rows[0][0].ToString();
            //string acode = ((TextBox)FormView1.FindControl("txtNewAccountCode")).Text;
            string aname = ((TextBox)FormView1.FindControl("txtNewAccountDescription")).Text;
            string ucode = Session["usercode"].ToString();
            //string msg = itemobj.AllAccountRelated(parent, acode, aname, atype, alevels, owner, ucode, "I", lblDetail.Text, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem);

            //string chkmsg = help.Right(msg, 1);
            //if (chkmsg == "1")
            //{
            //    clearnloadformview(sender, e);
            //}
            //lblMsg.Text = help.Left(msg, msg.Length - 1);
        }

        if (e.CommandName == "Delete")
        {
            //alevels = Convert.ToInt32(Diff[2]);
            //atype = Diff[1];
            //parent = Diff[0];
            //TAdd = null;
            //PAdd = null;
            //CPerson = null;
            //Tel = null;
            //Mob = null;
            //Email = null;
            //Web = null;
            //Rem = null;
            //string acode = Diff[0];
            string aname = Diff[0];
            string ucode = Session["usercode"].ToString();
            //string msg = itemobj.AllAccountRelated(parent, acode, aname, atype, alevels, owner, ucode, "D", lblDetail.Text, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem);
            //string chkmsg = help.Right(msg, 1);
            //if (chkmsg == "1")
            //{
            //    clearnloadformview(sender, e);
            //}
            //lblMsg.Text = help.Left(msg, msg.Length - 1);
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

    
}