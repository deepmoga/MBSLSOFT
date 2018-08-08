using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_view_detail : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bind();

        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from tbldetail order by id desc");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }

    }
   
    protected void gvdata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("institute-detail.aspx?id=" + e.CommandArgument.ToString());
        }
    }
}