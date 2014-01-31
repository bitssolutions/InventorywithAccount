using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AccountList
/// </summary>
public class AccountInfo
{
    public DataTable getAllAccount(string ucode, string type)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Code", ucode);
        param[1] = new SqlParameter("@Type", type);
        return DataAccessLayer.getTable("AccountInfo", param);
    }

    public DataTable getMax(string type, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", type);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("GenerateMaxNumber", param);
    }

}