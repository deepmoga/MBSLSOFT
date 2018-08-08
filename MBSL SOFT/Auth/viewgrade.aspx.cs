using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Auth_viewgrade : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dta = new DataTable();
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
        //    Response.Redirect("~/login.aspx");


        if (!Page.IsPostBack)
        {
            if (Session["Franchisee"] != null)
            {
                lblcode.Text = Session["Franchisee"].ToString();
            }
            if (Session["Receptionist"] != null)
            {
                lblcode.Text = Session["Receptionist"].ToString();
            }

            if (Session["Admin"] != null)
            {
                lblcode.Text = Request.QueryString["type"].ToString();
            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();


            }
            if (Session["Red Cross Receptionist"] != null)
            {
                lblcode.Text = Session["Red Cross Receptionist"].ToString();


            }
            BindPages();

            //((LinkButton)Master.FindControl("lnkfranc")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkdash")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkreception")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkstureg")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkdeactivate")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkinq")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkmaster")).CssClass = "active";
            //((LinkButton)Master.FindControl("lnkexpense")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkresume")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkother")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkresult")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkfvresult")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkcerti")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkreport")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkrecept")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkperformance")).CssClass = "";
            //((LinkButton)Master.FindControl("lnkviewstu")).CssClass = "";
        }
    }
    protected void BindPages()
    {
        DataTable dta = new DataTable();
        dta = objsql.GetTable("select * From tblgrade where CenterCode='" + lblcode.Text + "' Order By id asc");
        gridlist.DataSource = dta;
        gridlist.DataBind();
    }
    //protected void btnadd_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("add--master-details.aspx");
    //}
    protected void gridlist_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {

             objsql.ExecuteNonQuery1("delete from tblgrade  where id=" + e.CommandArgument);
            //if (i > 0)
            //{
            //    Page.RegisterStartupScript("d", "<script>alert('Grade Deleted Successfully!!')</script>");
            //}
            //else
            //{
            //    Page.RegisterStartupScript("d", "<script>alert('Grade Not Deleted!!')</script>");
            //}

            BindPages();
        }
        if (e.CommandName == "edit")
        {
            Response.Redirect("add--master-details.aspx?Grade_Id=" + e.CommandArgument);
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add--master-details.aspx?grade=active");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}