using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_Liabilities : System.Web.UI.Page
{
    AccountListTreeView obj = new AccountListTreeView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadliabilities();
        }
    }

    //public void loadliabilities()
    //{
    //    DataTable dt = obj.getLiabities();
    //    if (dt.Rows.Count > 0) 
    //    {
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //    }
    //}
}