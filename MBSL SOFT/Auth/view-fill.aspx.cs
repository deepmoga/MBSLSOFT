using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_view_fill : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bind();
        }
    }
    protected void gvdata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Fill-test.aspx?id=" + e.CommandArgument.ToString());
        }
        if (e.CommandName == "slip")
        {
            Response.Write("<script>window.open('Print-fill.aspx?id=" +e.CommandArgument.ToString() + "','_blank');</script>");
        }
    }
    protected void bind()
    {
        
        dt = objsql.GetTable("select * from tblfill ");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Fill-test.aspx");
    }
}