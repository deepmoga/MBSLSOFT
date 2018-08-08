using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class Auth_Dashboard_Pending : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string month = "", timecheck, from = "", to = "", paidfee = "", rollno = "", courseid = "", formatdate = "", Token = "", pid = "", pendos = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtdate2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            bindpending();
        }
    }
    protected void bindpending()
    {
        DataTable dtp = new DataTable();
        dtp = objsql.GetTable("select distinct f.id,s.id as rid,s.rollno,s.name,s.fathername,c.CourseName,f.fees,f.alertdate from tblstudentdata s , tblpendingfee f , Course c,student_course sc where s.rollno=f.RollNo and c.CourseId=f.CourseId and (convert(datetime, f.[alertdate], 120) <= convert(datetime,'" + changedate(txtdate2.Text) + "' , 120)) and f.alertdate!='' and f.status='1' and s.status='1' and sc.status='1' and sc.rollno=f.rollno");
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
    protected void gvpending_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvpending.EditIndex = e.NewEditIndex;
       
        bindpending();

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
    protected void insertpaid()
    {
        using (TransactionScope ts = new TransactionScope())
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
    public string changedate(string dates)
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
    protected void txtdate2_TextChanged(object sender, EventArgs e)
    {
        bindpending();
    }
}