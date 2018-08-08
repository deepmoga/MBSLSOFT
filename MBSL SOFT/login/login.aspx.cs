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

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
           if (ddllist.SelectedItem.Text=="Admin")
        {
            DataTable dta = new DataTable();

            dta = objsql.GetTable("select * from tbladmin where username='" + this.txtusername.Text + "' and password='" + EncryptData(this.txtpassword.Text) + "' and Type='"+ddllist.SelectedItem.Text+"'");

            if (dta.Rows.Count > 0)
            {
                if (ddllist.Text== "Admin")
                {
                    Session["Admin"] = dta.Rows[0]["id"].ToString();
                    Response.Redirect("~/Auth/Default.aspx?id=" + Session["Admin"]);
                    
                }

                else
                {

                    Session["Admin"] = null;
                    //Session["User"] = null;

                    //Response.Redirect("lab.aspx");
                }
            }
            else
            {
                Page.RegisterStartupScript("d", "<script> alert('Invalid Username or Password.')</script>");
            }
        }
           else if(ddllist.SelectedItem.Text=="Franchisee")
           {
               dta = objsql.GetTable("select * from FranchiseeDetails where LoginId='" + this.txtusername.Text + "' and Password='" + EncryptData(this.txtpassword.Text) + "'");
               if (dta.Rows.Count > 0)
               {
                 //  Session["Admin"] = null;
                   code = dta.Rows[0]["centercode"].ToString();
                 //  Session["Franchisee"] = dta.Rows[0]["centercode"].ToString();
                   Session["Franchisee"] = dta.Rows[0]["centercode"].ToString();
                   Response.Redirect("~/Auth/Default.aspx");
               }
                else
                {
                  Page.RegisterStartupScript("d", "<script> alert('Invalid Username or Password.')</script>");
                }
           }
       
    
       else if (ddllist.SelectedItem.Text == "Receptionist")
        {
            dta = objsql.GetTable("Select * from tblreceptionist where login='" + txtusername.Text + "' and password='"+EncryptData(this.txtpassword.Text)+"'");
            if (dta.Rows.Count > 0)
            {
                code = dta.Rows[0]["id"].ToString();
                //  Session["Franchisee"] = dta.Rows[0]["centercode"].ToString();
                Session["Receptionist"] = dta.Rows[0]["franchiseeuid"].ToString();
                Response.Redirect("~/Auth/Default.aspx");

            }
            else
            {

                Session["Receptionist"] = null;
            }
            
        }
           else if (ddllist.SelectedItem.Text == "Red Cross Franchisee")
           {
               dta = objsql.GetTable("select * from FranchiseeDetails where LoginId='" + this.txtusername.Text + "' and Password='" + EncryptData(this.txtpassword.Text) + "'");
               if (dta.Rows.Count > 0)
               {
                   //  Session["Admin"] = null;
                   code = dta.Rows[0]["centercode"].ToString();
                   //  Session["Franchisee"] = dta.Rows[0]["centercode"].ToString();
                   Session["Red Cross Franchisee"] = dta.Rows[0]["centercode"].ToString();
                   Response.Redirect("~/Auth/Default.aspx");
               }
               else
               {
                   Page.RegisterStartupScript("d", "<script> alert('Invalid Username or Password.')</script>");
               }

           }
           else if (ddllist.SelectedItem.Text == "Red Cross Receptionist")
           {
               dta = objsql.GetTable("select * from tblreceptionist where login='" + this.txtusername.Text + "' and password='" + EncryptData(this.txtpassword.Text) + "'");
               if (dta.Rows.Count > 0)
               {
                   //  Session["Admin"] = null;
                   code = dta.Rows[0]["franchiseeuid"].ToString();
                   //  Session["Franchisee"] = dta.Rows[0]["centercode"].ToString();
                   Session["Red Cross Receptionist"] = dta.Rows[0]["franchiseeuid"].ToString();
                   Response.Redirect("~/Auth/Default.aspx");
               }
               else
               {
                   Page.RegisterStartupScript("d", "<script> alert('Invalid Username or Password.')</script>");
               }

           }

           else
           {
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