using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Dashboard_Dayalert : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static DataTable dtall = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        
        string datex = System.DateTime.Now.AddDays(5).ToString("MM/dd/yyyy");
        
        dtall = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fathername,s.phone,c.coursename,c.courseid,c.enddate from tblstudentdata s , student_course c  where  s.rollno=c.RollNo and s.status='1' and c.status='1' and (convert(datetime, c.[enddate], 120) <= convert(datetime,'" + datex + "' , 120))");
        if (dtall.Rows.Count > 0)
        {
            GridView2.DataSource = dtall;
            GridView2.DataBind();
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label alert = (Label)e.Row.FindControl("lblalert");
            Label left = (Label)e.Row.FindControl("lblleft");
            if (alert != null)
            {
                string nowdate = System.DateTime.Now.ToString("MM/dd/yyyy");
                left.Text = (Convert.ToDateTime(alert.Text).Day - Convert.ToDateTime(nowdate).Day).ToString();
                int mnthdiff = (Convert.ToDateTime(alert.Text).Month - Convert.ToDateTime(nowdate).Month);
                int yeardiff = (Convert.ToDateTime(alert.Text).Year - Convert.ToDateTime(nowdate).Year);
                if (mnthdiff > 0 && yeardiff >=0)
                {
                    left.Text = (Convert.ToInt32(left.Text)).ToString();
                    e.Row.Visible = false;
                }
                else
                {
                    DateTime d1;
                    DateTime d2;
                    d1 = Convert.ToDateTime(alert.Text);
                    d2 = Convert.ToDateTime(nowdate);
                    // Difference in days, hours, and minutes.
                    TimeSpan ts = d2 - d1;
                    // Difference in days.
                    int differenceInDays = ts.Days;
                    int years = (int)(ts.Days / 365.25);
                    int months = ts.Days / 31;
                    left.Text = (Convert.ToInt32(differenceInDays) * Convert.ToInt32(-1)).ToString();
                }
            }
            alert.Text = Convert.ToDateTime(alert.Text).ToString("dd/MM/yyyy");
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Profile")
        {
            Cache.Remove("id");
            Cache["id"] = e.CommandArgument.ToString();
            Response.Redirect("Assign-Course.aspx");
        }
        if (e.CommandName == "con")
        {
            DataTable dtm = new DataTable();
            dtm = objsql.GetTable("select * from student_course where rollno=" + e.CommandArgument);
            if (dtm.Rows.Count > 0)
            {
                DateTime end = Convert.ToDateTime(dtm.Rows[0]["enddate"]);
                DateTime start = Convert.ToDateTime(dtm.Rows[0]["admitdate"]);
                string roll = dtm.Rows[0]["rollno"].ToString();
                string cid = dtm.Rows[0]["courseid"].ToString();
                string fees = dtm.Rows[0]["fees"].ToString();
                if (end != null && start != null)
                {
                    double days = (end.Date - start.Date).TotalDays;
                    string date =Convert.ToDateTime(end.AddDays(days)).ToString("MM/dd/yyyy");
                    objsql.ExecuteNonQuery("update student_course set enddate='" + date + "' where rollno='" + e.CommandArgument.ToString() + "'");
                    objsql.ExecuteNonQuery("update tblpendingfee set status='0' where rollno='" + roll + "' and courseid='" + cid + "'");

                    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" +roll + "','" + cid + "','','" + fees + "','" + start.ToString("MM/dd/yyyy") + "','1','" + start.ToString("MM/dd/yyyy") + "','" + end.ToString("MM/dd/yyyy") + "')");

                }
            }
        }
        bind();

   }
}