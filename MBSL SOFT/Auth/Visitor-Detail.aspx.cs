using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data;
public partial class Auth_Visitor_Detail : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string next = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            logs();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            if (txtdays.Text != "")
            {
                next = System.DateTime.Now.AddDays(Convert.ToInt32(txtdays.Text)).ToString("MM/dd/yyyy");
            }
            string max=Common.Get(objsql.GetSingleValue("select max(id) from tblfeedback where inquiryid='"+Request.QueryString["id"]+"'"));
            objsql.ExecuteNonQuery("insert into tblfeedback (inquiryid,date,feedback,days,type,nextfollow,status) values('" + Request.QueryString["id"] + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','" + txtfeed.Text + "','" + txtdays.Text + "','" + ddltype.SelectedItem.Text + "','" + next + "','" + ddlstatus.SelectedItem.Text + "')");
            objsql.ExecuteNonQuery("update tblfeedback set status='DeActive' where id='" + max + "'");
            string name = Common.Get(objsql.GetSingleValue("select name from tblinquiry where inquiryid='" + Request.QueryString["id"] + "'"));
            string contact = Common.Get(objsql.GetSingleValue("select contact from tblinquiry where inquiryid='" + Request.QueryString["id"] + "'"));
            sms("Enquiry Followup: (" +name + ") and M:(" + contact + ") Next FollowUp :(" + Convert.ToDateTime(next).ToString("dd/MM/yyyy") + ") Status : (" + ddlstatus.SelectedItem.Text + ")");

            clear();
            ts.Complete();
            ts.Dispose();
        }
        Response.Redirect("inquiry-list.aspx");
    }
    protected void clear()
    {
        txtdays.Text = "";
        txtfeed.Text = "";
        ddlstatus.SelectedIndex = 0;
        ddltype.SelectedIndex = 0;
    }
    protected void logs()
    {
        DataSet ds = new DataSet();
        ds = objsql.GetDataset("select * from tblfeedback where inquiryid='" + Request.QueryString["id"] + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    protected void sms(string Message)
    {
        DataTable dts = new DataTable();

        dts = objsql.GetTable("select * from tblsms");
        if (dts.Rows.Count > 0)
        {
            objsql.SendSMS(dts.Rows[0]["username"].ToString(), dts.Rows[0]["senderid"].ToString(), dts.Rows[0]["alertno"].ToString(), Message, dts.Rows[0]["type"].ToString(), dts.Rows[0]["api"].ToString());


        }
    }
}