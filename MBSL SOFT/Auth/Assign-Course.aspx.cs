using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Globalization;
using System.Security.Cryptography;
public partial class Auth_Assign_Course : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static int i = 0, j = 0, a = 0, Count = 0;
    public static string Tm, RollNo, rn, amountinstal, noofinstals, Code, cmd, chkval,time,pretime;
    public static string time2, cid,delete,ids="";
    public int count=0;
    const string passphrase = "password";
    Helper help = new Helper();
    public DataSet dss = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
        {
            
          //  bindcourse();
            bindcoursechange();
            Bindteacher();
            RollNo = objsql.GetSingleValue("Select rollno from tblstudentdata where  id =" + Cache["id"].ToString()).ToString();
            BindStudentCourse();
            if (Request.QueryString["edit"] != "")
            {
               // edit();
            }

        }

    }
    #region Course bind data

    

    protected void bindcoursechange()
    {
        help.BindDropDownList("Select CourseId,CourseName from Course","CourseName","CourseId",ddlCourse);
        DataTable dtc = new DataTable();
        
        help.BindDropDownList("select * from tblroom", "room", "id", ddlroom);
        Panel2.Visible = true;
        Panel3.Visible = true;
        pnlmid.Visible = true;
    }
    public void Bindteacher()
    {
        help.BindDropDownList("select * from tblteacher where status='1'", "teachername", "teachercode", ddlteacher);
        help.BindDropDownList("select * from Batch_Timming", "Time", "Id", ddlbatch);
     


    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {

       // bindtime();
        txtfee.Text = objsql.GetSingleValue("select Fees from course where CourseId='" + ddlCourse.SelectedItem.Value + "'").ToString();
    }

    private void bindtime()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("Select id,Time from Batch_Timming Where CenterCode='" + Session["code"].ToString() + "'");
        string b = Common.Get(objsql.GetSingleValue("Select minHour from Course where CenterCode='" + Session["code"].ToString() + "' and CourseId='" + ddlCourse.SelectedItem.Value + "' "));
        //a = Convert.ToInt32(b);
        //lbltime.Text = b;
        //Tm = "Please Select " + b + " Time Slots";

        grdtest.DataSource = dt2;
        grdtest.DataBind();

        txtfee.Text = Common.Get(objsql.GetSingleValue("select Fees from Course where CourseId='" + ddlCourse.SelectedItem.Value + "' and CenterCode='" + Session["code"].ToString() + "'"));
    } 
    #endregion
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            #region date conversion
            string date = "";
            //string date = "";
            string[] alldatevalues = new string[3];
            if (txtAdmitDate.Text != "")
            {
                alldatevalues = txtAdmitDate.Text.Split("/".ToCharArray());
            }
            if (alldatevalues.Length >= 3)
            {
                date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }


            #endregion
            string time = "";
            Count = 0;
            Tm = "";

            dss = help.Get_DataSet("select * from Student_Course where rollno='" + RollNo + "' and CourseId='"+ddlCourse.SelectedItem.Value+"' and status='1'");
            if (dss.Tables[0].Rows.Count > 0)
            {
                Page.RegisterStartupScript("a", "<script>alert('Course Already Assigned')</script>");

            }



            else
            {
                DataTable dtn = new DataTable();
                try
                {
                    string end = txtStartDate.Text;
                    objsql.ExecuteNonQuery1("insert into Student_Course(RollNo,CourseId,CourseName,Time,Status,AdmitDate,StartDate,Fees,Uid,roomid,enddate) values('" + RollNo
                    + "','" + ddlCourse.SelectedItem.Value + "','" + ddlCourse.SelectedItem.Text + "','" + ddlbatch.SelectedItem.Value + "','1','" + date + "','" + "." + "','" + txtfee.Text + "','" + Session["code"] + "','"+ddlroom.SelectedItem.Text+"','"+datechange(txtStartDate.Text)+"')");
                    DateTime date23 = new DateTime();
                    date23 = DateTime.ParseExact(txtAdmitDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    txtStartDate.Text = date23.AddMonths(1).ToString("MM/dd/yyyy");

                    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" + RollNo + "','" + ddlCourse.SelectedItem.Value + "','','" + txtfee.Text + "','" + date + "','1','" + date + "','" + datechange(end) + "')");


                    objsql.ExecuteNonQuery("insert into Fees_Master(RollNo,CourseId,TotalFees,PaidFees,Date,AlertDate,CenterCode,pending_Fees,noofinstalment,instalmentamount,discount,Status,discountstatus) values('" + RollNo
                       + "','" + ddlCourse.SelectedItem.Value + "','" + txtfee.Text + "',0,'" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + txtStartDate.Text + "','" + Session["code"].ToString() + "','" + txtfee.Text + "','" + noofinstals + "','" + amountinstal + "','0','1','0')");

                    objsql.ExecuteNonQuery("insert into Student_Fee(RollNo,CourseId,CenterCode,TotalFees,TotalPaidFees,FromDate,ToDate,Date,TodayPaidFee,Pending_Fees,noofinstalment,instalmentamount,discount) values('" + RollNo
                        + "','" + ddlCourse.SelectedItem.Value + "','" + Session["code"].ToString() + "','" + txtfee.Text + "',0,'" + date + "','" + date + "','" + DateTime.Now.ToShortDateString() + "',0,0,'" + noofinstals + "','" + amountinstal + "','0')");

                }
                catch (Exception ad)
                {
                    string vMessage = ad.Message.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "ClientScript", "alert('" + vMessage + "');", true);
                }

                a = 0;
                Count = 0;


            }



            clear();

            ts.Complete();
            ts.Dispose();
            BindStudentCourse();

        }
    }
    protected void BindStudentCourse()
    {

        //dtNew = objsql.GetTable("SELECT * FROM Student_Course  where RollNo='"+RollNo+"'");
        //GrdDetail.DataSource = dtNew;
        //GrdDetail.DataBind();

        DataTable dtNew = new DataTable();

        DataTable dt1 = new DataTable();
        rn = objsql.GetSingleValue("Select rollno from tblstudentdata where  id =" + Cache["id"].ToString()).ToString();
        RollNo = objsql.GetSingleValue("Select rollno from tblstudentdata where  id =" + Cache["id"].ToString()).ToString();

        dt1 = objsql.GetTable("select * from student_course where rollno='"+RollNo+"'");


        if (dt1.Rows.Count > 0)
        {
            GrdDetail.DataSource = dt1;
            GrdDetail.DataBind();
        }

        


    }
    protected void GrdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        using (TransactionScope tr=new TransactionScope ())
        {
            if (e.CommandName == "time")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                time2 = arg[1];
                cid = arg[2];
              //  Response.Redirect("Assign-Course.aspx?edit=" + cid);
                edit(cmd);
                Button1.Visible = false;
               
                btnupdatetime.Visible = true;
            }
            if (e.CommandName == "Activate")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                time2 = arg[1];
                cid = arg[2];

                objsql.ExecuteNonQuery1("update Student_Course set Status='Active',Active='1' where id='" + cmd + "'");
                DataTable ds = new DataTable();
              ds= objsql.GetTable("select * from Student_Course where id='" + cmd + "'");
                if (ds.Rows.Count > 0)
                {
                    string ctype = ds.Rows[0]["Type"].ToString();
                    string tcode = ds.Rows[0]["teachercode"].ToString();
                    objsql.ExecuteNonQuery("insert into tbltimehistory(RollNo,courseid,coursetype,teachername,timming,status,Date) values ('" + RollNo + "','" + cid + "','" + ctype + "','" + tcode + "','" + time2 + "','Active Time','" + System.DateTime.Now.ToShortDateString() + "')");

                }


            }
            if (e.CommandName == "Deactivate")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                time2 = arg[1];
                cid = arg[2];

                objsql.ExecuteNonQuery1("update Student_Course set Status='Deactive Time', Active='0' where id='" + cmd + "'");

                objsql.ExecuteNonQuery("update tbltimehistory set Date='" + System.DateTime.Now.ToShortDateString() + "', status='Deactive Time' where RollNo='" + RollNo + "' and courseid='" + cid + "' and timming='" + time2 + "' and status='Active Time'");

            }
            if (e.CommandName == "delete")
            {
                delete = e.CommandArgument.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
            }
            if (e.CommandName == "Start")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                time2 = arg[1];
                cid = arg[2];
                objsql.ExecuteNonQuery1("update Student_Course set Status='Start', Active='1' where CourseId='" + cid + "' and RollNo='"+RollNo+"'");
                objsql.ExecuteNonQuery1("update Fees_Master set Status='1' where CourseId='" + cid + "' and RollNo='" + RollNo + "'");
            }
            if (e.CommandName == "Stop")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                time2 = arg[1];
                cid = arg[2];
                objsql.ExecuteNonQuery1("update Student_Course set Status='Stop', Active='0' where CourseId='" + cid + "' and RollNo='" + RollNo + "'");
                objsql.ExecuteNonQuery1("update Fees_Master set Status='0' where CourseId='" + cid + "' and RollNo='" + RollNo + "'");
            }
            if (e.CommandName == "deactive")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                cmd = arg[0];
                cid = arg[1];
                objsql.ExecuteNonQuery1("update Student_Course set Status='0' where id='"+ arg[0] + "'");
                objsql.ExecuteNonQuery("update tblpendingfee set status='0' where Rollno='" + RollNo + "' and courseid='" + arg[1] + "'");
            }
            tr.Complete();
            tr.Dispose();
        }
        BindStudentCourse();
    }
    protected void btnupdatetime_Click(object sender, EventArgs e)
    {
        string formatdate="",end="";
        DateTime date = new DateTime();
         DateTime date2 = new DateTime();
        date = DateTime.ParseExact(txtAdmitDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        formatdate = date.ToString("MM/dd/yyyy");

        date2 = DateTime.ParseExact(txtStartDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        end = date2.ToString("MM/dd/yyyy");
        objsql.ExecuteNonQuery("update student_course set coursename='" + ddlCourse.SelectedItem.Text + "',courseid='" + ddlCourse.SelectedItem.Value + "', time='" + ddlbatch.SelectedItem.Value + "',admitdate='" + formatdate + "',enddate='"+end+"',Fees='" + txtfee.Text + "' where id='" + cmd + "'");
        Response.Redirect("Assign-course.aspx");
    }


    #region Assing New Time

    protected void asigncourse()
    {
        DataTable dtb = new DataTable();
        dtb = objsql.GetTable("Select distinct CourseId,CourseName from Student_Course where RollNo='" + RollNo+ "' and CenterCode='" + Session["code"].ToString() + "'");
        ddlasigncourse.DataSource = dtb;

        ddlasigncourse.DataTextField = "CourseName";
        ddlasigncourse.DataValueField = "CourseId";
        ddlasigncourse.DataBind();
        ddlasigncourse.Items.Insert(0, "-- Select Course --");
    }
    #endregion
    protected void lnkassign_Click(object sender, EventArgs e)
    {
        asigncourse();
        Bindteacher();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }
    protected void ddlasigncourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt21 = new DataTable();
        dt21 = objsql.GetTable("Select id,Time from Batch_Timming Where CenterCode='" + Session["code"].ToString() + "'");
        if (dt21.Rows.Count > 0)
        {
            lvtime.DataSource = dt21;
            lvtime.DataBind();

        }

    }
    protected void lvtime_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label lbid = (Label)e.Item.FindControl("lblaid");
            CheckBox chk = (CheckBox)e.Item.FindControl("chka");

            string chktimeasign = Common.Get(objsql.GetSingleValue("select Time from Student_Course where Time='" + lbid.Text + "' and RollNo='" + RollNo + "' and CenterCode='" + Session["code"].ToString() + "'"));
            if (chktimeasign==lbid.Text)
            {
                chk.Enabled = false;
            }
            
        }
    }
    
    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbadmit = (Label)e.Row.FindControl("lbladmitdate");
            Label end = (Label)e.Row.FindControl("lblend");

            lbadmit.Text = DateTime.Parse(lbadmit.Text).ToString("dd/MM/yyyy");
            end.Text = DateTime.Parse(end.Text).ToString("dd/MM/yyyy");

        }
    }
    protected void clear()
    {
        ddlCourse.SelectedIndex = 0;
     //   ddlcoursetype.SelectedIndex = 0;
        ddlteacher.SelectedIndex = 0;
        txtfee.Text = "0";
        txtAdmitDate.Text = "";
        txtStartDate.Text = "";
    }
    protected void GrdDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup2();", true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        using (TransactionScope ts2=new TransactionScope ())
        {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from tblPassword where Password='" + EncryptData(txtname.Value) + "' and Page_name='Course'");
            if (dt.Rows.Count > 0)
            {
                int i, j;
                i = objsql.ExecuteNonQuery1("delete from Student_Course where RollNo='"+RollNo+"' and CourseId='"+delete+"' and CenterCode='"+Session["code"].ToString()+"'");
                i = objsql.ExecuteNonQuery1("delete  from Student_Course_Master where RollNo='" + RollNo + "' and CourseId='" + delete + "' and CenterCode='" + Session["code"].ToString() + "'");
                i = objsql.ExecuteNonQuery1("delete  from Student_Fee where RollNo='" + RollNo + "' and CourseId='" + delete + "' and CenterCode='" + Session["code"].ToString() + "'");
                j = objsql.ExecuteNonQuery1("delete  from Fees_Master where RollNo='" + RollNo + "' and CourseId='" + delete + "' and CenterCode='" + Session["code"].ToString() + "'");
                j = objsql.ExecuteNonQuery1("delete  from Recipt_Details where RollNo='" + RollNo + "' and CourseId='" + delete + "' and CenterCode='" + Session["code"].ToString() + "'");

                if (j > 0)
                {
                    Page.RegisterStartupScript("d", "<script>alert('Record Deleted Successfully!!')</script>");
                }
                else
                {
                    Page.RegisterStartupScript("d", "<script>alert('Record Not Deleted!!')</script>");

                }
                BindStudentCourse();
            }
            else
            {
                ts2.Dispose();
                Page.RegisterStartupScript("d", "<script>alert('Wrong Password Please Try Again')</script>");
            }

            ts2.Complete();
           // ts2.Dispose();
        }

    }
    public static string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
       
    }
    protected void tt_Click(object sender, EventArgs e)
    {
        using (TransactionScope tt = new TransactionScope())
        {
            DataTable dt12 = new DataTable();
            dt12 = objsql.GetTable("select * from Student_Course where CourseId='" + ddlasigncourse.SelectedItem.Value + "' and RollNo='" + RollNo + "' and CenterCode='" + Session["code"].ToString() + "'");
            if (dt12.Rows.Count > 0)
            {
                foreach (ListViewItem lv in lvtime.Items)
                {
                    CheckBox ck1 = (CheckBox)lv.FindControl("chka");

                    if (ck1.Checked == true)
                    {
                        Label ltime = (Label)lv.FindControl("lblaid");

                        objsql.ExecuteNonQuery("insert into Student_Course(RollNo,CourseId,CourseName,Time,Status,Admitdate,StartDate,CenterCode,Type,Active,teachercode,course_complete) values ('" + dt12.Rows[0]["RollNo"] + "','" + ddlasigncourse.SelectedItem.Value + "','" + ddlasigncourse.SelectedItem.Text + "','" + ltime.Text + "','Active','" + dt12.Rows[0]["Admitdate"] + "','" + dt12.Rows[0]["StartDate"] + "','" + Session["code"].ToString() + "','" + dt12.Rows[0]["Type"] + "','1','" + ddlasignteacher.SelectedItem.Value + "','1')");
                        objsql.ExecuteNonQuery("insert into tbltimehistory(RollNo,courseid,coursetype,teachername,timming,status,Date) values ('" + RollNo + "','" + ddlasigncourse.SelectedItem.Value + "','" + dt12.Rows[0]["Type"] + "','" + ddlasignteacher.SelectedItem.Value + "','" + ltime.Text + "','Active Time','" + System.DateTime.Now.ToShortDateString() + "')");
                    }
                }

            }
            tt.Complete();
            tt.Dispose();
        }
    }
    protected void grdtest_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void edit(string id)
    {
        DataTable ds = new DataTable();
        ds = objsql.GetTable("select * from Student_Course where id='" + id + "'");
        if (ds.Rows.Count > 0)
        {
            //  bindcoursechange();
            ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(ds.Rows[0]["courseid"].ToString()));
            txtfee.Text = ds.Rows[0]["fees"].ToString();

            string datead = ds.Rows[0]["admitdate"].ToString();
            string enddate = ds.Rows[0]["enddate"].ToString();
            txtAdmitDate.Text = Convert.ToDateTime(datead).ToString("dd/MM/yyyy");
            txtStartDate.Text = Convert.ToDateTime(enddate).ToString("dd/MM/yyyy");
            ddlbatch.SelectedItem.Value = ds.Rows[0]["time"].ToString();
            ddlroom.SelectedItem.Text = ds.Rows[0]["roomid"].ToString();
        }
    }
    public string datechange(string date2)
    {
        string newdate = "";
        if (date2 != "")
        {
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(date2, "dd/MM/yyyy", null);
            newdate = myDateTime.ToString("MM/dd/yyyy"); // add myString_new to oracle

        }
        return newdate;

    }
}