using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;

public partial class Auth_View_password : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null || Session["Admin"] == "")
            Response.Redirect("login.aspx");
       
        if (Session["Admin"] != null)
        {
            lblcode.Text = Session["Admin"].ToString();
        }
        if (!IsPostBack)
        {
            Bind();
        }
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        ds = objsql.GetDataset("select * from tblPassword order by id asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridlist.DataSource = ds;
            gridlist.DataBind();
        }
    }
    protected void gridlist_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("add-page-password.aspx?Id=" + e.CommandArgument);
        }
        if (e.CommandName == "Deactivate")
        {
            objsql.ExecuteNonQuery("update tblPassword set Status='0' where Id=" + e.CommandArgument);
        }
        if (e.CommandName == "Activate")
        {
            objsql.ExecuteNonQuery("update tblPassword set Status='1' where Id=" + e.CommandArgument);
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-page-password.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void gridlist_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label lblpass = (Label)e.Item.FindControl("lblpass");
            lblpass.Text = DecryptData(lblpass.Text);
        }
    }
    #region Encrypt/Decrypt Data
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