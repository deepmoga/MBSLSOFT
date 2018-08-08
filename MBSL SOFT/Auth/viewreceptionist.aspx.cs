using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_viewreceptionist : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Page.IsPostBack)
        {

            BindPages();
        }

   
    }
    protected void BindPages()
    {
        DataTable dta = new DataTable();
       
       dta = objsql.GetTable("select * From tblreceptionist where status='1' Order By id asc");
       if (dta.Rows.Count > 0)
       {

           gridlist.DataSource = dta;
           gridlist.DataBind();
       }
    }
    protected void gridlist_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            objsql.ExecuteNonQuery("delete from tblreceptionist where id=" + e.CommandArgument);
            BindPages();
        }

        if (e.CommandName == "edit")
        {
            Response.Redirect("ReceptionDetails.aspx?id=" + e.CommandArgument);
        }

        if (e.CommandName == "add")
        {
            Response.Redirect("viewreceptionist.aspx?id=" + e.CommandArgument);
        }

    }
    protected void gridlist_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblpwd = (Label)e.Item.FindControl("lblpwd");
            lblpwd.Text = DecryptData(lblpwd.Text);
            Label lbldob = (Label)e.Item.FindControl("lbldob");
            #region date conversion
            string date = "";

            string[] alldatevalues = new string[3];
            if (lbldob.Text != "")
            {
                alldatevalues = lbldob.Text.Split("/".ToCharArray());
            }
            if (lbldob.Text.Length >= 3)
            {
                lbldob.Text = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }
            #endregion

        }
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

    protected void btnadd_Click1(object sender, EventArgs e)
    {
        Response.Redirect("ReceptionDetails.aspx");
    }
    protected void btnback_Click1(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

}