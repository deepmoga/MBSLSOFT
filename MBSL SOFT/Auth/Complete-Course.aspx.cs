using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Transactions;
public partial class Auth_Complete_Course : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable dt = new DataTable();
    //public DateTime future = new DateTime();
    public string future;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("~/Auth/Login.aspx");
        if (Session["Franchisee"] != null)
        {
            lblcode.Text = Session["Franchisee"].ToString();
        }
        if (Session["Receptionist"] != null)
        {
            lblcode.Text = Session["Receptionist"].ToString();
        }
        if (Session["Admin"] != null)
        {
            lblcode.Text = Request.QueryString["type"];
            //Session["Admin"] = Request.QueryString["type"].ToString();
        }
        if (Session["Red Cross Franchisee"] != null)
        {
            lblcode.Text = Session["Red Cross Franchisee"].ToString();


        }
        if (Session["Red Cross Receptionist"] != null)
        {
            lblcode.Text = Session["Red Cross Receptionist"].ToString();


        }
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select distinct s.rollno,s.name,s.fname,C.CourseName,c.CourseId,c.StartDate,s.Activate from tblstudentdetail s , Student_Course c where s.rollno=c.RollNo and c.course_complete!='0'" );
        if (dt.Rows.Count > 0)
        {
            gvhistory.DataSource = dt;
            gvhistory.DataBind();

        }

    }
    protected void gvhistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label date = (Label)e.Row.FindControl("lblstart");
            Label cid = (Label)e.Row.FindControl("lblcid");
            Label com = (Label)e.Row.FindControl("lblcom");

            try
            {

                string duration = Common.Get(objsql.GetSingleValue("select Duration from Course where CourseId='" + cid.Text + "' and centercode='" + lblcode.Text + "'"));
                if (!string.IsNullOrEmpty(duration))
                {
                    int time = Convert.ToInt32(duration);
                    if (time == 1)
                    {
                        DateTime ds = Convert.ToDateTime(date.Text);

                        future = Convert.ToDateTime(ds.AddYears(time)).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        DateTime ds = Convert.ToDateTime(date.Text);
                        future = Convert.ToDateTime(ds.AddMonths(time)).ToString("MM/dd/yyyy");

                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // DateTime fut = DateTime.ParseExact(future, "MM/dd/yyyy", null);
                com.Text = future;
                DateTime ctime = DateTime.ParseExact(com.Text, "MM/dd/yyyy", null);
                DateTime now = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                if (ctime >= now)
                {
                    e.Row.Visible = false;
                }
            }


        }
    }
    protected void chkcom_CheckedChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvhistory.Rows)
        {
            Label comcheck = (Label)row.FindControl("lblcom");

            DateTime ctime = DateTime.ParseExact(comcheck.Text, "MM/dd/yyyy", null);
            DateTime now = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            if (ctime >= now)
            {
                row.Visible = false;
            }
        }


    }
    protected void gvhistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "com")
        {
            using ( TransactionScope ex=new TransactionScope ())
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                string roll = arg[0];
                string ccid = arg[1];
                string sdate = arg[2];
                string duration = Common.Get(objsql.GetSingleValue("select Duration from Course where CourseId='" + ccid + "' and centercode='" + lblcode.Text + "'"));
                if (!string.IsNullOrEmpty(duration))
                {
                    int time = Convert.ToInt32(duration);
                    if (time == 1)
                    {
                        DateTime ds = Convert.ToDateTime(sdate);

                        future = Convert.ToDateTime(ds.AddYears(time)).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        DateTime ds = Convert.ToDateTime(sdate);
                        future = Convert.ToDateTime(ds.AddMonths(time)).ToString("MM/dd/yyyy");

                    }
                    DateTime timec = DateTime.ParseExact(future, "MM/dd/yyyy", null);
                    DateTime todaynow = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    if (timec <= todaynow)
                    {
                        DataTable dtfee = new DataTable();
                        dtfee = objsql.GetTable("select TotalFees,PaidFees,discount from Fees_Master where RollNo='" + roll + "' and CourseId='" + ccid + "' and CenterCode='" + lblcode.Text + "' ");
                        if (dtfee.Rows.Count > 0)
                        {
                            string paytot = (Convert.ToInt32(dtfee.Rows[0]["PaidFees"]) + Convert.ToInt32(dtfee.Rows[0]["discount"])).ToString();
                            if (Convert.ToInt32(dtfee.Rows[0]["TotalFees"]) == Convert.ToInt32(paytot))
                            {
                                objsql.ExecuteNonQuery("update Fees_Master set course_complete='0' where RollNo='" + roll + "' and CourseId='" + ccid + "' and CenterCode='" + lblcode.Text + "'  ");
                                objsql.ExecuteNonQuery("update Student_Course set course_complete='0' where RollNo='" + roll + "' and CourseId='" + ccid + "' and CenterCode='" + lblcode.Text + "'  ");
                                objsql.ExecuteNonQuery("update Student_Fee set course_complete='0' where RollNo='" + roll + "' and CourseId='" + ccid + "' and CenterCode='" + lblcode.Text + "'  ");
                            }
                            else
                            {
                                Page.RegisterStartupScript("a", "<script>alert('Fees Does not Clear')</script>");
                            }
                        }
                    }
                    else
                    {
                        Page.RegisterStartupScript("a", "<script>alert('Sorry Course Complete Time Does not match')</script>");
                    }
                }
                ex.Complete();

            } 
        }
        if (e.CommandName.ToString() == "Deactivate")
        {
            objsql.ExecuteNonQuery("update tblstudentdetail set Activate=0 where rollno='" + e.CommandArgument + "'");

        }

        if (e.CommandName.ToString() == "Activate")
        {
            objsql.ExecuteNonQuery("update tblstudentdetail set Activate=1 where rollno='" + e.CommandArgument+"'");

        }
        bind();
    }
}