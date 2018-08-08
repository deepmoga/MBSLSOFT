using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Outstanding_Report : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            bind();
        }

    }
    protected void BtnLoadReport_Click(object sender, EventArgs e)
    {
        total = 0;
        bind();
    }
    protected void gridPaymentinfo_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) ||
             (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label amt = (Label)e.Item.FindControl("lblamt");
            Label date = (Label)e.Item.FindControl("lbldate");
            if (date.Text != "")
            {


                date.Text = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
            }
            total += Convert.ToInt32(amt.Text);
            lbltotal.Text = total.ToString();

        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select s.id,s.name,s.rollno,s.phone,p.fees,p.alertdate from tblstudentdata s , tblpendingfee p where s.rollno=p.rollno and p.status='1' and s.status='1' and p.alertdate<='"+changedate(txtToDate.Text)+"'  order by p.alertdate asc");
        if (dt.Rows.Count > 0)
        {
            gridPaymentinfo.DataSource = dt;
            gridPaymentinfo.DataBind();
        }
    }
    public string changedate(string dates)
    {
        if (dates != "")
        {
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(dates, "dd/MM/yyyy", null);
            return myDateTime.ToString("MM/dd/yyyy"); // add myString_new to oracle
        }
        else
        {
            return null;
        }
    }

    
}