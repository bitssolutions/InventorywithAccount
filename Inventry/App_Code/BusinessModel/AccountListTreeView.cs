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
    
    public DataTable LoadAccountListTreeView(string parent,string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("AccountListsTreeView", param);
    }

}