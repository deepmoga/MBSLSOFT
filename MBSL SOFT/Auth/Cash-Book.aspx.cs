using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Cash_Book : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public int total = 0;
    public double balo= 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = "02/01/2017";
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
            Label bal = (Label)e.Item.FindControl("lblbalance");
            Label dis = (Label)e.Item.FindControl("lbldis");
            Label date = (Label)e.Item.FindControl("lbldate");
            HiddenField token = (HiddenField)e.Item.FindControl("hfto");
            if (date.Text != "")
            {


                date.Text = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
            }
            // check discount
            dis.Text = Common.Get(objsql.GetSingleValue("select discount from student_fee where token='" + token.Value + "'"));
            bal.Text = Common.Get(objsql.GetSingleValue("select pending_fees from student_fee where token='" + token.Value + "'"));

            total += Convert.ToInt32(amt.Text);
            balo+= Convert.ToDouble(bal.Text);

            lblrec.Text = total.ToString();
            lblbal.Text = balo.ToString() ;
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select r.id,s.name,r.date,r.reciptno,r.amount,s.rollno,r.tokenno from tblstudentdata s , Recipt_details r where s.rollno=r.rollno and  r.Date between '" + changedate(txtFromDate.Text) + "' and '" + changedate(txtToDate.Text) + "' and r.cancelauthorisation!='Cancel' and r.Active='1' order by r.date asc");
        if (dt.Rows.Count > 0)
        {
            gridPaymentinfo.DataSource = dt;
            gridPaymentinfo.DataBind();
        }
        else
        {
            gridPaymentinfo.DataSource = dt;
            gridPaymentinfo.DataBind();
            total = 0;
            balo = 0.0;
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