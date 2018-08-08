using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Dashboard_Inquiry : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            inquiry();
        }
    }
    protected void inquiry()
    {
        dt = objsql.GetTable("select distinct f.inquiryid,f.id,f.date,i.name,i.contact,f.feedback from tblinquiry i , tblfeedback f where f.nextfollow<='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' and f.status='Active' and i.inquiryid=f.inquiryid");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            Response.Redirect("Visitor-Detail.aspx?id=" + e.CommandArgument.ToString());
        }
    }
}