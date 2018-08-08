using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Auth_view_teachers : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("login.aspx");
        if (!Page.IsPostBack)
        {
            if (Session["Franchisee"] != null)
            {
                lblcode.Text = Session["Franchisee"].ToString();
                Bindfranchdata();
                pnlsearch.Visible = false;
            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();
            }
            if (Session["Admin"] != null)
            {
                lblcode.Text = Session["Admin"].ToString();
                Binddata();
                Bindfranchdata();
                pnlsearch.Visible = true;
            }
            //if (Session["Receptionist"] != null)
            //{
            //    lblcode.Text = Session["Receptionist"].ToString();
            //}
            //if (Session["Red Cross Receptionist"] != null)
            //{
            //    lblcode.Text = Session["Red Cross Receptionist"].ToString();
            //}
        }
    }
    #region Bind Teachers data
    public void Binddata()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblteacher");
        GrdDetail.DataSource = dt;
        GrdDetail.DataBind();
        foreach (GridViewRow gr in GrdDetail.Rows)
        {
            Label lbldob = (Label)gr.FindControl("lbldob");
            string[] allvalues = new string[3];
            allvalues = lbldob.Text.Split("/".ToCharArray());
            lbldob.Text = allvalues[1].Trim() + "/" + allvalues[0].Trim() + "/" + allvalues[2].Trim();
        }
    } 
    #endregion
    #region Bind Franchisee
    public void Bindfranchdata()
    {
        if (Session["Franchisee"] != null && Session["Franchisee"] !="")
        {
            DataTable dtf = new DataTable();
            dtf = objsql.GetTable("select * from tblteacher where centercode='" + Session["Franchisee"] + "'");
            GrdDetail.DataSource = dtf;
            GrdDetail.DataBind();
            foreach (GridViewRow gr in GrdDetail.Rows)
            {
                Label lbldob = (Label)gr.FindControl("lbldob");
                string[] allvalues = new string[3];
                allvalues = lbldob.Text.Split("/".ToCharArray());
                lbldob.Text = allvalues[1].Trim() + "/" + allvalues[0].Trim() + "/" + allvalues[2].Trim();
            }
        }
        if (Session["Admin"] != null && Session["Admin"] != "")
        {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from FranchiseeDetails");
            ddlfranchisee.DataSource = dt;
            ddlfranchisee.DataTextField = "CenterName";
            ddlfranchisee.DataValueField = "centercode";
            ddlfranchisee.DataBind();
            ddlfranchisee.Items.Insert(0, new ListItem("select franchisee"));
        } 
    } 
    #endregion
    #region Grid action
    protected void GrdDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GrdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Deactivate")
        {
            objsql.ExecuteNonQuery("update tblteacher set status=0 where id=" + e.CommandArgument);
        }

        if (e.CommandName.ToString() == "Activate")
        {
            objsql.ExecuteNonQuery("update tblteacher set status=1 where id=" + e.CommandArgument);
        }
        if (e.CommandName == "edit")
        {
            Response.Redirect("add--master-details.aspx?teach_id=" + e.CommandArgument);
        }
        Binddata();
    }
    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GrdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDetail.PageIndex = e.NewPageIndex;
        Binddata();
        GrdDetail.DataBind();
    } 
    #endregion
    #region add teacher
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add--master-details.aspx?teach=active");
    } 
    #endregion
    #region Back button click
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    } 
    #endregion
    #region Search Teacher
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        DataTable dtf = new DataTable();
        dtf = objsql.GetTable("select * from tblteacher where centercode='" + ddlfranchisee.SelectedItem.Value + "'");
        GrdDetail.DataSource = dtf;
        GrdDetail.DataBind();
    } 
    #endregion
}