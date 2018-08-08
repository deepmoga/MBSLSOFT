using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Expense_List : System.Web.UI.Page
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
        help.SelectGridView("selectExpense", gvdata);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Expense.aspx");
    }
    protected void gvdata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("Expense.aspx?id=" + e.CommandArgument.ToString());
        }
    }
    
}