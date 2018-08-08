using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Caching;
public partial class Auth_View_contact : System.Web.UI.Page
{
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
        SqlCommand cmd = new SqlCommand("selectcontact", MyCon);

        cmd.CommandType = CommandType.StoredProcedure;

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
            Response.Redirect("add-edit-contact.aspx");
        }
        
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}