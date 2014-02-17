using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;



public partial class _Default : System.Web.UI.Page
{
    GeneralRelated obj = new GeneralRelated();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
   
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword.Text);
        //string encryptPassword = Convert.ToBase64String(passBytes);
        //string epassword = Helper.ComputeHash(txtPassword.Text, "SHA512", null);
         
        if (txtPassword.Text==txtRepassword.Text)
        {

            int j = obj.RegisterCustomer(txtCustomerName.Text, txtPassword.Text, txtEmail.Text, txtMobile.Text);
            if (j>0)
            {
                lblMsg.Text = "Registration Sucess..!!";
            }
        }
        else
        {
            lblMsg.Text = "Password Mismatch..!";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCustomerName.Text = "";
        txtPassword.Text = "";
        txtRepassword.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
    }

    //public string Encrypt(string str)
    //{
    //    string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
    //    byte[] byKey = { };
    //    byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
    //    byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
    //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    //    byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
    //    MemoryStream ms = new MemoryStream();
    //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
    //    cs.Write(inputByteArray, 0, inputByteArray.Length);
    //    cs.FlushFinalBlock();
    //    return Convert.ToBase64String(ms.ToArray());
    //}
   
   
}