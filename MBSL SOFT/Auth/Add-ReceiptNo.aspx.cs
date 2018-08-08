using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Auth_Add_ReceiptNo : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string centercode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    public void BindCenter()
    {
        DataSet ds1 = new DataSet();
        ds1 = objsql.GetDataset("select * from FranchiseeDetails");
        ddlcenter.DataSource = ds1;
        ddlcenter.DataTextField = "CenterName";
        ddlcenter.DataValueField = "centercode";
        ddlcenter.DataBind();
        ddlcenter.Items.Insert(0, "Select Center");
        ds1.Clear();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            //centercode = ddlcenter.SelectedItem.Value;
        }
        else
        {
            centercode = Session["code"].ToString();
        }
        if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
        {
            objsql.ExecuteNonQuery("update tblReceipt set Start_no='" + txtstart.Text + "',End_no='" + txtend.Text + "' where Id='" + Request.QueryString["Id"] + "'");
        }
        else
        {
            string max = Common.Get(objsql.GetSingleValue("select max(id) from tblreceipt where status='1'"));
            objsql.ExecuteNonQuery("update tblreceipt set status='0' where id='" + max + "'");
            objsql.ExecuteNonQuery("insert into tblReceipt(Start_no,End_no,Center_code,Date,Status,current_recipt) values('" + txtstart.Text + "','" + txtend.Text + "','" + centercode + "','" + System.DateTime.Now.ToShortDateString() + "','1','"+txtstart.Text+"')");
        }
        Response.Redirect("view-receiptno.aspx");
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        ds = objsql.GetDataset("select * from tblReceipt where Id='" + Request.QueryString["Id"] + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtstart.Text = ds.Tables[0].Rows[0]["Start_no"].ToString();
            txtend.Text = ds.Tables[0].Rows[0]["End_no"].ToString();
            ddlcenter.SelectedIndex = ddlcenter.Items.IndexOf(ddlcenter.Items.FindByValue(ds.Tables[0].Rows[0]["Center_code"].ToString()));
        }
    }
}