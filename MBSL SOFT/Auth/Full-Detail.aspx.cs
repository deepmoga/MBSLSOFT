using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Full_Detail : System.Web.UI.Page
{
    public static string id = "", RollNo,rn;
    SQLHelper objsql = new SQLHelper();
    public double paidfee, disco, total2 = 0.0, disc = 0.0, paid = 0.0, pending2 = 0.0;
    public static string  total = "", Pending = "", discout = "", totval = "0", fee = "0", token, ccd, course = "1";
   
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
        }
    }

    protected void BindStudentCourse()
    {

        //dtNew = objsql.GetTable("SELECT * FROM Student_Course  where RollNo='"+RollNo+"'");
        //GrdDetail.DataSource = dtNew;
        //GrdDetail.DataBind();

        DataTable dtNew = new DataTable();

        DataTable dt1 = new DataTable();
       

        dt1 = objsql.GetTable("select * from student_course where rollno='" + RollNo + "'");


        if (dt1.Rows.Count > 0)
        {
            GrdDetail.DataSource = dt1;
            GrdDetail.DataBind();
        }




    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        RollNo = txtsearch.Text;
        id = Common.Get(objsql.GetSingleValue("select id from tblstudentdata where RollNo='" + RollNo + "'"));
        string status = Common.Get(objsql.GetSingleValue("select status from tblstudentdata where RollNo='" + RollNo + "'"));
        if (status == "True")
        {
            lblstatus.Text = "Active";
            lblstatus.CssClass = "label label-success";
        }
        else
        {
            lblstatus.Text = "Deactive";
            lblstatus.CssClass = "label label-Danger";
        }
        BindStudentCourse();
       
        BindStudent();
       
        
    }
    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbadmit = (Label)e.Row.FindControl("lbladmitdate");
            Label lbstart = (Label)e.Row.FindControl("lblend");
            lbadmit.Text = DateTime.Parse(lbadmit.Text).ToString("dd/MM/yyyy");
            lbstart.Text = DateTime.Parse(lbstart.Text).ToString("dd/MM/yyyy");
        }
    }


    #region Logs

    public void BindStudent()
    {
         DataSet ds = new DataSet();
        //ds = objsql.GetDataset("select st.name,st.fname,st.Id,sc.CourseName,sc.Time,s.RollNo,s.TotalFees,s.CourseId,s.Date,s.Pending_Fees,s.TotalPaidFees,m.PaidFees,s.instalmentamount,s.noofinstalment,s.discount from Student_Fee s,Fees_Master m,tblstudentdata st,Student_Course sc where s.RollNo=m.RollNo and s.RollNo=st.rollno and s.RollNo=sc.RollNo and s.RollNo='"+ RollNo +"' ");
        ds = objsql.GetDataset(" select r.id,r.rollno,r.particular,r.amount as paid,r.courseid,r.active,r.date,r.oldreceiptno,r.ReciptNo,m.totalfees,r.cancelauthorisation,f.discount,r.tokenno,f.fromdate,f.todate ,f.pending_fees_alert,f.pending_fees from Recipt_Details r , Fees_Master m,student_fee f  where r.rollno='"+RollNo+"' and r.courseid=m.courseid  and m.rollno=r.rollno and f.token=r.tokenno order by r.date asc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
         
        }
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "slip")
        {
            using (TransactionScope ex = new TransactionScope())
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                token = arg[0];
                ccd = arg[1];
                string mmid = Common.Get(objsql.GetSingleValue("select Max(id) from Student_Fee where CourseId='" + ccd + "' and RollNo='" + RollNo + "'"));
                string maxid = Common.Get(objsql.GetSingleValue("select Token from Student_Fee where id='" + mmid + "' "));

                DataSet ds1 = new DataSet();
                ds1 = objsql.GetDataset("select * from Student_Fee where Token='" + maxid + "'");
                if (maxid != "" && maxid != null)
                {
                    if (token == maxid) // check last slip
                    {
                        string totpaid = Common.Get(objsql.GetSingleValue("select PaidFees from Fees_Master  where CourseId='" + ccd + "' and RollNo='" + RollNo + "'"));
                        string nowpaid = (Convert.ToInt32(totpaid) - Convert.ToInt32(ds1.Tables[0].Rows[0]["TodayPaidFee"])).ToString();
                        objsql.ExecuteNonQuery("update Fees_Master set PaidFees='" + nowpaid + "' where CourseId='" + ccd + "' and RollNo='" + RollNo + "'");
                        objsql.ExecuteNonQuery("delete from Student_Fee where Token='" + token + "'");
                        objsql.ExecuteNonQuery("delete from Recipt_Details where TokenNo='" + token + "'");
                        string alert = Common.Get(objsql.GetSingleValue("select ToDate from Student_Fee where CourseId='" + ccd + "' and RollNo='" + RollNo + "' order by id desc"));
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
    }
    #endregion

    #region complete course
   
    #endregion
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblfee = (Label)e.Row.FindControl("lbltotal");

            Label lblpaidfee = (Label)e.Row.FindControl("lblpaidfee");
            Label lbldiscount = (Label)e.Row.FindControl("lbldiscount");
            Label date = (Label)e.Row.FindControl("lbldate");
            Label from = (Label)e.Row.FindControl("lblfrom");
            Label to = (Label)e.Row.FindControl("lblto");
            Label alertdate = (Label)e.Row.FindControl("lbladate");
            Label status = (Label)e.Row.FindControl("lblstatus");
            date.Text = DateTime.Parse(date.Text).ToString("dd/MM/yyyy");
            from.Text = DateTime.Parse(from.Text).ToString("dd/MM/yyyy");
            to.Text = DateTime.Parse(to.Text).ToString("dd/MM/yyyy");
            if (alertdate.Text != "")
            {
                alertdate.Text = DateTime.Parse(alertdate.Text).ToString("dd/MM/yyyy");
            }
           

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


        }
    }
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {

    }
}