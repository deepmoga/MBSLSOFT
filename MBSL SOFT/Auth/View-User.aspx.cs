using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Auth_View_User : System.Web.UI.Page
{

    const string passphrase = "password";
    SqlConnection MyCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == "" && Session["Admin"] == null)
            Response.Redirect("login.aspx");
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        SqlCommand cmd = new SqlCommand("selectUser", MyCon);

        cmd.CommandType = CommandType.StoredProcedure;

        //  cmd.Parameters.AddWithValue(“@UserId”, textBox1.Text);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        da.Fill(ds);
        gridlist.DataSource = ds;
        gridlist.DataBind();
        ds.Tables.Clear();
    }
    protected void gridlist_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Cache["Val"] = e.CommandArgument.ToString();
            Cache.Insert("key", Cache["Val"]);
            Response.Redirect("add-edit-user.aspx");
        }
        if (e.CommandName == "Activate")
        {
            string cmd1 = "update tblUser set Status='1' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            //objsql.ExecuteNonQuery("update tblStudentdetail set Status='1' where id=" + e.CommandArgument);
            BindData();
        }
        if (e.CommandName == "Deactivate")
        {
            string cmd1 = "update tblUser set Status='0' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            //objsql.ExecuteNonQuery("update tblStudentdetail set Status='0' where id=" + e.CommandArgument);
            BindData();
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-edit-user.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
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
    protected void gridlist_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label lblpass = (Label)e.Item.FindControl("lblpass");
            lblpass.Text = DecryptData(lblpass.Text);
        }
    }
}