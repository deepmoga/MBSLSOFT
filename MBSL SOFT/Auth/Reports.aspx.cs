using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_Reports : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string Code = "", id = "", Rep_Name = "", Date = "";
    public double total_expense = 0.00, totalIncome = 0.00, Total = 0.00;
    public DataTable dtexpense = new DataTable();
    public DataTable dtstdfees = new DataTable();
    public DataTable dtoCharge = new DataTable();
    public DataTable dtlpu = new DataTable();
    public DataTable dtNew1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("~/Login.aspx");
        if (!IsPostBack)
        {
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
                lblcode.Visible = true;
                Panel2.Visible = true;
                bindfranch();
                // ModalPopupExtender1.Show();
               // lblcode.Text =Session["Admin"].ToString();

            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();


            }
            if (Session["Red Cross Receptionist"] != null)
            {
                lblcode.Text = Session["Red Cross Receptionist"].ToString();


            }
            //id = Session["id"].ToString();
            //Rep_Name = lblcode.Text;
            //Code = Common.Get(objsql.GetSingleValue("Select CenterCode from Receptionist where id='" + id + "' and Name='" + Rep_Name + "'"));
            //Code = lblcode.Text;
            //  getExpenseName();
            getCourse();
            getlpuPayments();

            ((LinkButton)Master.FindControl("lnkfranc")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkdash")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkreception")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkstureg")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkdeactivate")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkinq")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkmaster")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkexpense")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkresume")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkother")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkresult")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkfvresult")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkcerti")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkreport")).CssClass = "active";
            ((LinkButton)Master.FindControl("lnkrecept")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkperformance")).CssClass = "";
            ((LinkButton)Master.FindControl("lnkviewstu")).CssClass = "";
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
        }

    }
    protected void BtnLoadReport_Click(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            if (ddlfranc.SelectedItem.Text == "Select Franchisee")
            {
                Page.RegisterStartupScript("d", "<script> alert('Please Select Franchisee')</script>");
            }

            else
            {
                bindReport();
            }
        }
        else
        {
            bindReport();
        }

    }

    protected void bindReport()
    {
        string fromdate = "";
        string todate = "";
        string[] alldatevalues = new string[3];
        Code = lblcode.Text;
        total_expense = 0.00;
        totalIncome = 0.00;
        if (txtFromDate.Text!= "")
        {
            alldatevalues = txtFromDate.Text.Split("/".ToCharArray());
        }
      
        if (alldatevalues.Length >= 3)
        {
            fromdate = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
        }
        if (txtToDate.Text != "")
        {
            alldatevalues = txtToDate.Text.Split("/".ToCharArray());
        }

        if (alldatevalues.Length >= 3)
        {
            todate = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
        }
        

        //  DataTable dtNew = new DataTable();

         

        dtNew1.Columns.Add(new DataColumn("Income", typeof(string)));
        dtNew1.Columns.Add(new DataColumn("Expense_Name", typeof(string)));
        dtNew1.Columns.Add(new DataColumn("Amount", typeof(string)));
        dtNew1.Columns.Add(new DataColumn("Date", typeof(string)));


        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            if (ddltype.SelectedIndex != 0)
            {

                if (ddltype.SelectedItem.Text == "Expense")
                {

                    dtexpense = objsql.GetTable("Select Expense_Name,Amount,Date From Expenses_Details where convert(datetime, [Date], 120) >= " +
                                        "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                                        "convert(datetime, '" + todate + "', 120)   and  CenterCode='" + lblcode.Text + "' ");

                    if (dtexpense.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dtexpense.Rows)
                        {
                            DataRow dr1 = dtNew1.NewRow();
                            dr1["Expense_Name"] = dr[0].ToString();
                            dr1["Amount"] = dr[1].ToString();
                            dr1["Income"] = "";
                            dr1["Date"] = dr[2].ToString();
                            // TotalExpense += Convert.ToDouble(dr[0]);
                            total_expense += Convert.ToDouble(dr[1]);
                            dtNew1.Rows.Add(dr1);
                        }
                    }


                }
                if (ddltype.SelectedItem.Text == "Course Fees")
                {
                    dtstdfees = objsql.GetTable("Select TodayPaidFee,CourseId,Date  From Student_Fee where convert(datetime, [Date], 120) >= " +
                                  "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                                  "convert(datetime, '" + todate + "', 120)   and  CenterCode='" + lblcode.Text + "' and TodayPaidFee!='0' order by CourseId ");
                    if (dtstdfees.Rows.Count > 0)
                    {
                        string nm = "";
                        double am = 0;

                        foreach (DataRow dr in dtstdfees.Rows)
                        {
                            string cid =Common.Get(objsql.GetSingleValue("Select CourseName from Course where CourseId='" + dr[1].ToString() + "'  and  CenterCode='" + lblcode.Text + "'"));
                            if (cid == nm)
                            {
                                nm = cid;
                                am += Convert.ToDouble(dr[0]);
                                Date = dr[2].ToString();
                            }
                            else
                            {
                                if (nm != "")
                                {
                                    DataRow dr1 = dtNew1.NewRow();
                                    dr1["Expense_Name"] = "";
                                    dr1["Income"] = nm;
                                    dr1["Amount"] = am;
                                    dr1["Date"] = dr[2].ToString();
                                    totalIncome += am;
                                    dtNew1.Rows.Add(dr1);
                                }
                                nm = cid;
                                string x = dr[0].ToString();
                                am = Convert.ToDouble(x);
                                Date = dr[2].ToString();
                            }

                        }
                        DataRow dr2 = dtNew1.NewRow();

                        dr2["Expense_Name"] = "";
                        dr2["Income"] = nm;
                        dr2["Amount"] = am;
                        dr2["Date"] = Date;
                        totalIncome += am;
                        dtNew1.Rows.Add(dr2);
                    }


                }
                //if (ddltype.SelectedItem.Text == "Lpu Payments")
                //{
                //    dtlpu = objsql.GetTable("Select  Amount,Expense_Name,Date  From  LPU_Expense where convert(nvarchar(200), [Date], 120) >= " +
                //              "convert(nvarchar(200), '" + txtFromDate.Text + "', 120) and convert(nvarchar(200), [Date], 120) <= " +
                //              "convert(nvarchar(200), '" + txtToDate.Text + "', 120)   and  CenterCode='" + lblcode.Text + "'");
                //    if (dtlpu.Rows.Count > 0)
                //    {
                //        foreach (DataRow dr in dtlpu.Rows)
                //        {

                //            DataRow dr1 = dtNew1.NewRow();
                //            dr1["Expense_Name"] = "";
                //            dr1["Income"] = dr[1].ToString();
                //            dr1["Amount"] = dr[0].ToString();
                //            dr1["Date"] = dr[2].ToString();
                //            totalIncome += Convert.ToDouble(dr[0]);

                //            dtNew1.Rows.Add(dr1);
                //        }
                //    }
                //}


                if (ddltype.SelectedItem.Text == "Other Charges")
                {
                    dtoCharge = objsql.GetTable("Select Paid,ChargeName,Date From S_OtherCharges where convert(datetime, [Date], 120) >= " +
                                  "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                                  "convert(datetime, '" + todate + "', 120)   and  CenterCode='" + lblcode.Text + "' order by ChargeName ");
                    if (dtoCharge.Rows.Count > 0)
                    {
                        string nm = "";
                        double am = 0;

                        foreach (DataRow dr in dtoCharge.Rows)
                        {
                            string cid = dr[1].ToString();
                            if (cid == nm)
                            {
                                nm = cid;
                                am += Convert.ToDouble(dr[0]);
                                Date = dr[2].ToString();
                            }
                            else
                            {
                                if (nm != "")
                                {
                                    DataRow dr1 = dtNew1.NewRow();
                                    dr1["Expense_Name"] = "";
                                    dr1["Income"] = nm;
                                    dr1["Amount"] = am;
                                    totalIncome += am;
                                    dr1["Date"] = dr[2].ToString();
                                    dtNew1.Rows.Add(dr1);
                                }
                                nm = cid;
                                string x = dr[0].ToString();
                                am = Convert.ToDouble(x);
                                Date = dr[2].ToString();
                            }

                        }
                        DataRow dr2 = dtNew1.NewRow();

                        dr2["Expense_Name"] = "";
                        dr2["Income"] = nm;
                        dr2["Amount"] = am;
                        dr2["Date"] = Date;
                        totalIncome += am;
                        dtNew1.Rows.Add(dr2);
                    }

                }
            }

            else
            {
                dtexpense = objsql.GetTable("Select Expense_Name,Amount,Date From Expenses_Details where convert(datetime, [Date], 120) >= " +
                                  "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                                 "convert(datetime, '" + todate + "', 120)   and  CenterCode='" + lblcode.Text + "'");

                if (dtexpense.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtexpense.Rows)
                    {
                        DataRow dr1 = dtNew1.NewRow();
                        dr1["Expense_Name"] = dr[0].ToString();
                        dr1["Income"] = "";
                        dr1["Amount"] = dr[1].ToString();
                        dr1["Date"] = dr[2].ToString();
                        total_expense += Convert.ToDouble(dr[1]);

                        dtNew1.Rows.Add(dr1);
                    }
                }
                //dtlpu = objsql.GetTable("Select  Amount,Expense_Name,Date  From  LPU_Expense where convert(nvarchar(200), [Date], 120) >= " +
                //                   "convert(nvarchar(200), '" + txtFromDate.Text + "', 120) and convert(nvarchar(200), [Date], 120) <= " +
                //                   "convert(nvarchar(200), '" + txtToDate.Text + "', 120)   and  CenterCode='" + lblcode.Text + "'");

                //if (dtlpu.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dtlpu.Rows)
                //    {

                //        DataRow dr1 = dtNew1.NewRow();
                //        dr1["Expense_Name"] = "";
                //        dr1["Income"] = dr[1].ToString();
                //        dr1["Amount"] = dr[0].ToString();
                //        dr1["Date"] = dr[2].ToString();
                //        totalIncome += Convert.ToDouble(dr[0]);

                //        dtNew1.Rows.Add(dr1);
                //    }
                //}
                dtstdfees = objsql.GetTable("Select TodayPaidFee,CourseId,Date From Student_Fee where convert(datetime, [Date], 120) >= " +
                                       "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                                       "convert(datetime, '" + todate+ "', 120)   and  CenterCode='" + lblcode.Text + "' and TodayPaidFee!='0' order by CourseId");

                if (dtstdfees.Rows.Count > 0)
                {
                    string nm = "";
                    double am = 0;

                    foreach (DataRow dr in dtstdfees.Rows)
                    {
                        string cid = Common.Get(objsql.GetSingleValue("Select CourseName from Course where CourseId='" + dr[1].ToString() + "'  and  CenterCode='" + lblcode.Text + "'"));
                        if (cid == nm)
                        {
                            nm = cid;
                            double val;
                            if (double.TryParse(dr[0].ToString(), out val))
                            {

                                am += Convert.ToDouble(dr[0]);
                            }
                            Date = dr[2].ToString();
                        }
                        else
                        {
                            if (nm != "")
                            {
                                DataRow dr1 = dtNew1.NewRow();
                                dr1["Expense_Name"] = "";
                                dr1["Amount"] = am;
                                dr1["Income"] = nm;
                                dr1["Date"] = dr[2].ToString();
                                totalIncome += am;
                                //  totalIncome += Convert.ToDouble(dr[0]);

                                dtNew1.Rows.Add(dr1);
                            }
                            nm = cid;
                            string x = dr[0].ToString();
                            am = Convert.ToDouble(x);
                            Date = dr[2].ToString();
                        }

                    }
                    DataRow dr2 = dtNew1.NewRow();
                    dr2["Expense_Name"] = "";
                    dr2["Amount"] = am;
                    dr2["Income"] = nm;
                    dr2["Date"] = Date;
                    totalIncome += am;
                    dtNew1.Rows.Add(dr2);
                }

                dtoCharge = objsql.GetTable("Select Paid,ChargeName,Date From S_OtherCharges where convert(datetime, [Date], 120) >= " +
                              "convert(datetime, '" + fromdate + "', 120) and convert(datetime, [Date], 120) <= " +
                              "convert(nvarchar(200), '" +todate + "', 120)   and  CenterCode='" + lblcode.Text + "' order by ChargeName ");
                if (dtoCharge.Rows.Count > 0)
                {
                    string nm = "";
                    double am = 0;

                    foreach (DataRow dr in dtoCharge.Rows)
                    {
                        string cid = dr[1].ToString();
                        if (cid == nm)
                        {
                            nm = cid;
                            am += Convert.ToDouble(dr[0]);
                            Date = dr[2].ToString();
                        }
                        else
                        {
                            if (nm != "")
                            {
                                DataRow dr1 = dtNew1.NewRow();
                                dr1["Expense_Name"] = "";
                                dr1["Income"] = nm;
                                dr1["Amount"] = am;
                                dr1["Date"] = dr[2].ToString();
                                totalIncome += am;
                                // totalIncome += Convert.ToDouble(dr[0]);
                                dtNew1.Rows.Add(dr1);
                            }
                            nm = cid;
                            string x = dr[0].ToString();
                            am = Convert.ToDouble(x);
                            Date = dr[2].ToString();
                        }

                    }
                    DataRow dr2 = dtNew1.NewRow();

                    dr2["Expense_Name"] = "";
                    dr2["Income"] = nm;
                    dr2["Amount"] = am;
                    dr2["Date"] = Date;
                    totalIncome += am;
                    dtNew1.Rows.Add(dr2);
                }
                // }
            }

        }
        //if (dtNew1.Rows.Count > 0)
        //{
        gridPaymentinfo.DataSource = dtNew1;
        gridPaymentinfo.DataBind();
        //}



        Total = totalIncome - total_expense;
    }
    //protected void getExpenseName()
    //{
    //    DataTable dt = new DataTable();
    //    dt = objsql.GetTable("Select Distinct Expense_Name from Expenses_Details where CenterCode='"+Code+"'");
    //    ddlExpense.DataSource = dt;
    //    ddlExpense.DataTextField = "Expense_Name";
    //    ddlExpense.DataValueField = "Expense_Name";
    //    ddlExpense.DataBind();
    //    ddlExpense.Items.Insert(0, "-- All --");

    //}

    protected void getCourse()
    {
        //DataTable dt = new DataTable();
        //dt = objsql.GetTable("Select Distinct CourseId,CourseName from Course where CenterCode='" + Code + "'");
        //ddlCourseWiseFees.DataSource = dt;

        //ddlCourseWiseFees.DataTextField = "CourseName";
        //ddlCourseWiseFees.DataValueField = "CourseId";
        //ddlCourseWiseFees.DataBind();
        //ddlCourseWiseFees.Items.Insert(0, "-- All --");
    }

    protected void getlpuPayments()
    {
        //    DataTable dt = new DataTable();
        //    dt = objsql.GetTable("Select Distinct Expense_Name from LPU_Expense where CenterCode='" + Code + "'");
        //    ddlLpuPayments.DataSource = dt;

        //    ddlLpuPayments.DataTextField = "Expense_Name";
        //    ddlLpuPayments.DataValueField = "Expense_Name";
        //    ddlLpuPayments.DataBind();
        //    ddlLpuPayments.Items.Insert(0, "-- All --");
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedIndex == 0)
        {
            pnltype.Visible = true;
        }
        else
        {
            pnltype.Visible = false;
        }
    }


    protected void btnExporttoexcel_Click(object sender, EventArgs e)
    {

        bindReport();
        DataSet dsreg = new DataSet("table");
        dsreg.Tables.Add(dtNew1);

        string filenam = "filename.xls";


        Response.Clear();
        Response.ClearContent();
        Response.ContentType = "application/excel";
        Response.AppendHeader("content-disposition", "attachment; filename=Registrantslist_" + filenam);

        gridPaymentinfo.AllowSorting = false;
        gridPaymentinfo.AllowPaging = false;

        gridPaymentinfo.DataSource = dtNew1;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);


        gridPaymentinfo.DataBind();
        gridPaymentinfo.RenderControl(hw);

        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void ddlfranc_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblcode.Text = ddlfranc.SelectedItem.Value;
        bindReport();
    }
    protected void bindfranch()
    {
        DataTable dt3 = new DataTable();
        dt3 = objsql.GetTable("SELECT CenterName,centercode from FranchiseeDetails");
        ddlfranc.DataSource = dt3;
        ddlfranc.DataValueField = "centercode";
        ddlfranc.DataTextField = "CenterName";
        ddlfranc.DataBind();
        ddlfranc.Items.Insert(0, "Select Franchisee");
    }
    protected void gridPaymentinfo_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) ||
             (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            string[] alldatevalues = new string[3];
            Label lbldate = (Label)e.Item.FindControl("lbldate");
            if (lbldate.Text != "")
            {
                alldatevalues = lbldate.Text.Split("/".ToCharArray());
            }

            if (lbldate.Text.Length >= 3)
            {
                lbldate.Text = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
            }
        }
    }
}