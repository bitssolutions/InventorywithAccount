using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ItemRealted
/// </summary>
public class ItemRealted
{
    //item related start
    public string AllItemRelated(string parent, string code,string iname,string type, int levels,string usercode, string status,string sex, string itname, string crate, string prate, string srate, string baseunit, string minstock, string maxstock, string disctype, string amount,string vat,string acode)
    {
        SqlParameter[] param = new SqlParameter[18];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Code", code);
        param[2] = new SqlParameter("@IName", iname);
        param[3] = new SqlParameter("@Type", type);
        param[4] = new SqlParameter("@Levels", levels);
        param[5] = new SqlParameter("@UserCode", usercode);
        param[6] = new SqlParameter("@Status", status);
        param[7] = new SqlParameter("@Sex", sex);
        param[8] = new SqlParameter("@ItName", itname);
        param[9] = new SqlParameter("@CRate", crate);
        param[10] = new SqlParameter("@PRate", prate);
        param[11] = new SqlParameter("@SRate", srate);
        param[12] = new SqlParameter("@BaseUnit", baseunit);
        param[13] = new SqlParameter("@MinStock", minstock);
        param[14] = new SqlParameter("@MaxStock", maxstock);
        param[15] = new SqlParameter("@DiscType", disctype);
        param[16] = new SqlParameter("@Amount", amount);
        param[17] = new SqlParameter("@VAT", vat);
        param[18] = new SqlParameter("@ACode", acode);
        param[19] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[19].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("ItemRelated", param);
        return (param[19].Value.ToString()).Trim();
    }


    public DataTable generateMaxNumber(string type, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", type);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("GenerateMaxNumber", param);
    }
    //item related end

    // to load treeview structure
    public DataTable LoadItemListTreeView(string parent)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Parent", parent);
        return DataAccessLayer.getTable("ItemListsTreeView", param);
    }
    //end load treeview structure

    //load iteminfo
    public DataTable LoadItemDetails(string code)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Code", code);
        return DataAccessLayer.getTable("ItemInfo", param);
    }


    //end load iteiminfo
}