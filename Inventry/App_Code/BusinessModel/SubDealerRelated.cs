using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SubDealerRelated
/// </summary>
public class SubDealerRelated
{
    //subdealer related start
    public string AllSubDealerRelated(string code, string aname,string usercode, string status, string addt, string addp, string conperson, string telephone, string mobile, string email, string webpage, string remarks,string showif)
    {
        SqlParameter[] param = new SqlParameter[14];
        param[0] = new SqlParameter("@Code", code);
        param[1] = new SqlParameter("@AName", aname);
        param[2] = new SqlParameter("@UserCode", usercode);
        param[3] = new SqlParameter("@Status", status);
        param[4] = new SqlParameter("@AddT", addt);
        param[5] = new SqlParameter("@AddP", addp);
        param[6] = new SqlParameter("@ConPerson", conperson);
        param[7] = new SqlParameter("@Telephone", telephone);
        param[8] = new SqlParameter("@Mobile", mobile);
        param[9] = new SqlParameter("@Email", email);
        param[10] = new SqlParameter("@WebPage", webpage);
        param[11] = new SqlParameter("@Remarks", remarks);
        param[12] = new SqlParameter("@ShowIf", showif);
        param[13] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[13].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("SubDealearRelated", param);
        return (param[13].Value.ToString()).Trim();
    }


    public DataTable generateMaxNumber(string type, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", type);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("GenerateMaxNumber", param);
    }
    //subdealer related end

    // to load treeview structure
    public DataTable LoadSubDealerListTreeView(string parent, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("AccountListsTreeView", param);
    }
    //end load treeview structure

    //load subdealearinfo
    public DataTable LoadSubDealearDetails(string ucode, string type)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Code", ucode);
        param[1] = new SqlParameter("@Type", type);
        return DataAccessLayer.getTable("AccountInfo", param);
    }


    //end load subdealearinfo
}