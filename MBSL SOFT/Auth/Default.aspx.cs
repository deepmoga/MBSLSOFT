using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Transactions;
public partial class Auth_Default : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable dt = new DataTable();
    public static bool edit = false;
    public static string month = "", timecheck, from = "", to = "", paidfee = "", rollno = "", courseid = "", formatdate="",Token="",pid="",pendos="";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Admin"] == "")
        //{
        //    Response.Redirect("login.aspx");
        //}


        if (!Page.IsPostBack)
        {
            txtdate2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            string datex = System.DateTime.Now.AddDays(5).ToString("MM/dd/yyyy");
            lbldaily.Text = Common.Get(objsql.GetSingleValue("select count(s.id) from tblstudentdata s , student_course c  where  s.rollno=c.RollNo and s.status='1' and c.status='1' and (convert(datetime, c.[enddate], 120) <= convert(datetime,'" + datex + "' , 120))"));
            lblpendo.Text = Common.Get(objsql.GetSingleValue("select count(f.id) from tblstudentdata s , tblpendingfee f , Course c,student_course sc where s.rollno=f.RollNo and c.CourseId=f.CourseId and (convert(datetime, f.[alertdate], 120) <= convert(datetime,'" + changedate(txtdate2.Text) + "' , 120)) and f.alertdate!='' and f.status='1' and s.status='1' and sc.status='1' and sc.rollno=f.rollno"));
            lblenq.Text = Common.Get(objsql.GetSingleValue("select count(f.inquiryid) from tblinquiry i , tblfeedback f where f.nextfollow<='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' and f.status='Active' and i.inquiryid=f.inquiryid"));
            edit = false;
            if (Session["Admin"] != null)
            {
                dt = objsql.GetTable("select * from tblsoftpage");
                if (dt.Rows.Count > 0)
                {
                    lvpages.DataSource = dt;
                    lvpages.DataBind();
                }
            }
            if (Session["role"] == "franch")
            {
                dt = objsql.GetTable("select s.pname,s.url from tblsoftpage s , tblroles r where r.pageid=s.id and r.rid='" + Session["code"] + "'");
                if (dt.Rows.Count > 0)
                {
                    lvpages.DataSource = dt;
                    lvpages.DataBind();
                }

            }




            bind();
           // bindcoursechange();
            //bindtime();
            bindpending();
            inquiry();

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
        DataTable dtall = new DataTable();
        dtall = objsql.GetTable("select distinct s.id,s.rollno,s.name,s.fathername,s.phone,c.coursename,c.courseid,c.enddate from tblstudentdata s , student_course c  where  s.rollno=c.RollNo and s.status='1' and c.status='1' and (convert(datetime, c.[enddate], 120) <= convert(datetime,'" + datex + "' , 120))");
        if (dtall.Rows.Count > 0)
        {
            GridView2.DataSource = dtall;
            GridView2.DataBind();
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
    protected void bindpending()
    {
        DataTable dtp = new DataTable();
        dtp = objsql.GetTable("select distinct f.id,s.id as rid,s.rollno,s.name,s.fathername,c.CourseName,f.fees,f.alertdate from tblstudentdata s , tblpendingfee f , Course c,student_course sc where s.rollno=f.RollNo and c.CourseId=f.CourseId and (convert(datetime, f.[alertdate], 120) <= convert(datetime,'"+changedate(txtdate2.Text)+"' , 120)) and f.alertdate!='' and f.status='1' and s.status='1' and sc.status='1' and sc.rollno=f.rollno");
        if (dtp.Rows.Count > 0)
        {
            gvpending.DataSource = dtp;
            gvpending.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvpending.DataSource = dt;
            gvpending.DataBind();  
        }
    }
    protected void gvpending_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvpending.EditIndex = e.NewEditIndex;
        edit = true;
        bindpending();  

    }
    protected void gvpending_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvpending.EditIndex = -1;

        //Call ShowData method for displaying updated data  
        bindpending();  

    }
    protected void gvpending_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = gvpending.Rows[e.RowIndex].FindControl("lblid") as Label;
        TextBox date = gvpending.Rows[e.RowIndex].FindControl("txtdate") as TextBox;
        DateTime myDateTime = new DateTime();
        myDateTime = DateTime.ParseExact(date.Text, "dd/MM/yyyy", null);
        String date23 = myDateTime.ToString("MM/dd/yyyy"); // add myString_new to oracle

        objsql.ExecuteNonQuery("update tblpendingfee set alertdate='" + date23 + "' where id='" + id.Text + "'");
        gvpending.EditIndex = -1;
        bindpending();
    }
    protected void gvpending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "pay")
        {
            pid = e.CommandArgument.ToString();
            txtddate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            pendingfeesdata(e.CommandArgument.ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //string[] arg = new string[2];
            //arg = e.CommandArgument.ToString().Split(',');
            //Cache["roll"] = arg[0];
            //Cache["id"] = arg[1];
            //Response.Redirect("Deposit-Fee.aspx");
        }
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
    protected void inquiry()
    {
        dt = objsql.GetTable("select distinct f.inquiryid,f.id,f.date,i.name,i.contact,f.feedback from tblinquiry i , tblfeedback f where f.nextfollow<='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "' and f.status='Active' and i.inquiryid=f.inquiryid");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            Response.Redirect("Visitor-Detail.aspx?id=" + e.CommandArgument.ToString());
        }
    }
    protected void gvpending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (edit == false)
        //    {
        //        Label date = (Label)e.Row.FindControl("lblpdate");

        //        if (date.Text != null)
        //        {
        //            DateTime myDateTime = new DateTime();
        //            myDateTime = DateTime.ParseExact(date.Text, "MM/dd/yyyy", null);
        //            date.Text = myDateTime.ToString("dd/MM/yyyy");
        //        }
        //    }
        //    else
        //    {

        //        TextBox edate = (TextBox)e.Row.FindControl("txtdate");
        //        Label edate = (Label)e.Row.FindControl("lbledate");
        //        if (edate.Text != null)
        //        {
        //            DateTime myDateTime = new DateTime();
        //            myDateTime = DateTime.ParseExact(edate.Text, "MM/dd/yyyy", null);
        //            edate.Text = myDateTime.ToString("dd/MM/yyyy");
        //        }
        //    }

        //    if (edate.Text != null)
        //    {
        //        DateTime myDateTime = new DateTime();
        //        myDateTime = DateTime.ParseExact(edate.Text, "MM/dd/yyyy", null);
        //        edate.Text = myDateTime.ToString("dd/MM/yyyy");
        //    }


        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        checkrecipt();
        if (Convert.ToDecimal(txtamt.Text) <= Convert.ToDecimal(paidfee))
        {
            if (Convert.ToDecimal(txtamt.Text) < Convert.ToDecimal(paidfee))
            {
                decimal check = (Convert.ToDecimal(txtamt.Text) + Convert.ToDecimal(txtpfees.Text));
                if (check == Convert.ToDecimal(paidfee))
                {
                    insertpaid();
                }

                else
                {
                    (this.Master as Auth_main).ShowMessage("You are Entered Wrong Amount", Auth_main.MessageType.Error);
                }
            }
            else
            {
                insertpaid();
            }
        }
        else
        {
            (this.Master as Auth_main).ShowMessage("Enter Wrong Amount Please Check Again", Auth_main.MessageType.Error);
        }
       
    }
    protected void pendingfeesdata(string id)
    {
        checkrecipt();

        DataTable dtp = new DataTable();
        dtp = objsql.GetTable("select * from tblpendingfee where id='" + id + "'");
        if (dtp.Rows.Count > 0)
        {
            rollno = dtp.Rows[0]["rollno"].ToString();
            courseid = dtp.Rows[0]["courseid"].ToString();
            txtamt.Text = dtp.Rows[0]["fees"].ToString();
            pendos = dtp.Rows[0]["fees"].ToString();
            paidfee = dtp.Rows[0]["fees"].ToString();
            from = dtp.Rows[0]["fromdate"].ToString();
            to = dtp.Rows[0]["todate"].ToString();
            txtcname.Text = Common.Get(objsql.GetSingleValue("select coursename from course where courseid='" + courseid + "'"));
            basicdetail(rollno);
        }
        
        

    }

    private void checkrecipt()
    {
        DataTable dtr = new DataTable();
        dtr = objsql.GetTable("select * from tblreceipt where status='1'");
        if (dtr.Rows.Count > 0)
        {
            int endno = Convert.ToInt32(dtr.Rows[0]["end_no"]);
            int current = Convert.ToInt32(dtr.Rows[0]["current_recipt"]);
            if (current <= endno)
            {
                txtreno.Text = current.ToString();
            }
            else
            {
                (this.Master as Auth_main).ShowMessage("Recipt Number Finshed Contact With Admin", Auth_main.MessageType.Error);
            }
        }
    }
    protected void basicdetail(string roll)
    {
        DataTable dts = new DataTable();
        dts = objsql.GetTable("select * from tblstudentdata where rollno='" + roll + "'");
        if (dts.Rows.Count > 0)
        {
            txtname.Text = dts.Rows[0]["name"].ToString();
            txtfname.Text = dts.Rows[0]["fathername"].ToString();
        }
    }
    protected void insertpaid()
    {
        using (TransactionScope ts=new TransactionScope ())
        {
            try
            {
                Token = Common.Get(objsql.GetSingleValue("Select Token from Current_ReceiptNo"));
                Token = (Convert.ToInt32(Token) + 1).ToString();
                string tpf = objsql.GetSingleValue("Select Top 1 TotalPaidFees  from Student_Fee where RollNo='" + rollno + "' and CourseId='" + courseid + "' order by id Desc").ToString();
                double TotalPaid = Convert.ToDouble(tpf);
                TotalPaid = TotalPaid + Convert.ToDouble(txtamt.Text);
                //discount
                string discout = objsql.GetSingleValue("Select discount  from Fees_Master where RollNo='" + rollno + "' and CourseId='" + courseid + "' order by id Desc").ToString();
                if (discout == "" || discout == null)
                {
                    discout = "0";
                }
                double dis = Convert.ToDouble(discout);

                double totdis = dis + 0;

                string courseFee = Common.Get(objsql.GetSingleValue("select totalfees from fees_master where rollno='" + rollno + "' and courseid='" + courseid + "'"));

                int i = objsql.ExecuteNonQuery1("insert into Student_Fee(RollNo,CourseId,CenterCode,TotalFees,TotalPaidFees,FromDate,ToDate,Date,TodayPaidFee,Token,Pending_Fees,DraftNo,ChequeNo,FeeMode,Pending_Fees_Alert,instalmentamount,discount,course_complete,note,duenxtfee) values('" + rollno
                            + "','" + courseid + "','" + Session["code"] + "','" + courseFee + "','" + TotalPaid + "','" + from + "','" + to + "','" + changedate(txtddate.Text) + "','" + txtamt.Text + "','" + Token + "','" + txtpfees.Text + "','" + txttype.Text + "','" + txttype.Text + "','" + ddlptype.SelectedItem.Text + "','" + changedate(txtalertdate.Text) + "','','0','1','" + txtremarks.Text + "','')");

                objsql.ExecuteNonQuery("update Fees_Master set Pending_Fees_Alert='" + changedate(txtalertdate.Text) + "', Paidfees='" + TotalPaid + "',mnul_FeeAlert='',Pending_Fees='" + txtpfees.Text + "',instalmentamount='',discount='" + totdis + "' where RollNo='" + rollno + "' and CourseId='" + courseid + "'");

                if (txtpfees.Text != "0.0") // check error
                {
                    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" + rollno + "','" + courseid + "','" + Token + "','" + txtpfees.Text + "','" + changedate(txtalertdate.Text) + "','1','" + from + "','" + to + "')");
                    objsql.ExecuteNonQuery("update tblpendingfee set status='0' where id='" + pid + "'");

                }
                else
                {
                    objsql.ExecuteNonQuery("update tblpendingfee set status='0' where id='" + pid + "'");
                }
                objsql.ExecuteNonQuery("insert into Recipt_Details(RollNo,Date,ReciptNo,TokenNo,Particular,Amount,DueDate,Feemode,CheckNo,DraftNo,CenterCode,CourseId,Active,oldreceiptno,course_complete,cancelauthorisation) values('" + rollno + "','" + changedate(txtddate.Text) + "','" + txtreno.Text + "','" + Token + "','" + txtcname.Text + "','" + txtamt.Text + "','','" + ddlptype.SelectedItem.Text + "','" + txttype.Text + "','" + txttype.Text + "','" + Session["code"] + "','" + courseid + "','1','','Active','Active')");
                // objsql.ExecuteNonQuery("Update Current_ReceiptNo set Token=Token+1 , ReceiptNo=ReceiptNo+1 where CenterCode='" + Session["code"] + "'");
                string recp = (Convert.ToInt32(txtreno.Text) + Convert.ToInt32(1)).ToString();
                objsql.ExecuteNonQuery("Update tblReceipt set Current_Recipt='" + recp + "' where  Status='1'");



                objsql.ExecuteNonQuery("Update Current_ReceiptNo set Token=Token+1  ");
                ts.Complete();
                ts.Dispose();
                (this.Master as Auth_main).ShowMessage("Deposit Pending Fees Sucessfully", Auth_main.MessageType.Success);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "OpenPopUp23();", true);
                bindpending();
            }
            catch (Exception t)
            {
                (this.Master as Auth_main).ShowMessage(t.Message, Auth_main.MessageType.Error);

            } 
        }

    }
    public string changedate( string dates)
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label alert = (Label)e.Row.FindControl("lblalert");
            Label left = (Label)e.Row.FindControl("lblleft");
            if (alert != null)
            {
                string nowdate=System.DateTime.Now.ToString("MM/dd/yyyy");
                left.Text = (Convert.ToDateTime(alert.Text).Day - Convert.ToDateTime(nowdate).Day).ToString();
                int mnthdiff = (Convert.ToDateTime(alert.Text).Month - Convert.ToDateTime(nowdate).Month);
                if (mnthdiff > 0)
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
    }
    protected void txtdate2_TextChanged(object sender, EventArgs e)
    {
        bindpending();
    }
}