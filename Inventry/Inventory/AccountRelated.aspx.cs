﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Inventory_AccountRelated : System.Web.UI.Page
{

    MasterRelated accountobj = new MasterRelated();
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
            Response.Redirect(GetRouteUrl("Error",null));
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
        string pcode = Request.QueryString["Account"].ToString();
        string pname=null;
        DataTable AcName = accountobj.LoadAccountDetails(pcode, "G");
        if (AcName.Rows.Count>0)
        {
            pname = AcName.Rows[0][4].ToString();
        }
        TreeNode newNodes = new TreeNode(pname, pcode + "-G-3-N-N");

        //TreeNode newNodes = new TreeNode("Products", "G1-G-3");
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
        DataTable treeViewDatas = accountobj.LoadAccountListTreeView(parentCode, Session["dealer"].ToString());
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
            lblType.Text = Diff[1];
            lblIsDetail.Text = Diff[4];
            if (Diff[1] == "G")
            {
                //string aname = ((TextBox)FormView1.FindControl("txtEditAccountDescription")).Text;
                TreeView1.SelectedNode.ChildNodes.Clear();
                AddChildTreeViewNodes(Diff[0]);
                loadFormView();
                lblMsg.Text = "";
            }
            else
            {
                //string aname = ((TextBox)FormView1.FindControl("txtEditAccountDescription")).Text;
                loadFormView();
                lblMsg.Text = "";
            }

        }
    }

    public void loadFormView()
    {
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');
        DataTable accountinfo = accountobj.LoadAccountDetails(Diff[0], Diff[1]);
        if (accountinfo.Rows.Count > 0)
        {
            FormView1.DataSource = accountinfo;
            FormView1.DataBind();
            //if (accountinfo.Rows[0][7].ToString() == "Comm")
            //{
            //    ((RadioButton)FormView1.FindControl("rbdCommon")).Checked = true;
            //}
            //else if (accountinfo.Rows[0][7].ToString() == "Sub")
            //{
            //    ((RadioButton)FormView1.FindControl("rbdSubDealer")).Checked = true;
            //}
            //else
            //{
            //    ((RadioButton)FormView1.FindControl("rbdIndividual")).Checked = true;
            //}
            if (Diff[4] == "Y")
            {
                lblDetail.Text = "Y";
            }
            else
            {
                lblDetail.Text = "N";
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
        string atype = "", parent = "", owner = "", TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem;
        string[] DiffUpDt;
        int alevels;
        string chkValue = TreeView1.SelectedNode.Value;
        string[] Diff = TreeView1.SelectedNode.Value.Split('-');

        if (Diff[0]!=Request.QueryString["Account"].ToString())
        {
            DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
        }
        else
        {
            DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
        }

        if (e.CommandName == "Edit")
        {
            if (Diff[3] == "Y")
            {
                FormView1.ChangeMode(FormViewMode.Edit);
                DataTable accountinfo = accountobj.LoadAccountDetails(Diff[0], "A");
                if (accountinfo.Rows.Count > 0)
                {
                    FormView1.DataSource = accountinfo;
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
            alevels = Convert.ToInt32(Diff[2]);
           // string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
            parent = DiffUpDt[0];
            atype = Diff[1];
            if (lblDetail.Text == "Y")
            {
                TAdd = ((TextBox)FormView1.FindControl("txtEditTempAddress")).Text;
                PAdd = ((TextBox)FormView1.FindControl("txtEditPermanentAddress")).Text;
                CPerson = ((TextBox)FormView1.FindControl("txtEditConPerson")).Text;
                Tel = ((TextBox)FormView1.FindControl("txtEditTelephone")).Text;
                Mob = ((TextBox)FormView1.FindControl("txtEditMobile")).Text;
                Email = ((TextBox)FormView1.FindControl("txtEditEmail")).Text;
                Web = ((TextBox)FormView1.FindControl("txtEditWebPage")).Text;
                Rem = ((TextBox)FormView1.FindControl("txtEditRemarks")).Text;
            }
            else
            {
                TAdd = null;
                PAdd = null;
                CPerson = null;
                Tel = null;
                Mob = null;
                Email = null;
                Web = null;
                Rem = null;
            }

            if (((RadioButton)FormView1.FindControl("rbdEditCommon")).Checked)
            {
                owner = "Comm";
            }
            else if (((RadioButton)FormView1.FindControl("rbdEditSubDealer")).Checked)
            {
                owner = "Sub";
            }
            else
            {
                owner = Session["dealer"].ToString();
            }
            string acode = ((TextBox)FormView1.FindControl("txtEditAccountCode")).Text;
            string aname = ((TextBox)FormView1.FindControl("txtEditAccountDescription")).Text;
            string ucode = Session["usercode"].ToString();
            string msg = accountobj.AllAccountRelated(parent, acode, aname, atype, alevels, owner, ucode, "E", lblDetail.Text, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem);

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

        if (e.CommandName == "AcGrp")
        {
          //  string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
            if (Diff[1] == "A" && DiffUpDt[0] == "SB1") 
            {
                
                //if (DiffUpDt[0]=="SB1")
                //{
                    lblMsg.Text = "SubDealer Should be Created by (Master-SubDealerCreate) Menu";
                //}
              
            }
            else if (Diff[1] == "G" && Diff[0] == "SB1")
            {
                //if (Diff[0]=="SB1")
                //{
                    lblMsg.Text = "SubDealer Should be Created by (Master-SubDealerCreate) Menu";
                //}
              
            }
            else
            {
                FormView1.ChangeMode(FormViewMode.Insert);
                DataTable accountinfo = accountobj.LoadAccountDetails(Diff[0], "A");
                if (accountinfo.Rows.Count > 0)
                {
                    FormView1.DataSource = accountinfo;
                    FormView1.DataBind();
                    lblMsg.Text = " ";
                }
            }
        }

        if (e.CommandName == "AcHead")
        {
           // string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
            if (Diff[1] == "A" && DiffUpDt[0] == "SB1") 
            {
                
                //if (DiffUpDt[0]=="SB1")
                //{
                    lblMsg.Text = "SubDealer Should be Created by (Master-SubDealerCreate) Menu";
                //}
               
            }
            else if (Diff[1] == "G" && Diff[0] == "SB1")
            {
                //if (Diff[0]=="SB1")
                //{
                    lblMsg.Text = "SubDealer Should be Created by (Master-SubDealerCreate) Menu";
                //}
               
             
            }
            else
            {
                FormView1.ChangeMode(FormViewMode.Insert);
                DataTable accountinfo = accountobj.LoadAccountDetails(Diff[0], "A");
                if (accountinfo.Rows.Count > 0)
                {
                    FormView1.DataSource = accountinfo;
                    FormView1.DataBind();
                    lblMsg.Text = " ";
                }
            }
        }

        if (e.CommandName == "create")
        {
            if (Diff[1] == "A")
            {
                //string[] DiffUpDt = TreeView1.SelectedNode.Parent.Value.Split('-');
                alevels = Convert.ToInt32(DiffUpDt[2]) + 1;
                parent = DiffUpDt[0];
            }
            else
            {
              //  string[] DiffUpDt = TreeView1.SelectedNode.Value.Split('-');
                alevels = Convert.ToInt32(Diff[2]) + 1;
                parent = Diff[0];
            }
            if (lblDetail.Text == "Y")
            {
                TAdd = ((TextBox)FormView1.FindControl("txtNewTempAddress")).Text;
                PAdd = ((TextBox)FormView1.FindControl("txtNewPermanentAddress")).Text;
                CPerson = ((TextBox)FormView1.FindControl("txtNewConPerson")).Text;
                Tel = ((TextBox)FormView1.FindControl("txtNewTelephone")).Text;
                Mob = ((TextBox)FormView1.FindControl("txtNewMobile")).Text;
                Email = ((TextBox)FormView1.FindControl("txtNewEmail")).Text;
                Web = ((TextBox)FormView1.FindControl("txtNewWebPage")).Text;
                Rem = ((TextBox)FormView1.FindControl("txtNewRemarks")).Text;

            }
            else
            {
                TAdd = null;
                PAdd = null;
                CPerson = null;
                Tel = null;
                Mob = null;
                Email = null;
                Web = null;
                Rem = null;
            }
            if (((RadioButton)FormView1.FindControl("rbdNewCommon")).Checked == true)
            {
                owner = "Comm";
            }
            else if (((RadioButton)FormView1.FindControl("rbdNewSubDealer")).Checked == true)
            {
                owner = "Sub";
            }
            else
            {
                owner = Session["dealer"].ToString();
            }
            atype = lblType.Text;
            DataTable accode = generalobj.generateMaxNumber("AC", "HO");
            string acode = accode.Rows[0][0].ToString();
            //string acode = ((TextBox)FormView1.FindControl("txtNewAccountCode")).Text;
            string aname = ((TextBox)FormView1.FindControl("txtNewAccountDescription")).Text;
            string ucode = Session["usercode"].ToString();
            string msg = accountobj.AllAccountRelated(parent, acode, aname, atype, alevels, owner, ucode, "I", lblDetail.Text, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem);

            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }

        if (e.CommandName == "Delete")
        {
            alevels = Convert.ToInt32(Diff[2]);
            atype = Diff[1];
            parent = Diff[0];
            TAdd = null;
            PAdd = null;
            CPerson = null;
            Tel = null;
            Mob = null;
            Email = null;
            Web = null;
            Rem = null;
            string acode = Diff[0];
            string aname = Diff[0];
            string ucode = Session["usercode"].ToString();
            string msg = accountobj.AllAccountRelated(parent, acode, aname, atype, alevels, owner, ucode, "D", lblDetail.Text, TAdd, PAdd, CPerson, Tel, Mob, Email, Web, Rem);
            string chkmsg = help.Right(msg, 1);
            if (chkmsg == "1")
            {
                clearnloadformview(sender, e);
            }
            lblMsg.Text = help.Left(msg, msg.Length - 1);
        }
    }


    protected void btnAgHead_Click(object sender, EventArgs e)
    {
        lblType.Text = "G";
    }

    protected void btnAcHead_Click(object sender, EventArgs e)
    {
        lblType.Text = "A";
    }

    protected void chkIsDetail_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)FormView1.FindControl("chkIsDetail")).Checked == true)
        {
            lblDetail.Text = "Y";
        }
        else
        {
            lblDetail.Text = "N";
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