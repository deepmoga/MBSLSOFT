using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Inquiry_List : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            bind();
        }
    }
    protected void bind()
    {
        help.SelectGridView("selectInquiry", GridView1);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField id = (HiddenField)e.Row.FindControl("hfid");
            LinkButton visit = (LinkButton)e.Row.FindControl("lnkvisit");
            Label date = (Label)e.Row.FindControl("lbldate");
            date.Text = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
            visit.Text = Common.Get(objsql.GetSingleValue("select count(id) from tblfeedback where inquiryid='" + id.Value + "'"));
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="edit")
        {
            Response.Redirect("visitor-detail.aspx?id="+ e.CommandArgument.ToString());
        }
        if (e.CommandName == "detail")
        {
            Response.Redirect("inquiry.aspx?id=" + e.CommandArgument.ToString());
        }
        if (e.CommandName == "delete")
        {
            objsql.ExecuteNonQuery("delete from tblinquiry where inquiryid=" + e.CommandArgument.ToString());
            objsql.ExecuteNonQuery("delete from tblfeedback where inquiryid=" + e.CommandArgument.ToString());
        }
        bind();
        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("inquiry.aspx");
    }
}