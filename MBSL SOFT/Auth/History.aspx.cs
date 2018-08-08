using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Auth_History : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string RollNo = "";
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
            RollNo = objsql.GetSingleValue("Select rollno from tblstudentdetail where centercode='" + lblcode.Text + "' and id =" + Cache["id"].ToString()).ToString();
            bind();
            BindStudentCourse();
        }
    }
    protected void bind()
    {
        DataSet ds=new DataSet ();
       ds= objsql.GetDataset("select h.Date,CourseName,t.teachername,b.Time,h.status from tbltimehistory h , Course c,tblteacher t,Batch_Timming b where h.courseid=c.CourseId and h.RollNo='"+RollNo+"' and h.teachername=t.teachercode and b.Id= h.timming");
       if (ds.Tables[0].Rows.Count > 0)
       {
           gvhistory.DataSource = ds;
           gvhistory.DataBind();
       }
    }
    protected void BindStudentCourse()
    {

        //dtNew = objsql.GetTable("SELECT * FROM Student_Course  where RollNo='"+RollNo+"'");
        //GrdDetail.DataSource = dtNew;
        //GrdDetail.DataBind();

        DataTable dtNew = new DataTable();

        DataTable dt1 = new DataTable();
       string rn = objsql.GetSingleValue("Select rollno from tblstudentdetail where centercode='" + lblcode.Text + "' and id =" + Cache["id"].ToString()).ToString();
        RollNo = objsql.GetSingleValue("Select rollno from tblstudentdetail where centercode='" + lblcode.Text + "' and id =" + Cache["id"].ToString()).ToString();

        dt1 = objsql.GetTable("select s.id,s.RollNo,s.CourseId,s.CourseName,s.Time,s.Status,s.Admitdate,s.StartDate,s.CenterCode,s.Type,s.Active,t.teachername from Student_Course s,tblteacher t where s.RollNo='" + RollNo + "' and s.CenterCode='" + lblcode.Text + "' and t.teachercode=s.teachercode and s.course_complete='0' order by s.Time");

        dtNew.Columns.Add(new DataColumn("id", typeof(int)));
        dtNew.Columns.Add(new DataColumn("RollNo", typeof(string)));

        dtNew.Columns.Add(new DataColumn("CourseName", typeof(string)));
        dtNew.Columns.Add(new DataColumn("Time", typeof(string)));
        dtNew.Columns.Add(new DataColumn("Status", typeof(string)));
        dtNew.Columns.Add(new DataColumn("AdmitDate", typeof(string)));
        dtNew.Columns.Add(new DataColumn("StartDate", typeof(string)));
        dtNew.Columns.Add(new DataColumn("Type", typeof(string)));
        dtNew.Columns.Add(new DataColumn("Teachercode", typeof(string)));
        dtNew.Columns.Add(new DataColumn("Active", typeof(string)));
        dtNew.Columns.Add(new DataColumn("CourseId", typeof(string)));

        if (dt1.Rows.Count > 0)
        {
            // int Timeid=0;
            string Time = "", Timeid = "";
            foreach (DataRow dr in dt1.Rows)
            {

                // Timeid=Convert.ToInt32(dr[4]);
                Timeid = dr[4].ToString();
                Time = Common.Get(objsql.GetSingleValue("select Time from Batch_Timming where id=" + Timeid));

                DataRow dr1 = dtNew.NewRow();
                dr1["id"] = Convert.ToInt32(dr[0]);
                dr1["RollNo"] = dr[1].ToString();
                dr1["CourseName"] = dr[3].ToString();
                dr1["Type"] = dr[9].ToString();
                dr1["Time"] = Time;
                dr1["Status"] = dr[5].ToString();
                dr1["AdmitDate"] = dr[6].ToString();
                dr1["StartDate"] = dr[7].ToString();
                dr1["Teachercode"] = dr[11].ToString();
                dr1["Active"] = dr[10].ToString();
                dr1["CourseId"] = dr[2].ToString();
                dtNew.Rows.Add(dr1);
            }
        }

        GrdDetail.DataSource = dtNew;
        GrdDetail.DataBind();


    }
}