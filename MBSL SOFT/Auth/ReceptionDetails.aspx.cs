using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_ReceptionDetails : System.Web.UI.Page
{

    public static string rid = "", role1 = "", role2 = "", formatdate, strname = "", riid = "";
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    DataTable dt2 = new DataTable();
    
    
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            roles();
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                roles();
                BindDescription();
            }

            rid = GenerateLeadNo();

            if (Session["Admin"] != null)
            {
              

            }
        }
        txtdob.Attributes.Add("readonly", "readonly");
        txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

 
    }
    protected string GenerateLeadNo()
    {
        string LeadNo = "";
        string id = objsql.GetSingleValue("select max(id) from tblreceptionist").ToString();
        if (id == "")
        {
            return "r_" + "1001";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select rid from tblreceptionist where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo.Replace("r_", "0"));
            oldlead += 1;

            return "r_" + oldlead.ToString();
        }

    }
    protected void BindDescription()
    {

        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {

            DataTable dta = new DataTable();
            dta = objsql.GetTable("select * From tblreceptionist where id='" + Request.QueryString["id"] + "' Order By id asc");

            txtname.Text = dta.Rows[0]["name"].ToString();

           



             txtdob.Text = dta.Rows[0]["dob"].ToString();
            txtfather.Text = dta.Rows[0]["fname"].ToString();
            txtmother.Text = dta.Rows[0]["mname"].ToString();
            txtaddress.Text = dta.Rows[0]["address"].ToString();
            txtemail.Text = dta.Rows[0]["email"].ToString();
            txtcontact.Text = dta.Rows[0]["contact"].ToString();
            txtlogin.Text = dta.Rows[0]["login"].ToString();
            txtpassword.Text =DecryptData(dta.Rows[0]["password"].ToString());
            txtdate.Text = dta.Rows[0]["date"].ToString();
            ddltype.SelectedItem.Text = dta.Rows[0]["Type"].ToString();
            

            
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
    protected void btn1_Click(object sender, EventArgs e)
    {
        changedate();


        if (Request.QueryString["id"]==null)
            {
                if (FileUpload1.HasFile)
                {
                    strname = FileUpload1.FileName.ToString();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/uploadimage/") + strname);
                }
                SqlParameter[] Param ={
                    new SqlParameter("@date",formatdate),
                    new SqlParameter("@name",txtname.Text),
                    new SqlParameter("@dob",txtdob.Text),
                    new SqlParameter("@fname",txtfather.Text),
                    new SqlParameter("@mname",txtmother.Text),
                    new SqlParameter("@address",txtaddress.Text),
                    new SqlParameter("@email",txtemail.Text),
                    new SqlParameter("@contact",txtcontact.Text),
                    new SqlParameter("@login",txtlogin.Text),
                    new SqlParameter("@password",EncryptData(txtpassword.Text)),
                    new SqlParameter("@rid",rid),
                    new SqlParameter("@status","1"),
                    new SqlParameter("@image",strname),
                    new SqlParameter("@Type",ddltype.SelectedItem.Text),
                   
                                 };
                help.ExecuteNonQueryByProc("InsertReceptionDetail", Param);
                foreach (GridViewRow row in gvpage.Rows)
                {
                    CheckBox ch = (CheckBox)row.FindControl("chk");
                    HiddenField id = (HiddenField)row.FindControl("hfid");
                    if (ch.Checked == true)
                    {
                        objsql.ExecuteNonQuery("insert into tblroles (pageid,rid) values ('" + id.Value + "','" + rid + "')");
                    }


                }
            }
            else
            {
                objsql.ExecuteNonQuery("update tblreceptionist set name='" + txtname.Text + "',dob='" + txtdob.Text + "',fname='" + txtfather.Text + "',mname='" + txtmother.Text + "',address='" + txtaddress.Text + "',email='" + txtemail.Text + "',contact='" + txtcontact.Text + "',login='" + txtlogin.Text + "',password='" + EncryptData(txtpassword.Text) + "' where id='" + Request.QueryString["id"] + "'");
                foreach (GridViewRow row in gvpage.Rows)
                {
                    CheckBox ch = (CheckBox)row.FindControl("chk");
                    HiddenField ids = (HiddenField)row.FindControl("hfid");
                    if (ch.Checked == true)
                    {
                        string id = Common.Get(objsql.GetSingleValue("select id from tblroles where rid='" + riid + "' and pageid='" + ids.Value + "'"));
                        if (id == "")
                        {
                            objsql.ExecuteNonQuery("insert into tblroles (pageid,rid) values ('" + ids.Value + "','" + riid + "')");

                        }
                        // objsql.ExecuteNonQuery("update tblroles set pageid ='" + id.Value + "' where rid='" + rid + "' and pageid='" + id.Value + "'");
                    }
                    else
                    {
                        objsql.ExecuteNonQuery("delete from tblroles where rid='" + riid + "' and pageid='" + ids.Value + "'");
                    }


                }
            }


          clear();

     
        Response.Redirect("viewreceptionist.aspx");
       

    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void clear()
    {
        txtname.Text = "";
        txtdob.Text = "";
        txtfather.Text = "";
        txtmother.Text = "";
        txtaddress.Text = "";
        txtemail.Text = "";
        txtcontact.Text = "";
        txtlogin.Text = "";
        txtpassword.Text = "";
    }
    
    protected  void changedate()
    {
        #region change date format
        DateTime date = new DateTime();
        date = DateTime.ParseExact(txtdate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        formatdate = date.ToString("MM/dd/yyyy");
        #endregion
    }
    protected void roles()
    {
        //if (Request.QueryString["id"] != null)
        //{
        //    dt2 = objsql.GetTable("select * from tblsoftpage where rid='"+riid+"'");
        //}

        //else
        //{
        //    dt2 = objsql.GetTable("select * from tblsoftpage");
        //}
        dt2 = objsql.GetTable("select * from tblsoftpage");
        if (dt2.Rows.Count > 0)
        {
            gvpage.DataSource = dt2;
            gvpage.DataBind();
        }

    }
    protected void gvpage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox ch = (CheckBox)e.Row.FindControl("chk");
            HiddenField hf = (HiddenField)e.Row.FindControl("hfid");
            string data = Common.Get(objsql.GetSingleValue("select id from tblroles where pageid='" + hf.Value + "' and rid='" + riid + "'"));
            if (data != "")
            {
                ch.Checked = true;
            }
        }
    }


}