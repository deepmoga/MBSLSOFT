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

public partial class Auth_View_Video_album : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("selectVideo", MyCon);

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
            Response.Redirect("add-edit-video.aspx");
        }
        if (e.CommandName == "Activate")
        {
            string cmd1 = "update tblVideo set Status='1' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            BindData();
        }
        if (e.CommandName == "Deactivate")
        {
            string cmd1 = "update tblVideo set Status='0' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            BindData();
        }
        if (e.CommandName == "add")
        {
            Cache["Video_Id"] = e.CommandArgument.ToString();
            Response.Redirect("add-edit-videoalbum.aspx");
        }
        if (e.CommandName == "view")
        {
            Cache["Video_Id"] = e.CommandArgument.ToString();
            Response.Redirect("View-VideoGallery.aspx");
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-edit-video.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}