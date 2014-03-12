using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_SubDealerCreate : System.Web.UI.Page
{
    
    MasterRelated subdealerobj = new MasterRelated();
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
        string pcode = Request.QueryString["SubDealer"].ToString();
        string pname = null;
        DataTable AcName = subdealerobj.LoadSubDealearDetails(pcode, "G");
        if (AcName.Rows.Count > 0)
        {
            pname = AcName.Rows[0][4].ToString();
        }
        TreeNode newNodes = new TreeNode(pname, pcode + "-G-3-N-N");
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
        DataTable treeViewDatas = subdealerobj.LoadSubDealerListTreeView(parentCode, Session["dealer"].ToString());
        if (treeViewDatas.Rows.Count > 0)
        {
            DataView view = new DataView(treeViewDatas);
            foreach (DataRowView row in view)
            {
                TreeNode newNodes = new TreeNode(row["AName"].ToString(), row["Diff"].ToString());
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

    public void loadFormView()
    {
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        DataTable accountinfo = subdealerobj.LoadSubDealearDetails(Diff[0], Diff[1]);
        if (accountinfo.Rows.Count > 0)
        {
            FormView1.DataSource = accountinfo;
            FormView1.DataBind();
           
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
        string  acode, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem, showif;
        string chkValue = TreeView1.SelectedNode.Value;
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');

        if (e.CommandName == "Edit")
        {
              FormView1.ChangeMode(FormViewMode.Edit);
                DataTable accountinfo = subdealerobj.LoadSubDealearDetails(Diff[0], "A");
                if (accountinfo.Rows.Count > 0)
                {
                    FormView1.DataSource = accountinfo;
                    FormView1.DataBind();
                }
        }

        if (e.CommandName == "edit")
        {
            acode = ((TextBox)FormView1.FindControl("txtEditAccountCode")).Text;
            string aname = ((TextBox)FormView1.FindControl("txtEditAccountDescription")).Text;
            TAdd = ((TextBox)FormView1.FindControl("txtEditTempAddress")).Text;
            PAdd = ((TextBox)FormView1.FindControl("txtEditPermanentAddress")).Text;
            CPerson = ((TextBox)FormView1.FindControl("txtEditConPerson")).Text;
            Tel = ((TextBox)FormView1.FindControl("txtEditTelephone")).Text;
            Mob = ((TextBox)FormView1.FindControl("txtEditMobile")).Text;
            Email = ((TextBox)FormView1.FindControl("txtEditEmail")).Text;
            Web = ((TextBox)FormView1.FindControl("txtEditWebPage")).Text;
            Rem = ((TextBox)FormView1.FindControl("txtEditRemarks")).Text;    
            string ucode = Session["usercode"].ToString();
            showif = lblShowIf.Text;
            string msg = subdealerobj.AllSubDealerRelated(acode, aname, ucode, "E", TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem,showif);

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

        if (e.CommandName == "CreateSubDealer")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            DataTable accountinfo = subdealerobj.LoadSubDealearDetails(Diff[0], "A");
            if (accountinfo.Rows.Count > 0)
            {
                FormView1.DataSource = accountinfo;
                FormView1.DataBind();
                lblMsg.Text = " ";
            }
        }

       
        if (e.CommandName == "create")
        {
            DataTable code = generalobj.generateMaxNumber("SD", "HO");
            acode = code.Rows[0][0].ToString();
            string aname = ((TextBox)FormView1.FindControl("txtNewAccountDescription")).Text;
            string ucode = Session["usercode"].ToString();
            TAdd = ((TextBox)FormView1.FindControl("txtNewTempAddress")).Text;
            PAdd = ((TextBox)FormView1.FindControl("txtNewPermanentAddress")).Text;
            CPerson = ((TextBox)FormView1.FindControl("txtNewConPerson")).Text;
            Tel = ((TextBox)FormView1.FindControl("txtNewTelephone")).Text;
            Mob = ((TextBox)FormView1.FindControl("txtNewMobile")).Text;
            Email = ((TextBox)FormView1.FindControl("txtNewEmail")).Text;
            Web = ((TextBox)FormView1.FindControl("txtNewWebPage")).Text;
            Rem = ((TextBox)FormView1.FindControl("txtNewRemarks")).Text;
            showif = lblShowIf.Text;
            string msg = subdealerobj.AllSubDealerRelated(acode, aname, ucode, "I", TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem, showif);

            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }

        if (e.CommandName == "Delete")
        {
            TAdd = null;
            PAdd = null;
            CPerson = null;
            Tel = null;
            Mob = null;
            Email = null;
            Web = null;
            Rem = null;
            string aname = Diff[0];
            acode = Diff[0];
            string ucode = Session["usercode"].ToString();
            showif = lblShowIf.Text;
            string msg = subdealerobj.AllSubDealerRelated(acode, aname, ucode, "D", TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem, showif);
            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }
    }


   



    protected void chkIsShowIf_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)FormView1.FindControl("chkIsShowIf")).Checked)
        {
            lblShowIf.Text = "Y";
        }
        else
        {
            lblShowIf.Text = "N";
        }

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