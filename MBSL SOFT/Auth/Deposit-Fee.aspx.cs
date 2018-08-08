using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
public partial class Auth_Deposit_Fee : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    public DataTable dt = new DataTable();
    public static string name = "", rollno = "", F_date = "", txtF_Date = "", T_Date = "", courseFee = "", Fee_id = "", RN = "", Reciptnumber = "", Token = "", feemode = "", Cno = "", DNo = "";
    public static double PaidFee = 0.00;
    public static string duedate = "", Cname = "", nxtrcpt, coname, ppaid;
    public static DateTime alertdate;
    public double Total = 0.00;
    public static string date = "",Date="",condition;
    public static string date1 = "";
    public static string date2 = "", idd;
    public static string datepending = "", lastrc, lastpa, instname, instadd, instph, netamount="";
    public string srollno = "", centername = "", add = "", cphone = "";
    public int days,paidamu=0;
    public static string[] val = new string[2];
    public static string name1 = "", Code = "", roll = "", phone = "", fname = "", gender = "", cat = "", Status = "", sta = "",restatus="",fes="",feval="";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtdiscount.Text = "0";
            //if (Cache["roll"] != null && Cache["roll"] != "")
            //{
            //    Cache.Remove("id");
            //    Cache["id"] = Common.Get(objsql.GetSingleValue("select id from tblstudentdata where rollno='" + Cache["roll"] + "'"));

            //}
            if (Request.QueryString["quick"] != null)
            {
                Cache.Remove("id");
            }

            ddlcourse.Items.Insert(0, "<-SELECT->");
            detail();
            txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtdate.Attributes.Add("readonly", "readonly");
            txtfrom.Attributes.Add("readonly", "readonly");
            txtto.Attributes.Add("readonly", "readonly");
            if (Cache["id"] != null && Cache["id"] != "")
            {
                binddiscription();
                getcourse();
               // bill();
            }
            else
            {
                Cache.Remove("id");
              //  bill();
                lblname.Enabled = true;
            }

           
        }
    

        
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmode.SelectedItem.Text == "Cheque")
        {
            pnlcheque.Visible = true;
            pnldraft.Visible = false;
        }
        if (ddlmode.SelectedItem.Text == "Draft")
        {
            pnldraft.Visible = true;
            pnlcheque.Visible = false;
        }
        if (ddlmode.SelectedIndex != 0)
        {
            txtamount.Enabled = true;
            txtamount.Focus();
        }
        
    }
    protected void binddiscription()
    {

        dt = objsql.GetTable("select * from tblstudentdata where id='" + Cache["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            lblname.Text = dt.Rows[0]["name"].ToString();
            lblroll.Text = dt.Rows[0]["rollno"].ToString();
            lbldisaprov.Text = dt.Rows[0]["discount"].ToString();
        }
    }
    protected void getcourse()
    {
        help.BindDropDownList("SELECT distinct CourseId,CourseName from Student_Course where RollNo='" + lblroll.Text + "' and status='1'", "CourseName", "CourseId", ddlcourse);
        ddlcourse.SelectedIndex = 1;
        gettimedetail();
        
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void fvSubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            if (txtrecipt.Text != "" && txtrecipt.Text!=null)
            {
                string chrep = Common.Get(objsql.GetSingleValue("select reciptno from recipt_details where reciptno='" + txtrecipt.Text + "' and cancelauthorisation!='Cancel'"));
                if (chrep != null && chrep != "")
                {
                    goto yy;
                }
                if (Convert.ToInt32(txtpendingfee.Text) > 0)
                {
                    if(txtpalert.Text=="")
                    {
                        goto xx;
                    }
                }
                Token = Common.Get(objsql.GetSingleValue("Select Token from Current_ReceiptNo"));
                Token = (Convert.ToInt32(Token) + 1).ToString();
                Reciptnumber = txtrecipt.Text;

                DataTable dt34 = new DataTable();

                //dt34 = objsql.GetTable("select  oldreceiptno from Recipt_Details where centercode='" + Session["code"] + "' and oldreceiptno='" + txtoldreceiptno.Text + "'");
                //if (dt34.Rows.Count > 0)
                //{
                //    Page.RegisterStartupScript("page", "<script>alert('This Receipt Number is already saved.Chosse a new one.')</script>");
                //}
                //else
                //{

                #region date conversion
                string[] alldatevalues3 = new string[3];

                if (txtpalert.Text != "" && txtpalert.Text != null)
                {
                    alldatevalues3 = txtpalert.Text.Split("/".ToCharArray());

                    if (alldatevalues3.Length >= 3)
                    {
                        datepending = alldatevalues3[1].Trim() + "/" + alldatevalues3[0].Trim() + "/" + alldatevalues3[2].Trim();

                    }
                }



                string[] alldateval = new string[3];
                if (txtdate.Text != "")
                {
                    alldateval = txtdate.Text.Split("/".ToCharArray());
                }
                if (alldateval.Length >= 3)
                {
                    date = alldateval[1].Trim() + "/" + alldateval[0].Trim() + "/" + alldateval[2].Trim();

                }




                #endregion

                #region a
             



                string[] alldatevalues1 = new string[3];

                if (txtto.Text != "")
                {
                    alldatevalues1 = txtto.Text.Split("/".ToCharArray());
                }
                if (alldatevalues1.Length >= 3)
                {
                    date1 = alldatevalues1[1].Trim() + "/" + alldatevalues1[0].Trim() + "/" + alldatevalues1[2].Trim();

                }
                T_Date = date1;

                string[] alldatevalues = new string[3];

                if (txtfrom.Text != "")
                {
                    alldatevalues = txtfrom.Text.Split("/".ToCharArray());
                }
                if (alldatevalues.Length >= 3)
                {
                    date2 = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

                }
                F_date = date2;


                //F_date =F_date;
                //T_Date = T_Date;
                string tpf = objsql.GetSingleValue("Select Top 1 TotalPaidFees  from Student_Fee where RollNo='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' order by id Desc").ToString();
                double TotalPaid = Convert.ToDouble(tpf);
                TotalPaid = TotalPaid + Convert.ToDouble(txtamount.Text);
                //discount
                string discout = objsql.GetSingleValue("Select discount  from Fees_Master where RollNo='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' order by id Desc").ToString();
                if (discout == "" || discout == null)
                {
                    discout = "0";
                }
                double dis = Convert.ToDouble(discout);

                double totdis = dis + Convert.ToDouble(txtdiscount.Text);

                int i = objsql.ExecuteNonQuery1("insert into Student_Fee(RollNo,CourseId,CenterCode,TotalFees,TotalPaidFees,FromDate,ToDate,Date,TodayPaidFee,Token,Pending_Fees,DraftNo,ChequeNo,FeeMode,Pending_Fees_Alert,instalmentamount,discount,course_complete,note,duenxtfee) values('" + lblroll.Text
                            + "','" + ddlcourse.SelectedItem.Value + "','" + Session["code"] + "','" + courseFee + "','" + TotalPaid + "','" + F_date + "','" + T_Date + "','" + date + "','" + txtamount.Text + "','" +Token + "','" + txtpendingfee.Text + "','" + txtdraft.Text + "','" + txtcheque.Text + "','" + ddlmode.SelectedItem.Text + "','" + datepending + "','" + txtamount.Text + "','" + txtdiscount.Text + "','1','" + txtnotice.Text + "','" + txtduefee.Text + "')");

                objsql.ExecuteNonQuery("update Fees_Master set AlertDate='" + T_Date + "' , Pending_Fees_Alert='" + datepending + "', Paidfees='" + TotalPaid + "',mnul_FeeAlert='',Pending_Fees='" + txtpendingfee.Text + "',instalmentamount='" + txtamount.Text + "',discount='" + totdis + "' where RollNo='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'");

                if (RadioButtonList1.SelectedItem.Text == "Yes")
                {
                    objsql.ExecuteNonQuery("update tblpendingfee set status='0' where rollno='" + lblroll.Text + "' and courseid='" + ddlcourse.SelectedItem.Value + "'");
                    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" + lblroll.Text + "','" + ddlcourse.SelectedItem.Value + "','" + Token + "','" + txtpendingfee.Text + "','" + datepending + "','1','" + F_date + "','" + T_Date + "')");

                }
                else
                {
                    objsql.ExecuteNonQuery("update tblpendingfee set status='0' where rollno='" + lblroll.Text + "' and courseid='" + ddlcourse.SelectedItem.Value + "'");

                }



                if (txtoldreceiptno.Text == "")
                {
                    objsql.ExecuteNonQuery("insert into Recipt_Details(RollNo,Date,ReciptNo,TokenNo,Particular,Amount,DueDate,Feemode,CheckNo,DraftNo,CenterCode,CourseId,Active,oldreceiptno,course_complete) values('" + lblroll.Text + "','" + date + "','" + Reciptnumber + "','" + Token + "','" + ddlcourse.SelectedItem.Text + "','" + txtamount.Text + "','" + duedate + "','" + feemode + "','" + txtcheque.Text + "','" + txtdraft.Text + "','" + Session["code"] + "','" + ddlcourse.SelectedItem.Value + "','1','','Active')");
                    // objsql.ExecuteNonQuery("Update Current_ReceiptNo set Token=Token+1 , ReceiptNo=ReceiptNo+1 where CenterCode='" + Session["code"] + "'");
                    objsql.ExecuteNonQuery("Update tblReceipt set Current_Recipt='" + nxtrcpt + "' where  Status='1'");
                    
                    //    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" + lblroll.Text + "','" + ddlcourse.SelectedItem.Value + "','" + Token + "','" + txtpendingfee.Text + "','" + datepending + "','1','" + F_date + "','" + T_Date + "')");


                }
                else if (txtoldreceiptno.Text != "")
                {
                    objsql.ExecuteNonQuery("insert into Recipt_Details(RollNo,Date,ReciptNo,TokenNo,Particular,Amount,DueDate,Feemode,CheckNo,DraftNo,CenterCode,CourseId,Active,oldreceiptno,course_complete,cancelauthorisation) values('" + lblroll.Text + "','" + date + "','','" + Token + "','" + ddlcourse.SelectedItem.Text + "','" + txtamount.Text + "','" + duedate + "','" + feemode + "','" + txtcheque.Text + "','" + txtdraft.Text + "','" + Session["code"] + "','" + ddlcourse.SelectedItem.Value + "','1','" + txtoldreceiptno.Text + "','Active','Active')");
                    // objsql.ExecuteNonQuery("Update Current_ReceiptNo set Token=Tokne+1  where CenterCode='" + Session["code"] + "'");

                }

                objsql.ExecuteNonQuery("Update Current_ReceiptNo set Token=Token+1  ");





                #endregion
             //   sms("New FeeStudentName:(" + lblname.Text + ") and Total Paid:(" + txtamount.Text+ ")");

                lastrc = lblrecpt.Text;
                lastpa = txtamount.Text;
                string word = ConvertNumbertoWords(Convert.ToInt32(lastpa));
                lblramt.Text = word;
                //ddlcourse.SelectedIndex = 0;
                txtfrom.Text = "";
                txtto.Text = "";
                //txtamount.Text = "";
              
             
                txtrecipt.Text = "";
                lblpendingfee.Text = "";
                lbltotal.Text = "";
                lblppaid.Text = "";
                txtpalert.Text = "";
                txtoldreceiptno.Text = "";
                ts.Complete();
                ts.Dispose();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "OpenPopUp();", true);

               // txtpendingfee.Text = "0";
              //  txtdiscount.Text = "0";
            xx:
                if (txtpalert.Text == "" && txtpalert.Text == null)
                {
                    Page.RegisterStartupScript("page", "<script>alert('Please Fill Pending Alert Date')</script>");
                }
        yy:
            if (chrep != null && chrep != "")
            {
                Page.RegisterStartupScript("page", "<script>alert('Receipt Already Used')</script>");
            }
                ;
            
            }
            else
            {
                Page.RegisterStartupScript("page", "<script>alert('Please Enter Recipt No')</script>");
            }
           // Response.Redirect("deposit-fee.aspx");
          //  bill();
    }
 }
    protected void txtto_TextChanged(object sender, EventArgs e)
    {
        string[] alldatevalues1 = new string[3];

        if (txtto.Text != "")
        {
            alldatevalues1 = txtto.Text.Split("/".ToCharArray());
        }
        if (alldatevalues1.Length >= 3)
        {
            date1 = alldatevalues1[1].Trim() + "/" + alldatevalues1[0].Trim() + "/" + alldatevalues1[2].Trim();

        }
        T_Date = date1;
        //txtfrom.Text =Convert.ToDateTime(T_Date).ToString("dd/MM/yyyy");
    }
    protected void btnother_Click(object sender, EventArgs e)
    {
        Response.Redirect("othercharges.aspx?Id=" + Cache["id"]);
    }
    protected void txtdiscount_TextChanged(object sender, EventArgs e)
    {
      //  txtamount.Text = (Convert.ToDouble(txtamount.Text) - Convert.ToDouble(txtdiscount.Text)).ToString();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        
        //Response.Redirect("student-Profile.aspx?Id=" + Cache["id"]);
      //  Response.Redirect("window.open('print-bill.aspx?rno=" + Reciptnumber + "&amt=" + txtamount.Text + "&cname=" + ddlcourse.SelectedItem.Text + "&roll=" + lblroll.Text + "','_blank')");

    }
    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        string[] alldatevalues = new string[3];

        if (txtfrom.Text != "")
        {
            alldatevalues = txtfrom.Text.Split("/".ToCharArray());
        }
        if (alldatevalues.Length >= 3)
        {
            date2 = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

        }
        F_date = date2;
    }
    protected void txtoldreceiptno_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        dt = objsql.GetTable("select  oldreceiptno from Recipt_Details where centercode='" + Session["code"] + "' and oldreceiptno='"+txtoldreceiptno.Text+"'");
        if (dt.Rows.Count > 0)
        {   
                    Page.RegisterStartupScript("page", "<script>alert('This Receipt Number is already saved.Chosse a new one.')</script>");
        }
    }
    protected void print()
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        dt1 = objsql.GetTable("select * from tblstudentdata where rollno='" +lblroll.Text + "'");

        if (dt1.Rows.Count > 0)
        {
            this.srollno = lblroll.Text;
            Date = txtdate.Text;
            //  Date = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

            string[] alldatevalues = new string[3];
            if (Date.ToString() != "")
            {
                alldatevalues = Date.ToString().Split("/".ToCharArray());

                if (alldatevalues.Length >= 3)
                {
                    Date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

                }
            }

            lbldate.Text = Date;
           lblrname.Text = dt1.Rows[0]["name"].ToString();
         
            roll = dt1.Rows[0]["rollno"].ToString();
          //  phone = dt1.Rows[0]["contact"].ToString();
           // fname = dt1.Rows[0]["fname"].ToString();
           // gender = dt1.Rows[0]["sex"].ToString();
        //    lblmode.Text = ddlmode.SelectedItem.Text;
          //  cat = dt1.Rows[0]["category"].ToString();

            //dt2 = objsql.GetTable("select * from Recipt_details where centercode='" + Session["code"] + "'");
            //if (dt2.Rows.Count > 0)
            //{
            //    centername = dt2.Rows[0]["CenterName"].ToString();
            //    add = dt2.Rows[0]["CenterAddress"].ToString();
            //    cphone = dt2.Rows[0]["ContactNo"].ToString();
            //}
           
        }


        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();

        string cid = Common.Get(objsql.GetSingleValue("select CourseId from Student_Fee where RollNo='" + lblroll.Text + "' and Token='" + Token + "'"));
         coname = Common.Get(objsql.GetSingleValue("select CourseName from Course where CourseId='"+cid+"' and centercode='FV'"));
        dt = objsql.GetTable("select CourseId,CenterCode,TodayPaidFee,FeeMode,ChequeNo,DraftNo from Student_Fee where RollNo='" + lblroll.Text + "' and Token='" + Token+ "'");
        dt3 = objsql.GetTable("select ChargeName,Paid from S_OtherCharges where RollNo='"+ lblroll.Text + "' and Token='" + Token + "' and CenterCode='" + Session["code"] + "'");
        if (dt.Rows.Count > 0)
        {
            ppaid = dt.Rows[0]["TodayPaidFee"].ToString();
           // GrdDetail.DataSource = dt;
           // GrdDetail.DataBind();
            duedate = objsql.GetSingleValue("select Top 1  Pending_Fees_Alert from Fees_Master where Rollno='" + roll + " '").ToString();
        }
        //if (dt3.Rows.Count > 0)
        //{

        //    foreach (DataRow dr in dt3.Rows)
        //    {

        //        DataRow dr1 = dtnewTest.NewRow();
        //        dr1["Course"] = dr[0].ToString();
        //        dr1["TodayPaidFee"] = dr[1].ToString();

        //        Total = Total + Convert.ToDouble(dr[1]);
        //        dtnewTest.Rows.Add(dr1);
        //    }

        //}
        //DataTable dtadm = new DataTable();
        //dtadm = objsql.GetTable("select id,TodayPaidFee,status from Student_Fee where courseid='Addmi1001' and  RollNo='" + lblroll.Text + "' ");
        //if (dtadm.Rows.Count > 0)
        //{
        //    if (dtadm.Rows[0]["status"].ToString() == null || dtadm.Rows[0]["status"].ToString() == "")
        //    {
        //        DataRow dr1 = dtnewTest.NewRow();
        //        dr1["Course"] = "Admission Fee";
        //        dr1["TodayPaidFee"] = dtadm.Rows[0]["TodayPaidFee"].ToString();

        //        Total = Total + Convert.ToDouble(dtadm.Rows[0]["TodayPaidFee"]);
        //        dtnewTest.Rows.Add(dr1);
        //        objsql.ExecuteNonQuery("update Student_Fee set status='Print' where id=" + dtadm.Rows[0]["id"]);
        //    }


        //}


     
 
    }

    #region Billing Number
    protected void bill()
    {
        DataTable dtbill = new DataTable();
        dtbill = objsql.GetTable("select * from tblReceipt where Status='1' ");
        if (dtbill.Rows.Count > 0)
        {
            string end = dtbill.Rows[0]["End_no"].ToString();
            string current = dtbill.Rows[0]["Current_Recipt"].ToString();
            if (Convert.ToInt32(current) < Convert.ToInt32(end))
            {
                lblrecpt.Text = current;
                Reciptnumber = lblrecpt.Text;
                txtrecipt.Text = lblrecpt.Text;
                nxtrcpt = (Convert.ToInt32(Reciptnumber) + Convert.ToInt32(1)).ToString();
                restatus = "True";
            }
            else
            {
                restatus = "False";
                Page.RegisterStartupScript("page", "<script>alert('Sorry Recipt No Is Finished')</script>");
            }

        }

    }
    #endregion

    protected void ddlcourse_SelectedIndexChanged1(object sender, EventArgs e)
    {
        gettimedetail();


    }

    private void gettimedetail()
    {
        try
        {
            DataTable dt1 = new DataTable();
            int mm = 1;
            string month = "";
            lbltotal.Text = "0";
            Cname = ddlcourse.SelectedItem.Text;
            #region date conversion

            string[] alldatevalues = new string[3];
            if (txtdate.Text != "")
            {
                alldatevalues = txtdate.Text.Split("/".ToCharArray());
            }
            if (alldatevalues.Length >= 3)
            {
                date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }

            string[] alldatevalues2 = new string[3];

            //if (txtto.Text != "")
            //{
            //    alldatevalues2 = txtto.Text.Split("/".ToCharArray());
            //}
            //if (alldatevalues2.Length >= 3)
            //{
            //    date1 = alldatevalues2[1].Trim() + "/" + alldatevalues2[0].Trim() + "/" + alldatevalues2[2].Trim();

            //}


            #endregion



            // txtamount.Text = Common.Get(objsql.GetSingleValue("select Instalment_amount from  Course where CourseId='" + ddlcourse.SelectedItem.Value + "'"));
            idd = Common.Get(objsql.GetSingleValue("Select Top 1 id from Student_Fee where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' order By id Desc"));


            dt1 = objsql.GetTable("Select *  from Student_Fee where id ='" + idd + "'");

            if (dt1.Rows.Count > 0)
            {
                string chkdis = Common.Get(objsql.GetSingleValue("select discount from Fees_Master where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' and CenterCode='" + Session["code"] + "'"));
                if (chkdis == "")
                {
                    lbldis.Text = "0";
                }
                else
                {
                    lbldis.Text = chkdis;
                }


                string max = Common.Get(objsql.GetSingleValue("select max(id) from Student_Fee where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'"));
                F_date = Common.Get(objsql.GetSingleValue("select Admitdate from student_course where courseid='" + ddlcourse.SelectedItem.Value + "' and Rollno='" + lblroll.Text + "'"));
                T_Date = Common.Get(objsql.GetSingleValue("select enddate from student_course where courseid='" + ddlcourse.SelectedItem.Value + "' and Rollno='" + lblroll.Text + "'"));

               // T_Date = Convert.ToDateTime(T_Date).ToString("dd/MM/yyyy");
                txtto.Text = Convert.ToDateTime(T_Date).ToString("dd/MM/yyyy");


                txtfrom.Text = Convert.ToDateTime(F_date).ToString("dd/MM/yyyy");


                // txtT_Date.Text = (DateTime.ParseExact(txtF_Date.Text,"dd/MM/yyyy",null).AddDays(30)).ToString();

                courseFee = Common.Get(objsql.GetSingleValue("select fees from student_course where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'"));

                lbltotal.Text = courseFee;

                //check pending fees
                lblpbalance.Text = Common.Get(objsql.GetSingleValue("select fees from tblpendingfee where courseid='" + ddlcourse.SelectedItem.Value + "' and rollno='" + lblroll.Text + "' and status='1'"));
                if (lblpbalance.Text == "")
                {
                    lblpbalance.Text = "0";

                }
                // check total paid amount

               netamount= (Convert.ToDecimal(lbltotal.Text) - Convert.ToDecimal(lblpbalance.Text)).ToString();
                
               txtamount.Text = lblpbalance.Text;

                //string totpaid = (Convert.ToDouble(dt1.Rows[0]["TotalPaidFees"]) + Convert.ToDouble(lbldis.Text)).ToString();
                //lblpendingfee.Text = (Convert.ToDouble(dt1.Rows[0]["TotalFees"]) - Convert.ToDouble(totpaid)).ToString();
                //PaidFee = Convert.ToDouble(dt1.Rows[0]["TotalPaidFees"]);
                //lblppaid.Text = PaidFee.ToString();
                //txtamount.Text = lblpendingfee.Text;
                //lbltotal.Text = dt1.Rows[0]["TotalFees"].ToString();
                //pnlfee.Visible = true;


            }

            DataTable dtmaster = new DataTable();
            dtmaster = objsql.GetTable("Select Top 1 id,Date,TotalFees,PaidFees,CourseId,AlertDate,instalmentamount,discount  from Fees_Master where RollNo='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'  and CenterCode='" + Session["code"] + "' Order by id Desc ");
            {
                if (dtmaster.Rows.Count > 0)
                {
                    string[] allvalues = new string[3];

                    foreach (DataRow dr1 in dtmaster.Rows)
                    {
                        //  courseFee = dr1[2].ToString();

                        PaidFee = Convert.ToDouble(dr1[3].ToString());

                        // txtamount.Text = dr1["instalmentamount"].ToString();
                        //txtdiscount.Text = dr1["discount"].ToString();
                        string datee = dr1[1].ToString();
                        Fee_id = dr1[0].ToString();
                        string a = dr1[5].ToString();

                        alertdate = Convert.ToDateTime(T_Date);
                        allvalues = datee.Split("/".ToCharArray());
                        if (allvalues[0] != null)
                        {
                            month = allvalues[0].Trim();
                            //Year = allvalues[2].Trim();
                        }
                        //if (Convert.ToInt32(month) <= Convert.ToInt32(DateTime.Now.Month) && Convert.ToInt32(Year) <= Convert.ToInt32(DateTime.Now.Year))
                        //if (Convert.ToInt32(month) == mm)
                        //{

                        //}
                        //else
                        //{
                        string tF = (Convert.ToDouble(courseFee) + Convert.ToDouble(dr1[2]) - Convert.ToDouble(dr1[3])).ToString();
                        // 
                        //objsql.ExecuteNonQuery("insert into Fees_Master (RollNo,TotalFees,PaidFees,CourseId,Date,AlertDate,CenterCode) values('" + RollNo
                        //    + "','" + tF + "',0,'" + dr1[4] + "','" + DateTime.Now.ToShortDateString() + "','"++"' ,'"+ Code+"')");
                        // }

                    }
                }
            }
        }
        catch (Exception ss)
        {
            Page.RegisterStartupScript("page", "<script>alert('"+ss.Message+"')</script>");
          // throw;
        }
        if (ddlcourse.SelectedIndex != 0)
        {
            ddlmonth.Enabled = true;

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
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        try
        {
            DataTable dt1 = new DataTable();
            int mm = 1;
            string month = "";
            lbltotal.Text = "0";

            #region date conversion

            string[] alldatevalues = new string[3];
            if (txtdate.Text != "")
            {
                alldatevalues = txtdate.Text.Split("/".ToCharArray());
            }
            if (alldatevalues.Length >= 3)
            {
                date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }

            string[] alldatevalues2 = new string[3];

            //if (txtto.Text != "")
            //{
            //    alldatevalues2 = txtto.Text.Split("/".ToCharArray());
            //}
            //if (alldatevalues2.Length >= 3)
            //{
            //    date1 = alldatevalues2[1].Trim() + "/" + alldatevalues2[0].Trim() + "/" + alldatevalues2[2].Trim();

            //}


            #endregion



           // txtamount.Text = Common.Get(objsql.GetSingleValue("select Instalment_amount from  Course where CourseId='" + ddlcourse.SelectedItem.Value + "'"));
            idd = Common.Get(objsql.GetSingleValue("Select Top 1 id from Student_Fee where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' order By id Desc"));


            dt1 = objsql.GetTable("Select *  from Student_Fee where id ='" + idd + "'");

            if (dt1.Rows.Count > 0)
            {
                string chkdis = Common.Get(objsql.GetSingleValue("select discount from Fees_Master where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "' and CenterCode='" + Session["code"] + "'"));
                if (chkdis == "")
                {
                    lbldis.Text = "0";
                }
                else
                {
                    lbldis.Text = chkdis;
                }


                string max = Common.Get(objsql.GetSingleValue("select max(id) from Student_Fee where RollNo ='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'"));
                F_date = Common.Get(objsql.GetSingleValue("select todate from student_fee where id='" + max + "'"));

                if (ddlmonth.SelectedItem.Text == "1 Month")
                {
                    days = 30;
                    fes = "Fees";
                    feval = "1";
                }
                if (ddlmonth.SelectedItem.Text == "2 Month")
                {
                    days = 60;
                    fes = "twomonth";
                    feval = "2";
                }
                if (ddlmonth.SelectedItem.Text == "3 Month")
                {
                    days = 90;
                    fes = "threemonth";
                    feval = "3";
                }
                if (ddlmonth.SelectedItem.Text == "4 Month")
                {
                    days = 120;
                    fes = "fourmonth";
                    feval = "4";
                }
                T_Date = (Convert.ToDateTime(F_date).AddDays(days)).ToShortDateString();
                txtto.Text = (Convert.ToDateTime(F_date).AddDays(days)).ToString("dd/MM/yyyy");


                txtfrom.Text = Convert.ToDateTime(F_date).ToString("dd/MM/yyyy");


                // txtT_Date.Text = (DateTime.ParseExact(txtF_Date.Text,"dd/MM/yyyy",null).AddDays(30)).ToString();

                courseFee = dt1.Rows[0]["TotalFees"].ToString().Replace("''", "'");

                

                string totpaid = (Convert.ToDouble(dt1.Rows[0]["TotalPaidFees"]) + Convert.ToDouble(lbldis.Text)).ToString();
                lblpendingfee.Text = (Convert.ToDouble(dt1.Rows[0]["TotalFees"]) - Convert.ToDouble(totpaid)).ToString();
                PaidFee = Convert.ToDouble(dt1.Rows[0]["TotalPaidFees"]);
                lblppaid.Text = PaidFee.ToString();
                txtamount.Text = lblpendingfee.Text;
                lbltotal.Text = dt1.Rows[0]["TotalFees"].ToString();
                pnlfee.Visible = true;
                
                string montlyfees = Common.Get(objsql.GetSingleValue("select " + fes + " from course where courseid='" + ddlcourse.SelectedItem.Value + "'"));
                if (montlyfees != "")
                {
                    lbltopa.Text = montlyfees;
                    paidamu = (Convert.ToInt32(lbltotal.Text) * Convert.ToInt32(feval));
                    txtamount.Text = paidamu.ToString();
                    if (paidamu > Convert.ToInt32(lbltopa.Text))
                    {
                        txtdiscount.Text = (Convert.ToInt32(txtamount.Text) - Convert.ToInt32(lbltopa.Text)).ToString();
                        txtamount.Text = lbltopa.Text;

                    }
                    else
                    {
                        txtdiscount.Text = "0";
                    }

                }
                else
                {
                    lbltopa.Text = "N/A";
                    btndepost.Enabled = false;
                }

            }

            DataTable dtmaster = new DataTable();
            dtmaster = objsql.GetTable("Select Top 1 id,Date,TotalFees,PaidFees,CourseId,AlertDate,instalmentamount,discount  from Fees_Master where RollNo='" + lblroll.Text + "' and CourseId='" + ddlcourse.SelectedItem.Value + "'  and CenterCode='" + Session["code"] + "' Order by id Desc ");
            {
                if (dtmaster.Rows.Count > 0)
                {
                    string[] allvalues = new string[3];

                    foreach (DataRow dr1 in dtmaster.Rows)
                    {
                        //  courseFee = dr1[2].ToString();

                        PaidFee = Convert.ToDouble(dr1[3].ToString());

                        // txtamount.Text = dr1["instalmentamount"].ToString();
                        //txtdiscount.Text = dr1["discount"].ToString();
                        string datee = dr1[1].ToString();
                        Fee_id = dr1[0].ToString();
                        string a = dr1[5].ToString();

                        alertdate = Convert.ToDateTime(T_Date);
                        allvalues = datee.Split("/".ToCharArray());
                        if (allvalues[0] != null)
                        {
                            month = allvalues[0].Trim();
                            //Year = allvalues[2].Trim();
                        }
                        //if (Convert.ToInt32(month) <= Convert.ToInt32(DateTime.Now.Month) && Convert.ToInt32(Year) <= Convert.ToInt32(DateTime.Now.Year))
                        //if (Convert.ToInt32(month) == mm)
                        //{

                        //}
                        //else
                        //{
                        string tF = (Convert.ToDouble(courseFee) + Convert.ToDouble(dr1[2]) - Convert.ToDouble(dr1[3])).ToString();
                        // 
                        //objsql.ExecuteNonQuery("insert into Fees_Master (RollNo,TotalFees,PaidFees,CourseId,Date,AlertDate,CenterCode) values('" + RollNo
                        //    + "','" + tF + "',0,'" + dr1[4] + "','" + DateTime.Now.ToShortDateString() + "','"++"' ,'"+ Code+"')");
                        // }

                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "Yes")
        {
            pnlate.Visible = true;

        }
        else
        {
            pnlate.Visible = false;
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select (name+','+rollno) as name from tblstudentdata where " +
                "name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);

                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }

    protected void lblname_TextChanged(object sender, EventArgs e)
    {
        
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
    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
     //   checkremainfees();
        
    }

    private void checkremainfees()
    {
        if (Convert.ToDecimal(txtamount.Text) <= Convert.ToDecimal(lblpbalance.Text))
        {
            RadioButtonList1.Items.FindByText("Yes").Selected = true;
            RadioButtonList1.Items.FindByText("No").Selected = false;
            pnlate.Visible = true;
            // check rest pending amount
            if (Convert.ToInt32(txtdiscount.Text) > 0)
            {
                string netdis = (Convert.ToDecimal(netamount) - Convert.ToDecimal(txtamount.Text)).ToString();
                txtpendingfee.Text = (Convert.ToDecimal(netdis) - Convert.ToDecimal(txtdiscount.Text)).ToString();
            }
            else
            {
                txtpendingfee.Text = (Convert.ToDecimal(lblpbalance.Text) - Convert.ToDecimal(txtamount.Text)).ToString();

            }
            
        }
    }
    protected void lblroll_TextChanged(object sender, EventArgs e)
    {
        string ido = Common.Get(objsql.GetSingleValue("select id from tblstudentdata where rollno='" + lblroll.Text + "'")).ToString();
        if (ido!=null && ido!="")
        {
            val = lblname.Text.Split(',');
            
            Cache["id"] = ido;
            if (Cache["id"] != null && Cache["id"] != "")
            {
                binddiscription();
                getcourse();
               // bill();
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Roll No Not Found ')", true);
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string[] arr = new string[5];
        if (TextBox1.Text != null)
        {
            arr = TextBox1.Text.Split(',');
            string ido = Common.Get(objsql.GetSingleValue("select id from tblstudentdata where rollno='" + arr[0] + "'")).ToString();
            if (ido != null && ido != "")
            {
                val = lblname.Text.Split(',');

                Cache["id"] = ido;
                if (Cache["id"] != null && Cache["id"] != "")
                {
                    binddiscription();
                    getcourse();
                  //  bill();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Roll No Not Found ')", true);
            }

        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText, int count)
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = "select (rollno+','+Name) Name from tblstudentdata where " + "name like @Search + '%'";

                com.Parameters.AddWithValue("@Search", prefixText);
                com.Connection = con;
                con.Open();
                List<string> countryNames = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countryNames.Add(sdr["name"].ToString());
                    }
                }
                con.Close();
                return countryNames;


            }

        }

    }
    protected void sms(string Message)
    {
        DataTable dts = new DataTable();

        dts = objsql.GetTable("select * from tblsms");
        if (dts.Rows.Count > 0)
        {
                objsql.SendSMS(dts.Rows[0]["username"].ToString(), dts.Rows[0]["senderid"].ToString(), dts.Rows[0]["alertno"].ToString(), Message, dts.Rows[0]["type"].ToString(), dts.Rows[0]["api"].ToString());
           // objsql.SendSMS(dts.Rows[0]["username"].ToString(), dts.Rows[0]["senderid"].ToString(), "9780551900", Message, dts.Rows[0]["type"].ToString(), dts.Rows[0]["api"].ToString());

        }
    }
}