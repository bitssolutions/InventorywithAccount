using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

/// <summary>
/// All Function related to Customer
/// @Ridhhi Kumar Shrestha
/// </summary>
public class GeneralRelated
{
    //customer Registration

    public int RegisterCustomer(string cname,string cpassword,string email,string mobile)
    {
        SqlParameter[] param=new SqlParameter[5];
        param[0] = new SqlParameter("@CName", cname);
        param[1] = new SqlParameter("@CPassWord", cpassword);
        param[2] = new SqlParameter("@EMail", email);
        param[3] = new SqlParameter("@Mobile", mobile);
        param[4] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[4].Direction = ParameterDirection.Output;
        return DataAccessLayer.ExecuteProc("CustomerRegistrationRelated",param);
    }

    // Generating Maximum Code Number
    public DataTable generateMaxNumber(string type, string owner)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Type", type);
        param[1] = new SqlParameter("@Owner", owner);
        return DataAccessLayer.getTable("GenerateMaxNumber", param);
    }
   
    public DataTable CheckUserLogin(string AName, string APassword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@AName", AName);
        param[1] = new SqlParameter("@APassWord", APassword);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        ////string strMessage = param[2].Value.ToString();
        return DataAccessLayer.getTable("CheckLogin", param);

    }

    public DataTable CheckUserName(string AName)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@AName", AName);
        param[1] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[1].Direction = ParameterDirection.Output;
        ////string strMessage = param[2].Value.ToString();
        return DataAccessLayer.getTable("CheckUserName", param);

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
        SqlParameter[] param = new SqlParameter[3];
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
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Status", status);
        param[1] = new SqlParameter("@YearIsFrom", yearisfrom);
        param[2] = new SqlParameter("@YearIsTo", yearisto);
        param[3] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[3].Direction = ParameterDirection.Output;
        return DataAccessLayer.getTable("YearListsAndRelated", param);
    }

    public int InsertFisicalYear(string physicalyear)
    {
        string status = "I";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Status", status);
        param[1] = new SqlParameter("@YearIsFrom", physicalyear);
        return DataAccessLayer.ExecuteProc("YearListsAndRelated", param);
    }

    public DataTable getSubDealers(string username, string password)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Name", username);
        param[1] = new SqlParameter("@PassWord", password);
        param[2] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
        param[2].Direction = ParameterDirection.Output;
        return DataAccessLayer.getTable("SubDealerLists", param);
    }

    //Get System Date,Fiscal Year,HO Margin,VAT,Dealer etc
    public DataTable getSystemDate()
    {
        SqlParameter[] param = new SqlParameter[1];
        return DataAccessLayer.getTable("SystemStatus", null);
    }
}