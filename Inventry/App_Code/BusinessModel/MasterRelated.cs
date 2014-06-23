using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MasterRelated
/// @Ridhhi Kumar Shrestha
/// </summary>
public class MasterRelated
{
    //---------------  Account Related Start ----------------------------

    // Account Delete/Edit/Insert Related by Status=D, E and I
    public string AllAccountRelated(string parent, string code, string aname, string type, int levels, string owner, string usercode, string status, string detailvalues, string addt, string addp, string conperson, string telephone, string mobile, string email, string webpage, string remarks)
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
        param[17] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[17].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("AccountRelated", param);
        return (param[17].Value.ToString()).Trim();
    }

   

    // To Load Treeview Structure of Account
    public DataTable LoadAccountListTreeView(string parent, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("AccountListsTreeView", param);
    }

    //Load Account Info
    public DataTable LoadAccountDetails(string ucode, string type)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Code", ucode);
        param[1] = new SqlParameter("@Type", type);
        return DataAccessLayer.getTable("AccountInfo", param);
    }
    //-------------- End of Account Related -----------------------------

    
    //subdealer related start
    public string AllSubDealerRelated(string code, string aname, string usercode, string status, string addt, string addp, string conperson, string telephone, string mobile, string email, string webpage, string remarks, string showif)
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

    //---------------  Item Related Start ----------------------------

    // Item Delete/Edit/Insert Related by Status=D, E and I
    public string AllItemRelated(string parent, string code, string iname, string type, int levels, string usercode, string status, string sex, string itname, double crate, double prate, double srate, string baseunit, int minstock, int maxstock, string disctype, double amount, string vat, string scode)
    {
        SqlParameter[] param = new SqlParameter[20];
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
        param[18] = new SqlParameter("@SCode", scode);
        param[19] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[19].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("ItemRelated", param);
        return (param[19].Value.ToString()).Trim();
    }

    // To Load Item Treeview Structure
    public DataTable LoadItemListTreeView(string parent, string status)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Status", status);
        return DataAccessLayer.getTable("ItemListsTreeView", param);
    }

    //Load Item Info
    public DataTable LoadItemDetails(string code)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Code", code);
        return DataAccessLayer.getTable("ItemInfo", param);
    }

    //Load Supplier/provider lists for Item Master
    public DataTable getSubppliers(string parent, string owner, string usercode, string accountoritem)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Parent", parent);
        param[1] = new SqlParameter("@Owner", owner);
        param[2] = new SqlParameter("@UserCode", usercode);
        param[3] = new SqlParameter("@AccountOrItem", accountoritem);
        return DataAccessLayer.getTable("ParentToChildEnd", param);
    }

    //Load Supplier/provider lists for Purchase
    public DataTable AccountListforPurchase(string owner, string usercode)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Owner", owner);
        param[1] = new SqlParameter("@UserCode", usercode);
        return DataAccessLayer.getTable("AccountListforPurchase", param);
    }
    //Load Client Lists for Sales
    public DataTable AccountListforSales(string owner, string usercode)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Owner", owner);
        param[1] = new SqlParameter("@UserCode", usercode);
        return DataAccessLayer.getTable("AccountListforSales", param);
    }
   

    //Load Item Base Units
    public DataTable getItemBaseUnit()
    {
        SqlParameter[] param = new SqlParameter[0];
        return DataAccessLayer.getTable("BaseUnitLists", null);
    }

    //Load Wholesale Rate
    public DataTable getWholeSaleRate(double prate)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@PRate", prate);
        return DataAccessLayer.getTable("WholeSaleRateGenerate", param);
    }

    //-------------- End Of Item Related -----------------------------

    //-------------- Opening Stock Related ---------------------------
    public DataTable OpenItemInfo(string owner,string icode)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Owner", owner);
        param[1] = new SqlParameter("@ICode", icode);
        return DataAccessLayer.getTable("OpenItemInfo", param);
    }

   
    public string OpenItemRelated(string icode, double qty, double rate,string owner, string usercode)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@ICode", icode);
        param[1] = new SqlParameter("@Qty", qty);
        param[2] = new SqlParameter("@Rate", rate);
        param[3] = new SqlParameter("@Owner", owner);
        param[4] = new SqlParameter("@UserCode", usercode);
        param[5] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[5].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("OpenItemRelated", param);
        return (param[5].Value.ToString()).Trim();
    }

    //------------- End of Openning Stock Related --------------------

    //-------------- Stock Count Related ---------------------------
    public DataTable StockCountInfo(string owner, string icode)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Owner", owner);
        param[1] = new SqlParameter("@ICode", icode);
        return DataAccessLayer.getTable("StockCountInfo", param);
    }

    public string StockCountItemRelated(string icode, double qty, double rate, string owner, string usercode)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@ICode", icode);
        param[1] = new SqlParameter("@Qty", qty);
        param[2] = new SqlParameter("@Rate", rate);
        param[3] = new SqlParameter("@Owner", owner);
        param[4] = new SqlParameter("@UserCode", usercode);
        param[5] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[5].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("StockCountItemRelated", param);
        return (param[5].Value.ToString()).Trim();
    }

    public string bulkInsertCheck(DataTable ItemDetails)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@ItemsDetails", ItemDetails);
        param[1] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[1].Direction = ParameterDirection.Output;
        DataAccessLayer.ExecuteProc("ChecktTablePara", param);
        return (param[1].Value.ToString()).Trim();
    }

    //------------- End of  Stock Count Related --------------------

   

    

}