using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AccountListTreeView
/// </summary>
public class AccountListTreeView
{
    
    public DataTable getAssets(string parent,string owner)
    {
        //string parent = "AT1";
       // string owner = "U0001";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("AccountListsTreeView", param);
    }

    public DataTable getLiabities(string parent)
    {
        //string parent = "LL1";
        string owner = "HO";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("AccountListsTreeView", param);
    }

   
}