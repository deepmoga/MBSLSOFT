using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_main : System.Web.UI.MasterPage
{
    public enum MessageType { Success, Error, Info, Warning };
    public static string name = "";
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (Session["Admin"] == null && Session["Receptionist"] == null)
            {
                Response.Redirect("login.aspx");
            }
            name = Common.Get(objsql.GetSingleValue("select name from tbldetail"));


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
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
    protected void lnkcomplete_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Complete-Course.aspx");
    }
    protected void lnkactive_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Deactive.aspx");
    }
    protected void lblresult_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/Result.aspx");
    }
    protected void lnkdeposit_Click(object sender, EventArgs e)
    {
        Cache.Remove("id");
        Response.Redirect("~/Auth/deposit-fee.aspx?quick='sucess'");
    }
    public void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}
