using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Auth_view_receiptno : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Bind();
        }
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        ds=objsql.GetDataset("select * from tblReceipt where Status='1'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridlist.DataSource = ds;
            gridlist.DataBind();
        }
    }
    protected void gridlist_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Add-ReceiptNo.aspx?Id=" + e.CommandArgument);
        }
        if (e.CommandName == "Deactivate")
        {
            objsql.ExecuteNonQuery("update tblReceipt set Status='0' where Id=" + e.CommandArgument);
        }
        if (e.CommandName == "Activate")
        {
            objsql.ExecuteNonQuery("update tblReceipt set Status='1' where Id=" + e.CommandArgument);
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add-ReceiptNo.aspx");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}