using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection con=new SqlConnection(DataAccessLayer.connectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        string flag = CheckUserName();
        if (flag == "true")
        {
            using (SqlCommand cmd = new SqlCommand("update UserListToLogin set UPassWord=@UPassWord where UName=@UName", con))
            {
                cmd.Parameters.AddWithValue("@UName", txtUsername.Text);
                //Here i have implemented the code for doing encryption of password
                string ePass = Helper.ComputeHash(txtPassword.Text, "SHA512", null);
                cmd.Parameters.AddWithValue("@UPassWord", ePass);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lbmMessage.Text = "Your password has been Updated Sucessfully";
            }
        }
    }

    public string CheckUserName()
    {

        using (SqlCommand cmd = new SqlCommand("Select UName from UserListToLogin where UName=@UName", con))
        {
            cmd.Parameters.AddWithValue("@UName", txtUsername.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {

                return "true";
            }
            else
            {
                lbmMessage.Text = "Invalid UserName";
                txtPassword.Text = string.Empty;
                return "false";
            }

        }
    }
}