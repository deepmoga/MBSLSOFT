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

public partial class Auth_view_gallery : System.Web.UI.Page
{
    SqlConnection MyCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
    public static string albumval="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == "" && Session["Admin"] == null)
            Response.Redirect("login.aspx");
        if (!IsPostBack)
        {
            albumval = Cache["Album_code"].ToString();
            BindData();
        }
    }
    public void BindData()
    {
        if (albumval != null && albumval != "")
        {
            SqlCommand cmd = new SqlCommand("selectGallery", MyCon);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Album_Code", albumval);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);
            gridlist.DataSource = ds;
            gridlist.DataBind();
            ds.Tables.Clear();
        }
    }
    protected void gridlist_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Cache["Val"] = e.CommandArgument.ToString();
            Cache.Insert("key", Cache["Val"]);
            Response.Redirect("add-edit-gallery.aspx");
        }
        if (e.CommandName == "Activate")
        {
            string cmd1 = "update tblGallery set Status='1' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            BindData();
        }
        if (e.CommandName == "Deactivate")
        {
            string cmd1 = "update tblGallery set Status='0' where id=" + e.CommandArgument;
            SqlCommand cmd = new SqlCommand(cmd1, MyCon);
            MyCon.Open();
            cmd.ExecuteNonQuery();
            MyCon.Close();
            BindData();
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-edit-gallery.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}