using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// All Functions Related to Users of the system
/// </summary>
public class UserRelated
{

    public DataTable CheckUserLogin(string AName,string APassword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@AName",AName);
        param[1] = new SqlParameter("@APassWord",APassword);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        ////string strMessage = param[2].Value.ToString();
        return DataAccessLayer.getTable("CheckLogin", param);
        
    }

    public string CheckUserExists(string AName, string APassword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@AName", AName);
        param[1] = new SqlParameter("@APassWord", APassword);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        DataAccessLayer.getTable("CheckLogin", param);
        return param[2].Value.ToString();
    }

    public int UpdateAdminTypeUser(string AName, string APassword)
    { 
        SqlParameter[] param=new SqlParameter[3];
        param[0] = new SqlParameter("@AName", AName);
        param[1] = new SqlParameter("@APassWord", APassword);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        return DataAccessLayer.ExecuteProc("LoginAdminUNameAndPasswordChange", param);
    }

    public DataTable getAllYearLists()
    {
        string status = "Y";
        Boolean yearisfrom = false;
        Boolean yearisto = false;
        SqlParameter[] param=new SqlParameter[4];
        param[0] = new SqlParameter("@Status", status);
        param[1] = new SqlParameter("@YearIsFrom", yearisfrom);
        param[2] = new SqlParameter("@YearIsTo", yearisto);
        param[3] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[3].Direction = ParameterDirection.Output;
        return DataAccessLayer.getTable("YearListsAndRelated", param);
    }

    public int InsertFisicalYear(string physicalyear)
    {
        string status="I";
        SqlParameter[] param = new SqlParameter[2];
        param[0]=new SqlParameter("@Status",status);
        param[1] = new SqlParameter("@YearIsFrom",physicalyear);
        return DataAccessLayer.ExecuteProc("YearListsAndRelated",param);
    }

    public DataTable getSubDealers(string username,string password)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Name", username);
        param[1] = new SqlParameter("@PassWord", password);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        return DataAccessLayer.getTable("SubDealerLists", param);
    }
   
}