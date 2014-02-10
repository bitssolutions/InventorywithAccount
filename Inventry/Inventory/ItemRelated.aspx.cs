using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_ItemRelated : System.Web.UI.Page
{
    ItemRealted itemobj = new ItemRealted();
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
        //string pname = null;
        //DataTable AcName = subdealerobj.LoadSubDealearDetails(pcode, "G");
        //if (AcName.Rows.Count > 0)
        //{
        //    pname = AcName.Rows[0][4].ToString();
        //}
       // TreeNode newNodes = new TreeNode(pname, pcode + "-G-3-N-N");
        TreeNode newNodes = new TreeNode("Products", "G1-G-3");
        TreeView1.Nodes.Add(newNodes);
        TreeView1.Nodes[0].Selected = true;
        TreeView1.SelectedNode.ChildNodes.Clear();
        AddChildTreeViewNodes(pcode);
        TreeView1.ExpandAll();
        //loadFormView();
       // lblMsg.Text = "";

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
}