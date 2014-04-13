using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// All Function related to Customer
/// </summary>
public class CustomerRelated
{
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
}