using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Transactions;
public partial class Auth_Studentfee_Log : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string RollNo="",total="",Pending="",discout="",totval="0",fee="0",token,ccd,course="1",discont,pend;
    public double paidfee, disco,total2=0.0,disc=0.0,paid=0.0,pending2=0.0;
    public double to = 0.0, pai = 0.0, dis = 0.0, pen = 0.0,check23=0.0;
    public static string datepending = "", lastrc, lastpa, instname, instadd, instph,rno,amt,cname,roll,day,cid="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("Login.aspx");
        if (!Page.IsPostBack)
        {
            detail();

             RollNo = objsql.GetSingleValue("Select rollno from tblstudentdata where id =" + Cache["id"].ToString()).ToString();
        
            
            // RollNo = objsql.GetSingleValue("Select rollno from tblstudentdata where id =" + Cache["id"].ToString()).ToString();
            //if (Session["Receptionist"] != null)
            //{
            //    lblcode.Text = Session["Receptionist"].ToString();
            //}
            //if (Session["Red Cross Receptionist"] != null)
            //{
            //    lblcode.Text = Session["Red Cross Receptionist"].ToString();
            //}
             coursetype();
            BindStudent();
            
            check();

        }
    }
    public void BindStudent()
    {
        DataSet ds = new DataSet();
        //ds = objsql.GetDataset("select st.name,st.fname,st.Id,sc.CourseName,sc.Time,s.RollNo,s.TotalFees,s.CourseId,s.Date,s.Pending_Fees,s.TotalPaidFees,m.PaidFees,s.instalmentamount,s.noofinstalment,s.discount from Student_Fee s,Fees_Master m,tblstudentdata st,Student_Course sc where s.RollNo=m.RollNo and s.RollNo=st.rollno and s.RollNo=sc.RollNo and s.RollNo='"+ RollNo +"' ");
        ds = objsql.GetDataset(" select f.id as fid,r.id,r.rollno,r.particular,r.amount as paid,r.courseid,r.active,r.date,r.oldreceiptno,r.ReciptNo,m.totalfees,r.cancelauthorisation,f.discount,r.tokenno,f.fromdate,f.todate ,f.pending_fees_alert,f.pending_fees,f.totalpaidfees from Recipt_Details r , Fees_Master m,student_fee f  where r.rollno='" + RollNo + "' and r.courseid=m.courseid  and m.rollno=r.rollno and f.token=r.tokenno order by r.date asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdDetail.DataSource = ds;
            GrdDetail.DataBind();
            coursetype();
        }
    }
    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // coursetype();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblfee = (Label)e.Row.FindControl("lbltotal");

            Label lblpaidfee = (Label)e.Row.FindControl("lblpaidfee");
            Label lbldiscount = (Label)e.Row.FindControl("lbldiscount");
            HiddenField token = (HiddenField)e.Row.FindControl("hfto");
            HiddenField cid = (HiddenField)e.Row.FindControl("hfcid");
            HiddenField tpa = (HiddenField)e.Row.FindControl("hftot");
            Label date = (Label)e.Row.FindControl("lbldate");
            Label from = (Label)e.Row.FindControl("lblfrom");
            Label to = (Label)e.Row.FindControl("lblto");
            Label pend = (Label)e.Row.FindControl("Label2");
            Label alertdate = (Label)e.Row.FindControl("lbladate");
            Label status = (Label)e.Row.FindControl("lblstatus");
            LinkButton del = (LinkButton)e.Row.FindControl("lnkslipdel");
            date.Text = DateTime.Parse(date.Text).ToString("dd/MM/yyyy");
            from.Text = DateTime.Parse(from.Text).ToString("dd/MM/yyyy");
            to.Text = DateTime.Parse(to.Text).ToString("dd/MM/yyyy");

            if (alertdate.Text != "")
            {
                alertdate.Text = DateTime.Parse(alertdate.Text).ToString("dd/MM/yyyy");
            }
            lblpaidfee.Text = tpa.Value;

            //string getmid = Common.Get(objsql.GetSingleValue("select top(1) id from student_Fee where   id<'" + token.Value + "' and courseid='" + cid.Value + "' order by id desc"));
            //string gettpaid= Common.Get(objsql.GetSingleValue("select todaypaidfee id from student_Fee where   id='" + getmid + "'"));
            //if (gettpaid != null)
            //{
            //    string getidpaid = Common.Get(objsql.GetSingleValue("select todaypaidfee from student_Fee where   id='"+token.Value+"'"));
            //    lblpaidfee.Text = (Convert.ToInt32(gettpaid) + Convert.ToInt32(getidpaid)).ToString();

            //}



            //string paido = Common.Get(objsql.GetSingleValue("select todaypaidfee from student_fee where courseid='" + cid.Value + "' and token='" + token.Value + "'"));
            //lblpaidfee.Text = (Convert.ToInt32(paid) + Convert.ToInt32(lblpaidfee.Text)).ToString();

            //string di = Common.Get(objsql.GetSingleValue("select discount from student_fee where courseid='" + cid.Value + "' and token='" + token.Value + "'"));
            //lbldiscount.Text = (Convert.ToInt32(di) + Convert.ToInt32(lbldiscount.Text)).ToString();
            //if (lbldiscount.Text == "")
            //{
            //    lbldiscount.Text = "0.0";
            //    string to2 = ((Convert.ToDouble(lbldiscount.Text) + Convert.ToDouble(lblpaidfee.Text))).ToString();
            //    pend.Text = ((Convert.ToInt32(lblfee.Text) - Convert.ToInt32(to2))).ToString();
            //}
            //else
            //{
            //    string to2 = ((Convert.ToDouble(lbldiscount.Text) + Convert.ToDouble(lblpaidfee.Text))).ToString();
            //    pend.Text = ((Convert.ToInt32(lblfee.Text) - Convert.ToInt32(to2))).ToString();

            //}

            string ddl = ddlcourse.SelectedItem.Value;

            // string courseactive = Common.Get(objsql.GetSingleValue("select Active from Student_Course where CourseId='" + course + "' and RollNo='" + RollNo + "'"));
            if (status.Text != "Cancel")
            {
                total2 = (Convert.ToDouble(lblfee.Text) + Convert.ToDouble(total2));                        //  Total
                // int final= Convert.ToInt32( lbltotal.Text);
                disc = (Convert.ToDouble(lbldiscount.Text) + Convert.ToDouble(disc)); // Discount
                paid = (Convert.ToDouble(lblpaidfee.Text) + Convert.ToDouble(paid));
                // int left=final-paid;

                pending2 = (Convert.ToDouble(total2) - Convert.ToDouble(paid));
            }
            else
            {
                del.Enabled = false;
                del.Text = "Slip Cancel";
            }

           
        }
           }
        protected void coursetype()
        {
        DataTable dt35 = new DataTable();
        dt35 = objsql.GetTable("SELECT distinct CourseName,CourseId from Student_Course where RollNo='"+RollNo+"'");
        ddlcourse.DataSource = dt35;
        ddlcourse.DataValueField = "CourseId";
        ddlcourse.DataTextField = "CourseName";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, "Select Course");
        }
        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DataSet ds1 = new DataSet();
            //ds = objsql.GetDataset("select st.name,st.fname,st.Id,sc.CourseName,sc.Time,s.RollNo,s.TotalFees,s.CourseId,s.Date,s.Pending_Fees,s.TotalPaidFees,m.PaidFees,s.instalmentamount,s.noofinstalment,s.discount from Student_Fee s,Fees_Master m,tblstudentdata st,Student_Course sc where s.RollNo=m.RollNo and s.RollNo=st.rollno and s.RollNo=sc.RollNo and s.RollNo='"+ RollNo +"' ");
            ds1 = objsql.GetDataset("select r.id,r.rollno,r.particular,r.amount as paid,r.courseid,r.active,m.discount,r.date,r.oldreceiptno,r.ReciptNo,m.totalfees from Recipt_Details r , Fees_Master m  where r.rollno='" + RollNo + "' and r.courseid=m.courseid and r.courseid='" + ddlcourse.SelectedItem.Value + "' and m.rollno=r.rollno");
            if (ds1.Tables[0].Rows.Count > 0)
            {
               
                GrdDetail.DataSource = ds1;
                GrdDetail.DataBind();
            }
            else
            {
                lbltotal2.Text = "0";
                lbldisc.Text = "";
                lblpaid.Text = "0";
                lblpending.Text = "0";
                BindStudent();
               
         
               
         
            }
            check();
        }
        protected void check()
        {

            lbltotal2.Text = "";
            totval = "0";
            DataTable ds = new DataTable();
            DataTable ds1 = new DataTable();
            if (ddlcourse.SelectedIndex == 0)
            {
                ds = objsql.GetTable("select distinct CourseId from Student_Course where RollNo='" + RollNo + "' ");
            }
            else
            {
                ds = objsql.GetTable("select distinct CourseId from Student_Course where RollNo='" + RollNo + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'");
            }

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                ds1 = objsql.GetTable("select * from Fees_Master where RollNo='" + RollNo + "' and CourseId='" + ds.Rows[i]["CourseId"] + "' ");
                if (ds.Rows.Count > 0)
                {
                    string joindate = Common.Get(objsql.GetSingleValue("select admitdate from student_course where RollNo='" + RollNo + "' and CourseId='" + ds.Rows[i]["CourseId"] + "'"));
                    string latest = ds1.Rows[0]["alertdate"].ToString();
                    DateTime startDate = Convert.ToDateTime(joindate);
                    DateTime endDate = Convert.ToDateTime(latest);
                    int mnthcomp = (endDate.Year * 12 + endDate.Month) - (startDate.Year * 12 + startDate.Month);
                    {
                        double mnt=(Convert.ToDouble(ds1.Rows[0]["TotalFees"])* Convert.ToDouble(mnthcomp));

                        to += mnt;

                    }
                    
                  //  pai += Convert.ToDouble(ds1.Rows[0]["PaidFees"]);
                    //dis += Convert.ToDouble(ds1.Rows[0]["Discount"]);
                   // pen = to - (pai + dis);
                }
                //totval = (Convert.ToInt32(totval) + Convert.ToInt32(totfee)).ToString();
                //lbltotal.Text = totval;
            }


            //lbltotal2.Text = to.ToString();
            //lblpaid.Text = pai.ToString();
            //lbldisc.Text = dis.ToString();
            //lblpending.Text = pen.ToString();

        }

        protected void GrdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "slip")
            {
                using (TransactionScope ex=new TransactionScope ())
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(',');
                    token = arg[0];
                    ccd = arg[1];
                    string mmid = Common.Get(objsql.GetSingleValue("select Max(id) from Student_Fee where CourseId='" + ccd + "' and RollNo='" + RollNo + "'"));
                    string maxid = Common.Get(objsql.GetSingleValue("select Token from Student_Fee where id='" + mmid + "' "));

                    DataSet ds1 = new DataSet();
                    ds1 = objsql.GetDataset("select * from Student_Fee where Token='" + maxid + "'");
                    if (maxid!="" && maxid!=null)
                    {
                        if (token == maxid) // check last slip
                        {
                            string totpaid = Common.Get(objsql.GetSingleValue("select PaidFees from Fees_Master  where CourseId='" + ccd + "' and RollNo='" + RollNo + "'"));
                            string nowpaid = (Convert.ToInt32(totpaid) - Convert.ToInt32(ds1.Tables[0].Rows[0]["TodayPaidFee"])).ToString();
                            objsql.ExecuteNonQuery("update Fees_Master set PaidFees='" + nowpaid + "' where CourseId='" + ccd + "' and RollNo='" + RollNo + "'");
                            objsql.ExecuteNonQuery("delete from Student_Fee where Token='" + token + "'");
                            objsql.ExecuteNonQuery("delete from Recipt_Details where TokenNo='" + token + "'");
                           string alert=Common.Get(objsql.GetSingleValue("select ToDate from Student_Fee where CourseId='" + ccd + "' and RollNo='" + RollNo + "' order by id desc"));
                           objsql.ExecuteNonQuery("update Fees_Master set AlertDate='" + alert + "' where CourseId='" + ccd + "' and RollNo='" + RollNo + "'");
                            ex.Complete();
                        }
                        else
                        {
                            ex.Dispose();
                            Page.RegisterStartupScript("d", "<script>alert('Sorry You Delete Wrong Slip')</script>");
                        }
                    }
                 
                    ex.Dispose();
                    BindStudent();
                }
              
            }
            if (e.CommandName == "cancel")
            {
                string[] arg = new string[6];
                arg = e.CommandArgument.ToString().Split(',');

                objsql.ExecuteNonQuery("update student_fee set status='Cancel' where Token='" + arg[2] + "' and courseid='"+arg[4]+"'");
               objsql.ExecuteNonQuery("update Recipt_details set cancelauthorisation='Cancel' where id='" + arg[0] + "' and courseid='"+arg[4]+"'");
               string fees = Common.Get(objsql.GetSingleValue("select Paidfees from fees_master where courseid='" + arg[4] + "' and Rollno='" + RollNo + "'"));
               if (fees != null)
               {
                   int leftpayment = (Convert.ToInt32(fees) - Convert.ToInt32(arg[3]));
                   objsql.ExecuteNonQuery("update Fees_Master set PaidFees='" + leftpayment + "' where CourseId='" + arg[4] + "' and RollNo='" + RollNo + "'");

               }


            }
            if (e.CommandName == "reprint")
            {
                DataTable dt3 = new DataTable();
                dt3 = objsql.GetTable("select s.name , r.reciptno , r.date,r.amount,r.particular,r.courseid,r.checkno,r.draftno,r.TokenNo from tblstudentdata s , recipt_details r where s.rollno='" + RollNo + "' and r.id='" + e.CommandArgument.ToString() + "'");
                if (dt3.Rows.Count > 0)
                {
                    lblrname.Text = dt3.Rows[0]["name"].ToString();
                    lastrc = dt3.Rows[0]["reciptno"].ToString();
                    rno = RollNo;
                    string token=dt3.Rows[0]["tokenno"].ToString();
                    cname = dt3.Rows[0]["particular"].ToString();
                    cid = dt3.Rows[0]["courseid"].ToString();
                    string date = dt3.Rows[0]["date"].ToString();
                    lbldate.Text = Convert.ToDateTime(date).ToString("dd/MM/yyyy");
                    lastpa = dt3.Rows[0]["amount"].ToString();
                    string word = ConvertNumbertoWords(Convert.ToInt32(lastpa));
                    discont = Common.Get(objsql.GetSingleValue("select discount from student_fee where token='" + token + "'"));
                    pend = Common.Get(objsql.GetSingleValue("select fees from tblpendingfee where tokenno='" + token + "'"));
                    lblramt.Text = word;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "OpenPopUp();", true);
                }
                check();
            }
        }
        protected void detail()
        {
            DataTable detail = new DataTable();
            detail = objsql.GetTable("select * from tblreceptionist where type='Admin'");
            if (detail.Rows.Count > 0)
            {
                instname = detail.Rows[0]["name"].ToString();
                instadd = detail.Rows[0]["address"].ToString();
                instph = detail.Rows[0]["contact"].ToString();
            }

        }
        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        protected void GrdDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
}