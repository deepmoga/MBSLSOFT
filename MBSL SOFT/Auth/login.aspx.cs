using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;

public partial class Auth_login : System.Web.UI.Page
{
  
    SQLHelper objsql = new SQLHelper();
    const string passphrase = "password";
    DataTable dta = new DataTable();
    public static string code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
     //   string a = Session["Admin"].ToString();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

            dta = objsql.GetTable("Select * from tblreceptionist where login='" + txtusername.Text + "' and password='" + EncryptData(this.txtpassword.Text) + "' and Type='"+ddllist.SelectedItem.Text+"'");
            if (dta.Rows.Count > 0)
            {
              //  string a = Session["Admin"].ToString();
                code = dta.Rows[0]["id"].ToString();
                if (ddllist.SelectedItem.Text == "Admin")
                {
                    Session["Admin"] = dta.Rows[0]["rid"].ToString();

                }
                else
                {
                    Session["Receptionist"] = dta.Rows[0]["rid"].ToString();
                    Session["role"] = "franch";
                }
                Session["code"] = dta.Rows[0]["rid"].ToString();
                Response.Redirect("~/Auth/Default.aspx");

            }
            else
            {
                
                Session["code"] = null;
                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert(' Invalid Username or Password.')</script>");
            }

        



    }
    public static string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }
    public static string DecryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return UTF8.GetString(Results);
    }
}