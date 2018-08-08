using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_profile : System.Web.UI.MasterPage
{
    SQLHelper objsql = new SQLHelper();
    public static string img = "",name="";
    DataTable dt = new DataTable();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblro.Text = Common.Get(objsql.GetSingleValue("select rollno from tblstudentdata where id='" + Cache["id"] + "'"));
            lblname.Text = Common.Get(objsql.GetSingleValue("select name from tblstudentdata where id='" + Cache["id"] + "'"));
            img = Common.Get(objsql.GetSingleValue("select image from tblstudentdata where id='" + Cache["id"] + "'"));
            name = Common.Get(objsql.GetSingleValue("select name from tbldetail"));
        }
        if (Session["Admin"] != null)
        {
            dt = objsql.GetTable("select * from tblsoftpage");
            if (dt.Rows.Count > 0)
            {
                lvpages.DataSource = dt;
                lvpages.DataBind();
            }
        }
        if (Session["role"] == "franch")
        {
            dt = objsql.GetTable("select s.pname,s.url from tblsoftpage s , tblroles r where r.pageid=s.id and r.rid='" + Session["code"] + "'");
            if (dt.Rows.Count > 0)
            {
                lvpages.DataSource = dt;
                lvpages.DataBind();
            }

        }
    }
    protected void btndeposit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Deposit-Fee.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
    protected void btncourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("Assign-Course.aspx");
    }
    protected void btnlod_Click(object sender, EventArgs e)
    {
        Response.Redirect("Studentfee_Log.aspx");
    }
    protected void btnhistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("History.aspx");
    }
    protected void btnprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student-Profile.aspx");
    }
    protected void btndocument_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-qualification.aspx");
    }
    protected void lnkcomplete_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Complete-Course.aspx");
    }
    protected void lnkactive_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Deactive.aspx");
    }
    protected void lnkresult_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Result.aspx");
    }
    protected void lnkdeposit_Click(object sender, EventArgs e)
    {
        Cache.Remove("id");
        Response.Redirect("~/Auth/deposit-fee.aspx");
    }
    public void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}
