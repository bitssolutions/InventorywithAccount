using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AccountRelated
/// </summary>
public class AccountRelated
{
    public string AllAccountRelated(string parent,string code,string aname,string type,int levels,string owner,string usercode,string status,string detailvalues,string addt,string addp,string conperson,string telephone,string mobile,string email,string webpage,string remarks)
    {
        SqlParameter[] param = new SqlParameter[18];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Code", code);
        param[2] = new SqlParameter("@AName", aname);
        param[3] = new SqlParameter("@Type", type);
        param[4] = new SqlParameter("@Levels", levels);
        param[5] = new SqlParameter("@Owner", owner);
        param[6] = new SqlParameter("@UserCode", usercode);
        param[7] = new SqlParameter("@Status", status);
        param[8] = new SqlParameter("@IsDetail", detailvalues);
        param[9] = new SqlParameter("@AddT", addt);
        param[10] = new SqlParameter("@AddP", addp);
        param[11] = new SqlParameter("@ConPerson", conperson);
        param[12] = new SqlParameter("@Telephone", telephone);
        param[13] = new SqlParameter("@Mobile", mobile);
        param[14] = new SqlParameter("@Email", email);
        param[15] = new SqlParameter("@WebPage", webpage);
        param[16] = new SqlParameter("@Remarks", remarks);
        param[17] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar,254);
        param[17].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("AccountRelated", param);
        return (param[17].Value.ToString()).Trim();
    }

   
    public DataTable generateMaxNumber(string type, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", type);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("GenerateMaxNumber", param);
    }
}