using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Globalization;
using System.Data;
public partial class Auth_inquiry : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    public static string inquiry = "", formatdate,next;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bind();
            inquiry = GenerateInquiry();
            txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            if (Request.QueryString["id"] != null)
            {
                data(Request.QueryString["id"].ToString());
            }
           
           
            
        }
    }
    protected void bind()
    {
        help.BindDropDownList("select * from course", "coursename", "courseid", ddlcourse);
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            DateFormat();
            if (Request.QueryString["id"] != null)
            {

                if (ddltype.SelectedItem.Text == "Days")
                {


                    next = System.DateTime.Now.AddDays(Convert.ToInt32(txtdays.Text)).ToString("MM/dd/yyyy");
                }
                objsql.ExecuteNonQuery("update tblinquiry set name='" + txtname.Text + "',fname='" + txtfname.Text + "',contact='" + txtcontact.Text + "',address='" + txtaddress.Text + "',referedby='" + txtref.Text + "',course='" + ddlcourse.SelectedItem.Value + "',date='" + formatdate + "',status='1' where inquiryid='" + Request.QueryString["id"] + "'");
                objsql.ExecuteNonQuery("update tblfeedback set date='"+ formatdate + "', feedback='" + txtfeed.Text + "',days='" + txtdays.Text + "',type='" + ddltype.SelectedItem.Text + "',nextfollow='" + next + "',status='" + ddlstatus.SelectedItem.Text + "' where inquiryid='" + Request.QueryString["id"] + "' ");
                Response.Redirect("Inquiry-List.aspx");
            }
            else
            {
                

                int i = objsql.ExecuteNonQuery1("insert into tblinquiry (inquiryid,name,fname,contact,address,referedBy,course,date,centercode,status) values('" + inquiry + "','" + txtname.Text + "','" + txtfname.Text + "','" + txtcontact.Text + "','" + txtaddress.Text
                    + "','" + txtref.Text + "','" + ddlcourse.SelectedItem.Value + "','" + formatdate + "','" + Session["code"] + "','1')");
                if (i > 0)
                {
                    // objsql.ExecuteNonQuery("update FranchiseeDetails Set inquiryid='" + txtInquiry.Text + "' where UniqueCode='" + Code + "' ");

                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Saved Successfully..')</script>");
                }
                else
                {
                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Not Saved ..')</script>");
                }
                if (ddltype.SelectedItem.Text == "Days")
                {


                    next = System.DateTime.Now.AddDays(Convert.ToInt32(txtdays.Text)).ToString("MM/dd/yyyy");
                }

                objsql.ExecuteNonQuery("insert into tblfeedback (inquiryid,date,feedback,days,type,nextfollow,status) values ('" + inquiry + "','" + formatdate + "','" + txtfeed.Text + "','" + txtdays.Text + "','" + ddltype.SelectedItem.Text + "','" + next + "','" + ddlstatus.SelectedItem.Text + "')");
            }
            ts.Complete();
            
            ts.Dispose();

            sms("New Enquiry(" + txtname.Text + ") and M:(" + txtcontact.Text + ") Next FollowUp :(" +Convert.ToDateTime(next).ToString("dd/MM/yyyy") + ") Status : ("+ddlstatus.SelectedItem.Text+")");
            if (txtcontact.Text != "")
            {
                smsclient("Thank You " + txtname.Text + " For Visit Kohli Star Image School", txtcontact.Text);
            }
            clear();
        }
    }

    private void DateFormat()
    {
        DateTime date = new DateTime();
        date = DateTime.ParseExact(txtdate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        formatdate = date.ToString("MM/dd/yyyy");
    }
    protected void clear()
    {
        txtname.Text = "";
        txtfname.Text = "";
        txtaddress.Text = "";
        txtfeed.Text = "";
        txtcontact.Text = "";
        ddlcourse.SelectedIndex = 0;
        txtref.Text = "";
        ddltype.SelectedIndex = 0;
        txtdays.Text = "";
        inquiry = GenerateInquiry();
        
    }
    protected string GenerateInquiry()
    {
        string LeadNo = "";

        string id = objsql.GetSingleValue("select max(id) from tblinquiry ").ToString();
        if (id == "")
        {
            return "I_101";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select inquiryid from tblinquiry where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo.Replace("I_", "0"));
            oldlead += 1;

            return "I_" + oldlead.ToString();

        }




    }
    protected void data(string id)
    {
        bind();
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblinquiry where inquiryid='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            txtaddress.Text = dt.Rows[0]["address"].ToString();
            txtcontact.Text = dt.Rows[0]["contact"].ToString();
            txtdate.Text = dt.Rows[0]["date"].ToString();
            txtdays.Text = dt.Rows[0]["address"].ToString();
            txtfeed.Text = dt.Rows[0]["address"].ToString();
            string course = dt.Rows[0]["course"].ToString();
            ddlcourse.Items.FindByValue(course).Selected = true;
            txtfname.Text = dt.Rows[0]["fname"].ToString();
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtref.Text = dt.Rows[0]["referedby"].ToString();
            txtdate.Text = Convert.ToDateTime(dt.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
        }

        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from tblfeedback where inquiryid='" + id + "' order by id desc");
        if (dt2.Rows.Count > 0)
        {
            ddltype.SelectedItem.Text = dt2.Rows[0]["type"].ToString();
            txtdays.Text=dt2.Rows[0]["days"].ToString();
            txtfeed.Text = dt2.Rows[0]["feedback"].ToString();
            string status = dt2.Rows[0]["status"].ToString();
            ddlstatus.Items.FindByText(status).Selected = true;
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
    protected void smsclient(string Message,string mob)
    {
        DataTable dts = new DataTable();

        dts = objsql.GetTable("select * from tblsms");
        if (dts.Rows.Count > 0)
        {
            objsql.SendSMS(dts.Rows[0]["username"].ToString(), dts.Rows[0]["senderid"].ToString(), mob, Message, dts.Rows[0]["type"].ToString(), dts.Rows[0]["api"].ToString());

        }
    }



}