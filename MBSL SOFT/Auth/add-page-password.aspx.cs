using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;

public partial class Auth_add_page_password : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string centercode = "";
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null && Session["Admin"] == "")
            Response.Redirect("~/login.aspx");

        if (Session["Admin"] != null)
        {
            lblcode.Text = Session["Admin"].ToString();
        }
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
            {
                objsql.ExecuteNonQuery("update tblPassword set Page_name='" + txtpage.Text + "',Password='" + EncryptData(txtpass.Text) + "' where Id='" + Request.QueryString["Id"] + "'");
            }
            else
            {
                objsql.ExecuteNonQuery("insert into tblPassword(Page_name,Password,Status) values('" + txtpage.Text + "','" + EncryptData(txtpass.Text) + "','1')");
            }
        }
        catch (Exception ex)
        {
            
             string message = ex.Message.ToString();

             Page.ClientScript.RegisterStartupScript(typeof(Page), "ControlFocus", "<script> alert('" + message + "')</script>", true);
        }
        Response.Redirect("View-password.aspx");
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        ds = objsql.GetDataset("select * from tblPassword where Id='" + Request.QueryString["Id"] + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtpage.Text = ds.Tables[0].Rows[0]["Page_name"].ToString();
            txtpass.Text = DecryptData(ds.Tables[0].Rows[0]["Password"].ToString());
            txtpass.TextMode = TextBoxMode.SingleLine;
            }
    }
    #region encrypted decryped data
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
    #endregion
}