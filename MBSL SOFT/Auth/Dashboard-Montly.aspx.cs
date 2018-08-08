using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Dashboard_Montly : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string month = "", timecheck, from = "", to = "", paidfee = "", rollno = "", courseid = "", formatdate = "", Token = "", pid = "", pendos = "";
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        timecheck = "";
        if (Session["Admin"] != "")
        {
            dt = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fathername,s.phone,f.alertdate,d.coursename,c.courseid from tblstudentdata s , student_course c ,fees_master f,course d where c.CourseId=f.CourseId and f.courseid=d.courseid and s.rollno=f.RollNo and s.status='1' and (convert(datetime, f.[AlertDate], 120) <= convert(datetime,'" + System.DateTime.Now.ToString("MM/dd/yyyy") + "', 120))");

        }
        else
        {


            dt = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fathername,s.phone,f.alertdate,d.coursename,c.courseid from tblstudentdata s , student_course c ,fees_master f,course d where c.CourseId=f.CourseId and f.courseid=d.courseid and s.rollno=f.RollNo and s.status='1' and (convert(datetime, f.[AlertDate], 120) <= convert(datetime,'" + System.DateTime.Now.ToString("MM/dd/yyyy") + "', 120))");
        }
        if (dt.Rows.Count > 0)
        {
            GrdDetail.DataSource = dt;
            GrdDetail.DataBind();

        }
        string datex = System.DateTime.Now.AddDays(5).ToString("MM/dd/yyyy");
       
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        try
        {
            if (ddlCourse.SelectedIndex != 0 && ddltime.SelectedIndex == 0)
            {
                dt2 = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fname,s.contact,c.CourseName,c.CourseId,f.TotalFees,f.PaidFees,f.AlertDate,cc.instalment_amount as paid from tblstudentdetail s, Fees_Master f,Student_Course c, Batch_Timming b,Course cc where c.CourseId=f.CourseId and s.rollno=f.RollNo  and (convert(datetime, f.[AlertDate], 120) <= convert(datetime,'" + System.DateTime.Now.ToShortDateString() + "' , 120))  and s.Activate='1' and c.CenterCode='" + lblcode.Text + "' and cc.CourseId=c.CourseId and c.CourseId='" + courseid + "' and c.Active='1'and f.TotalFees!=f.PaidFees and f.Status='1'");
            }
            else if (ddltime.SelectedIndex != 0 && ddlCourse.SelectedIndex == 0)
            {
                GrdDetail.DataSource = null;
                GrdDetail.DataBind();
                dt2.Clear();
                timecheck = "";
                timecheck = ddltime.SelectedItem.Value;
                dt2 = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fname,s.contact,c.CourseName,c.CourseId,f.TotalFees,f.PaidFees,f.AlertDate,cc.instalment_amount as paid from tblstudentdetail s, Fees_Master f,Student_Course c, Batch_Timming b,Course cc where c.CourseId=f.CourseId and s.rollno=f.RollNo  and (convert(datetime, f.[AlertDate], 120) <= convert(datetime,'" + System.DateTime.Now.ToShortDateString() + "' , 120))  and s.Activate='1' and c.CenterCode='" + lblcode.Text + "' and cc.CourseId=c.CourseId and  c.time='" + ddltime.SelectedItem.Value + "' and c.Active='1'and f.TotalFees!=f.PaidFees and f.Status='1'");
            }
            else if (ddltime.SelectedIndex != 0 && ddlCourse.SelectedIndex != 0)
            {
                dt2 = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fname,s.contact,c.CourseName,c.CourseId,f.TotalFees,f.PaidFees,f.AlertDate,cc.instalment_amount as paid from tblstudentdetail s, Fees_Master f,Student_Course c, Batch_Timming b,Course cc where c.CourseId=f.CourseId and s.rollno=f.RollNo  and (convert(datetime, f.[AlertDate], 120) <= convert(datetime,'" + System.DateTime.Now.ToShortDateString() + "' , 120))  and s.Activate='1' and c.CenterCode='" + lblcode.Text + "' and cc.CourseId=c.CourseId and c.CourseId='" + courseid + "' and  c.time='" + ddltime.SelectedItem.Value + "' and c.Active='1'and f.TotalFees!=f.PaidFees and f.Status='1'");

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            GrdDetail.PagerSettings.Visible = false;
            GrdDetail.PageSize = 500;
            GrdDetail.DataSource = dt2;
            GrdDetail.DataBind();
        }


    }
    protected void bindcoursechange()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("Select CourseId,CourseName from Course where CenterCode='" + lblcode.Text + "'");
        ddlCourse.DataSource = dt;

        ddlCourse.DataTextField = "CourseName";
        ddlCourse.DataValueField = "CourseId";
        ddlCourse.DataBind();
        ddlCourse.Items.Insert(0, "-- Select Course --");

    }

    protected void bindtime()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("Select Id,Time from Batch_Timming where centercode='" + lblcode.Text + "'");
        ddltime.DataSource = dt;

        ddltime.DataTextField = "Time";
        ddltime.DataValueField = "Id";
        ddltime.DataBind();
        ddltime.Items.Insert(0, "-- Select Time --");

    }
    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // int index = Convert.ToInt32(e.Row);
            Label lbalert = (Label)e.Row.FindControl("lblalert");
            Label lblinstal = (Label)e.Row.FindControl("lblmnth");
            Label rollno = (Label)e.Row.FindControl("lblroll");
            Label cid = (Label)e.Row.FindControl("lblcid");
            lbalert.Text = DateTime.Parse(lbalert.Text).ToString("dd/MM/yyyy");
            //string maxid = Common.Get(objsql.GetSingleValue("select max(id) from student_fee where RollNo='" + rollno.Text + "' and CourseId='" + cid.Text + "'"));
            //string duefee = Common.Get(objsql.GetSingleValue("select duenxtfee from student_fee where id='"+maxid+"'"));
            //if (!string.IsNullOrEmpty(duefee))
            //{
            //    lblinstal.Text = duefee;
            //}

            //string[] alldatevalues3 = new string[3];

            //if (lbalert.Text != "" && lbalert.Text != null)
            //{
            //    alldatevalues3 = lbalert.Text.Split("/".ToCharArray());

            //    if (alldatevalues3.Length >= 3)
            //    {
            //        month = alldatevalues3[1].Trim();

            //    }
            //}
            //DateTime myDateTime = DateTime.Now;
            //string nowmonth = System.DateTime.Now.ToShortDateString();
            //string[] alldatevalues = new string[3];

            //if (nowmonth != "" && nowmonth != null)
            //{
            //    alldatevalues = nowmonth.Split("/".ToCharArray());

            //    if (alldatevalues.Length >= 3)
            //    {
            //        nowmonth = alldatevalues[0].Trim();

            //    }
            //}

            //if ( Convert.ToInt32(nowmonth) > Convert.ToInt32(month))
            //{
            //    string datediff = (Convert.ToInt32(nowmonth) - Convert.ToInt32(month)).ToString();
            //    int diff = Convert.ToInt32(datediff);
            //    lblinstal.Text = (Convert.ToInt32(lblinstal.Text) * diff).ToString();
            //}
            //if (!string.IsNullOrEmpty(timecheck))
            //{
            //    string Time = Common.Get(objsql.GetSingleValue("select Time from Student_Course where RollNo='" + rollno.Text + "' and CourseId='" + cid.Text + "'"));
            //    if (timecheck != Time)
            //    {
            //        e.Row.Visible = false;
            //    }
            //}
            //DataTable dtcheck = new DataTable();
            //dtcheck = objsql.GetTable("select * from Fees_Master where RollNo='" + rollno.Text + "' and CourseId='" + cid.Text + "'");
            //if(dtcheck.Rows.Count>0)
            //{
            //    int tofee =Convert.ToInt32( dtcheck.Rows[0]["TotalFees"]);
            //    int pfee = Convert.ToInt32(dtcheck.Rows[0]["PaidFees"]);
            //    int disc=Convert.ToInt32(dtcheck.Rows[0]["discount"]);
            //    int afdis = pfee + disc;
            //    if (tofee == afdis)
            //    {
            //        e.Row.Visible = false;
            //    }
            //}
        }


    }
    protected void GrdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDetail.PageIndex = e.NewPageIndex;
        bind();
    }
    protected void GrdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Profile")
        {
            Cache.Remove("id");
            Cache["id"] = e.CommandArgument.ToString();
            Response.Redirect("Assign-Course.aspx");
        }

    }
}