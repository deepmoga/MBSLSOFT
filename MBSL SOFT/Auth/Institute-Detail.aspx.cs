using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Institute_Detail : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind();
            }
        }
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
            if (FileUpload1.HasFile)
            {
                filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //Save images into Images folder
                string id = Guid.NewGuid().ToString().Substring(0, 5);
                filename = id + filename;
                FileUpload1.SaveAs(HttpContext.Current.Server.MapPath("~/uploadimage/" + filename));

            }
            
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tbldetail set name='" + txtname.Text + "',phone='" + txtphone.Text + "',address='" + txtadd.Text + "',uname='" + txtuser.Text + "',pass='" + txtphone.Text + "',sid='" + txtsid.Text + "',logo='" + filename + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tbldetail (name,phone,address,uname,pass,sid,logo) values('" + txtname.Text + "','" + txtphone.Text + "','" + txtadd.Text + "','" + txtuser.Text + "','" + txtpass.Text + "','" + txtsid.Text + "','" + filename + "')");
        }
        Response.Redirect("view-detail.aspx");
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tbldetail where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtpass.Text = dt.Rows[0]["phone"].ToString();
            txtadd.Text = dt.Rows[0]["address"].ToString();
            txtuser.Text = dt.Rows[0]["uname"].ToString();
            txtpass.Text = dt.Rows[0]["pass"].ToString();
            txtsid.Text = dt.Rows[0]["sid"].ToString();
            filename = dt.Rows[0]["logo"].ToString();
        }
    }

}