using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Auth_add__master_details : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string Code = "", newdate;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
        //    Response.Redirect("~/login.aspx");

        //HyperLink h1 = (HyperLink)(Master.FindControl("lnkHome"));
        //h1.CssClass = "";
        //HyperLink h2 = (HyperLink)(Master.FindControl("lnkReg"));
        //h2.CssClass = "";
        //HyperLink h3 = (HyperLink)(Master.FindControl("lnkDetails"));
        //h3.CssClass = "";
        //HyperLink h4 = (HyperLink)(Master.FindControl("lnkInquiry"));
        //h4.CssClass = "";
        //HyperLink h5 = (HyperLink)(Master.FindControl("lnkBatch"));
        //h5.CssClass = "active";

        if (!IsPostBack)
        {
            bindfanch();
            coursetype();
           txtCourseId.Text=GenerateLeadNo();
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
             //   ModalPopupExtender1.Show();
                //lblcode.Text =ddlfanch.SelectedItem.Value;

            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();


            }
            if (Session["Red Cross Receptionist"] != null)
            {
                lblcode.Text = Session["Red Cross Receptionist"].ToString();


            }
            //ClearFields(this);
            //Code = lblcode.Text;
            //getCategory();
            if (!Page.IsPostBack)
            {
                //Code = lblcode.Text;
                if (Request.QueryString["Cat_Id"] != null && Request.QueryString["Cat_Id"] != "")
                {

                    BindDescriptionCat();
                    pnlBatch.Visible = false;
                    PnlCategory.Visible = true;
                    pnlCourse.Visible = false;
                }


                else if (Request.QueryString["Time_Id"] != null && Request.QueryString["Time_Id"] != "")
                {

                    BindDescription();
                    pnlBatch.Visible = true;
                    PnlCategory.Visible = false;
                    pnlCourse.Visible = false;
                }

                else if (Request.QueryString["Course_Id"] != null && Request.QueryString["Course_Id"] != "")
                {

                    BindDescriptionCourse();
                    pnlBatch.Visible = false;
                    PnlCategory.Visible = false;
                    pnlCourse.Visible = true;

                }
                else if (Request.QueryString["Grade_Id"] != null && Request.QueryString["Grade_Id"] != "")
                {

                    BindDescriptionGrade();
                    pnlBatch.Visible = false;
                    PnlCategory.Visible = false;
                    pnlCourse.Visible = false;
                    pnlGrade.Visible = true;

                }
                else if (Request.QueryString["teach_id"] != null && Request.QueryString["teach_id"] != "")
                {
                    Bindfranchisee();
                    bindteacher();
                    pnladmin.Visible = true;
                    pnlBatch.Visible = false;
                    PnlCategory.Visible = false;
                    pnlCourse.Visible = false;
                    pnlGrade.Visible = false;
                    Pnlteacher.Visible = true;
                }
                else
                {
                    txtCourseId.Text = GenerateLeadNo();
                    txtCategoryCode.Text = GenerateCategoryCode();
                    txtcode.Text = Generateteachercode();
                }
            }


            if (Request.QueryString["addcat"] != null && Request.QueryString["addcat"] != "")
            {

                //BindDescriptionCat();
                pnlBatch.Visible = false;
                PnlCategory.Visible = true;
                pnlCourse.Visible = false;
            }

            else if (Request.QueryString["batchtime"] != null && Request.QueryString["batchtime"] != "")
            {

                //BindDescription();
                pnlBatch.Visible = true;
                PnlCategory.Visible = false;
                pnlCourse.Visible = false;
            }

            else if (Request.QueryString["course"] != null && Request.QueryString["course"] != "")
            {

                //BindDescriptionCourse();
                pnlBatch.Visible = false;
                PnlCategory.Visible = false;
                pnlCourse.Visible = true;

            }

            else if (Request.QueryString["grade"] != null && Request.QueryString["grade"] != "")
            {

                //BindDescriptionGrade();
                pnlBatch.Visible = false;
                PnlCategory.Visible = false;
                pnlCourse.Visible = false;
                pnlGrade.Visible = true;

            }
            else if (Request.QueryString["teach"] != null && Request.QueryString["teach"] != "")
            {

                //BindDescriptionGrade();
                pnlBatch.Visible = false;
                PnlCategory.Visible = false;
                pnlCourse.Visible = false;
                pnlGrade.Visible = false;
                Pnlteacher.Visible = true;

            }
        }

 
    }



    protected void BindDescription()
    {
        string batch = "";
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("Select * from Batch_Timming where Id =" + Request.QueryString["Time_Id"].ToString());
        if (dt1.Rows.Count > 0)
        {
            batch = dt1.Rows[0]["Time"].ToString().Replace("''", "'");
            {

                string[] allvalues = new string[5];
                if (batch != "")
                {
                    allvalues = batch.Split(" ".ToCharArray());

                }


                //if (allvalues[0] != null)
                //{

                //    txtFrom.Text = allvalues[0].Trim();
                //    for (int k = 0; k < ddlFrom.Items.Count; k++)
                //    {
                //        if (ddlFrom.Items[k].Text == allvalues[1].Trim())
                //        {
                //            ddlFrom.SelectedIndex = k;
                //            break;
                //        }
                //    }

                //    txtTo.Text = allvalues[3].Trim();
                //    for (int h = 0; h < ddlTo.Items.Count; h++)
                //    {
                //        if (ddlTo.Items[h].Text == allvalues[4].Trim())
                //        {
                //            ddlTo.SelectedIndex = h;
                //            break;
                //        }
                //    }


                //}

            }


        }
    }

    protected void BindDescriptionCourse()
    {
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("Select * from Course where Id =" + Request.QueryString["Course_Id"].ToString());
        if (dt1.Rows.Count > 0)
        {
            txtCourseId.Text = dt1.Rows[0]["CourseId"].ToString().Replace("''", "'");
            txtCourseName.Text = dt1.Rows[0]["CourseName"].ToString().Replace("''", "'");
            txtDuration.Text = dt1.Rows[0]["Duration"].ToString().Replace("''", "'");
            txtEligibility.Text = dt1.Rows[0]["Eligibilty"].ToString().Replace("''", "'");
            txtFee.Text = dt1.Rows[0]["Fees"].ToString().Replace("''", "'");
            txtMinHour.Text = dt1.Rows[0]["minHour"].ToString().Replace("''", "'");
            txtdurWords.Text = dt1.Rows[0]["C_Duration"].ToString().Replace("''", "'");
            txt2.Text = dt1.Rows[0]["twomonth"].ToString().Replace("''", "'");
            txt3.Text = dt1.Rows[0]["threemonth"].ToString().Replace("''", "'");
            txt4.Text = dt1.Rows[0]["fourmonth"].ToString().Replace("''", "'");
            //txtnoofinstlmnts.Text = dt1.Rows[0]["no_of_insatalments"].ToString().Replace("''", "'");
            txtinstalamount.Text = dt1.Rows[0]["instalment_amount"].ToString().Replace("''", "'");
            for (int k = 0; k < ddlDurationType.Items.Count; k++)
            {
                if (ddlDurationType.Items[k].Text == dt1.Rows[0]["Duration_Type"].ToString().Replace("''", "'"))
                {
                    ddlDurationType.SelectedIndex = k;
                    break;
                }
            }
            for (int k = 0; k < ddlCourseType.Items.Count; k++)
            {
                if (ddlCourseType.Items[k].Text == dt1.Rows[0]["CourseType"].ToString().Replace("''", "'"))
                {
                    ddlCourseType.SelectedIndex = k;
                    break;
                }
            }

        }
     //   txtnoofinstlmnts.Enabled = false;
        txtinstalamount.Enabled = false;
    }

    protected void BindDescriptionGrade()
    {
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("Select * from tblgrade where id =" + Request.QueryString["Grade_Id"].ToString());
        if (dt1.Rows.Count > 0)
        {

            txtMaxPerc.Text = dt1.Rows[0]["MaxPercantage"].ToString().Replace("''", "'");
            txtMinPerc.Text = dt1.Rows[0]["MinPercantage"].ToString().Replace("''", "'");
            txtgrde.Text = dt1.Rows[0]["Grade"].ToString().Replace("''", "'");

            for (int k = 0; k < ddlCenter.Items.Count; k++)
            {
                if (ddlCenter.Items[k].Text == dt1.Rows[0]["G_Type"].ToString().Replace("''", "'"))
                {
                    ddlCenter.SelectedIndex = k;
                    break;
                }
            }

        }
    }

    protected void BindDescriptionCat()
    {
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("Select * from tblroom where  id='" + Request.QueryString["id"] + "' Order By id asc");
        if (dt1.Rows.Count > 0)
        {

            txtCategoryCode.Text = dt1.Rows[0]["id"].ToString().Replace("''", "'");
            txtCategoryName.Text = dt1.Rows[0]["room"].ToString().Replace("''", "'");


        }
    }





    protected void fvAddCategory_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["Cat_Id"] != null && Request.QueryString["Cat_Id"] != "")
        {
            int i = objsql.ExecuteNonQuery1("update tblroom set id='" + txtCategoryCode.Text + "',room='" + txtCategoryName.Text + "' where id=" + Request.QueryString["id"]);

            if (i > 0)
            {

                //  getCategory();


                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Room Updated successfully!!')</script>");
                Response.Redirect("add--master-details.aspx");
                //ClearFields(this);

            }
            else
            {

                //getCategory();
                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Room not Updated!!!)</script>");
                //ClearFields(this);
            }
        }
        else
        {

            int i = objsql.ExecuteNonQuery1("insert into tblroom (room) Values('" + txtCategoryName.Text + "')");

            if (i > 0)
            {


                //getCategory();

                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Room added successfully')</script>");
                //Response.Redirect("Add-Master-Details.aspx");
                //ClearFields(this);
            }
            else
            {
                //getCategory();
                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Room already present')</script>");
                //ClearFields(this);
            }
        }
    }

    protected string GenerateCategoryCode()
    {
        string LeadNo = "";

        string id = objsql.GetSingleValue("select max(id) from Category where centercode='" + lblcode.Text + "'").ToString();
        if (id == "")
        {
            return "Room_101";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select CategoryCode from Category where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo.Replace("Room_", "0"));
            oldlead += 1;

            return "Room_" + oldlead.ToString();

        }




    }

    protected string GenerateLeadNo()
    {
        string LeadNo = "";

        string id = objsql.GetSingleValue("select max(id) from Course").ToString();
        if (id == "")
        {
            return  "1001";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select CourseId from Course where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo);
            oldlead += 1;

            return oldlead.ToString();

        }

    }

    //private void ClearFields(admin_add_master_details admin_add_master_details)
    //{
    //    throw new NotImplementedException();
    //}
    protected void fvReset_Click(object sender, EventArgs e)
    {

        txtCategoryName.Text = "";
        txtCategoryCode.Text = GenerateCategoryCode();

    }


    protected void LnkAddCategory_Click(object sender, EventArgs e)
    {
        PnlCategory.Visible = true;
        pnlBatch.Visible = false;
        pnlCourse.Visible = false;
        pnlGrade.Visible = false;
    }
    protected void LnkAddCourses_Click(object sender, EventArgs e)
    {
        pnlBatch.Visible = false;
        pnlCourse.Visible = true;
        PnlCategory.Visible = false;
        pnlGrade.Visible = false;
    }
    protected void LnkBatch_Click(object sender, EventArgs e)
    {
        pnlBatch.Visible = true;
        pnlCourse.Visible = false;
        PnlCategory.Visible = false;
        pnlGrade.Visible = false;
    }
    protected void lnkaddGrade_Click(object sender, EventArgs e)
    {
        pnlBatch.Visible = false;
        PnlCategory.Visible = false;
        pnlCourse.Visible = false;
        pnlGrade.Visible = true;
    }


    protected void addcategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcategory.aspx?type=" + lblcode.Text);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void fvAddCourse_Click(object sender, EventArgs e)
    {
        // double feeparday = Convert.ToDouble(txtFee.Text) / 30;
        if (Request.QueryString["Course_Id"] != null && Request.QueryString["Course_Id"] != "")
        {
            //CourseId='" + txtCourseId.Text + "',

            int i = objsql.ExecuteNonQuery1("update Course set CourseName='" + txtCourseName.Text + "',Duration='" + txtDuration.Text + "',Eligibilty='" + txtEligibility.Text + "',Fees='" + txtFee.Text + "',minHour='" + txtMinHour.Text + "',Duration_Type='" + ddlDurationType.SelectedItem.Text + "', CourseType='" + ddlCourseType.SelectedItem.Text + "' ,C_duration='" + txtdurWords.Text + "',instalment_amount='" + txtinstalamount.Text + "',twomonth='"+txt2.Text+"',threemonth='"+txt3.Text+"',fourmonth='"+txt4.Text+"' where  id=" + Request.QueryString["Course_Id"]);

            //objsql.ExecuteNonQuery("update Student_Course set CourseName='" + txtCourseName.Text + "' where CourseId='" + txtCourseId.Text + "'");
            if (i > 0)
            {

                //   getCourse();

                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Course Updated successfully!!')</script>");
                Response.Redirect("add--master-details.aspx");


            }
            else
            {

                //   getCourse();
                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Course not Updated!!!)</script>");
                // ClearFields(this);
            }
        }
        else
        {
            string checkname = Common.Get(objsql.GetSingleValue("select CourseName from course where CourseName='" + txtCourseName.Text + "'"));
            if (checkname == "")
            {
                int i = objsql.ExecuteNonQuery1("insert into Course (CourseId,CourseName,Duration,Eligibilty,centercode,Fees,minHour,Duration_Type,CourseType,C_Duration,no_of_insatalments,instalment_amount,twomonth,threemonth,fourmonth) Values('" + txtCourseId.Text + "','" + txtCourseName.Text + "','" + txtDuration.Text + "','" + txtEligibility.Text + "','" + lblcode.Text + "','" + txtFee.Text + "','" + txtMinHour.Text + "','" + ddlDurationType.SelectedItem.Text + "','" + ddlCourseType.SelectedItem.Text + "','" + txtdurWords.Text + "','','" + txtinstalamount.Text + "','"+txt2.Text+"','"+txt3.Text+"','"+txt4.Text+"')");
                //  GrdCourse.DataBind();
                if (i > 0)
                {

                    Response.Redirect("viewcourse.aspx");
                    //ClearFields(this);

                }
                
            }
            else
            {

                //  getCourse();
                Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Course Already Exist!!')</script>");
                //ClearFields(this);
            }
        }
    }



    protected void fv1AddBatch_Click(object sender, EventArgs e)
    {
        string timng = txtFrom.Text.Trim() + " " + "-" + " " + txtTo.Text.Trim() + " " ;

        if (Request.QueryString["Time_Id"] != null && Request.QueryString["Time_Id"] != "")
        {
            int i = objsql.ExecuteNonQuery1("update Batch_Timming set Time= '" + timng + "' where id=" + Request.QueryString["Time_Id"]);

            if (i > 0)
            {
                txtFrom.Text = "";
              //  ddlFrom.SelectedIndex = 0;
                txtTo.Text = "";
                //ddlTo.SelectedIndex = 0;

                Page.RegisterStartupScript("d", "<script>alert('Batch Updated Successfully!!')</script>");
                //Response.Redirect("add-master-details.aspx");

            }
            else
            {

                Page.RegisterStartupScript("d", "<script>alert('Batch Not Updated!!')</script>");

            }
        }
        else
        {
            int i = objsql.ExecuteNonQuery1("insert into Batch_Timming values( '" + timng + "','" + lblcode.Text + "')");

            if (i > 0)
            {
                txtFrom.Text = "";
                //ddlFrom.SelectedIndex = 0;
                txtTo.Text = "";
                //ddlTo.SelectedIndex = 0;

                Page.RegisterStartupScript("d", "<script>alert('Batch Added Successfully!!')</script>");
            }
            else
            {

                Page.RegisterStartupScript("d", "<script>alert('Batch Not Added!!')</script>");

            }
        }
    }




    protected void btnGrade_Click(object sender, EventArgs e)
    {
        Code = lblcode.Text;
        int i = 0;
        if (Request.QueryString["Grade_Id"] != null && Request.QueryString["Grade_Id"] != "")
        {
            i = objsql.ExecuteNonQuery1("update tblGrade set CenterCode= '" + lblcode.Text + "',MinPercantage='" + txtMinPerc.Text + "',MaxPercantage='" + txtMaxPerc.Text + "',Grade='" + txtgrde.Text + "',G_Type='" + ddlCenter.SelectedItem.Text + "' where id=" + Request.QueryString["Grade_Id"]);
        }
        else
        {

            i = objsql.ExecuteNonQuery1("insert into tblGrade(MaxPercantage,MinPercantage,Grade,centercode,G_Type) values( '" + txtMaxPerc.Text + "','" + txtMinPerc.Text + "','" + txtgrde.Text + "','" + lblcode.Text + "','" + ddlCenter.SelectedItem.Text + "')");
        }
        if (i > 0)
        {
            txtMinPerc.Text = "";
            txtMaxPerc.Text = "";
            txtgrde.Text = "";
            ddlCenter.SelectedIndex = 0;
            Page.RegisterStartupScript("d", "<script>alert('Grade Added Successfully!!')</script>");
        }
        else
        {

            Page.RegisterStartupScript("d", "<script>alert('Grade Not Added!!')</script>");

        }
    }




    protected void viewbatch_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewbatchtime.aspx?type=" + lblcode.Text);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcourse.aspx?type=" + lblcode.Text);
    }
    protected void viewgrade_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewgrade.aspx?type=" + lblcode.Text);
    }
    protected void bindfanch()
    {
        DataTable dtc = new DataTable();
        dtc = objsql.GetTable("SELECT CenterName,centercode from FranchiseeDetails");
        ddlfanch.DataSource = dtc;
        ddlfanch.DataTextField = "CenterName";
        ddlfanch.DataValueField = "centercode";
        ddlfanch.DataBind();
        ddlfanch.Items.Insert(0, new ListItem("--Select Type--", "0"));
    }

    protected void btnsubmited_Click(object sender, EventArgs e)
    {
        lblcode.Text = ddlfanch.SelectedItem.Value;
    }
    protected void lnkviewtype_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcoursetype.aspx?type=" + lblcode.Text);
    }
    protected void coursetype()
    {
        DataTable dt35 = new DataTable();
        dt35 = objsql.GetTable("SELECT Type from tblCourseType");
        ddlCourseType.DataSource = dt35;
        ddlCourseType.DataValueField = "Type";
        ddlCourseType.DataTextField = "Type";
        ddlCourseType.DataBind();
        ddlCourseType.Items.Insert(0, "Select Course Type");
    }


    protected void lnkteacher_Click(object sender, EventArgs e)
    {
        Response.Redirect("view-teachers.aspx?type=" + lblcode.Text);
    }
    #region teacher values
    protected string Generateteachercode()
    {
        string LeadNo = "";

        string id = objsql.GetSingleValue("select max(id) from tblteacher").ToString();
        if (id == "")
        {
            return "T_" + "1001";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select teachercode from tblteacher where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo.Replace("T_", "0"));
            oldlead += 1;

            return "T_" + oldlead.ToString();

        }
    }
    protected void btnaddteacher_Click(object sender, EventArgs e)
    {
        Dateconvert();
        if (Request.QueryString["teach_id"] != null && Request.QueryString["teach_id"] != "")
        {
            if (Session["Franchisee"] != null && Session["Franchisee"] != "")
            {
                objsql.ExecuteNonQuery("update tblteacher set teachername='" + txtname.Text + "',fathername='" + txtfather.Text + "',dob='" + newdate + "',phone='" + txtphone.Text + "',address='" + txtaddress.Text + "',centercode='" + Session["Franchisee"].ToString() + "' where id='" + Request.QueryString["teach_id"] + "'");
            }
            if (Session["Admin"] != null && Session["Admin"] != "")
            {
                objsql.ExecuteNonQuery("update tblteacher set teachername='" + txtname.Text + "',fathername='" + txtfather.Text + "',dob='" + newdate + "',phone='" + txtphone.Text + "',address='" + txtaddress.Text + "',email='" + txtemail.Text + "',centercode='" + ddlcode.SelectedItem.Value + "' where id='" + Request.QueryString["teach_id"] + "'");
            }
        }
        else
        {
            if (Session["Franchisee"] != null && Session["Franchisee"] != "")
            {
                objsql.ExecuteNonQuery("insert into tblteacher(teachername,fathername,dob,phone,address,email,teachercode,centercode,status) values('" + txtname.Text + "','" + txtfather.Text + "','" + newdate + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtemail.Text + "','" + txtcode.Text + "','" + Session["Franchisee"].ToString() + "','1')");
            }
            if (Session["Admin"] != null && Session["Admin"] != "")
            {
                objsql.ExecuteNonQuery("insert into tblteacher(teachername,fathername,dob,phone,address,email,teachercode,centercode,status) values('" + txtname.Text + "','" + txtfather.Text + "','" + newdate + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtemail.Text + "','" + txtcode.Text + "','" + ddlcode.SelectedItem.Value + "','1')");
            }
        }
        Response.Redirect("view-teachers.aspx");
    }
    public void Bindfranchisee()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from FranchiseeDetails");
        ddlcode.DataSource = dt;
        ddlcode.DataTextField = "CenterName";
        ddlcode.DataValueField = "centercode";
        ddlcode.DataBind();
        ddlcode.Items.Insert(0, new ListItem("select franchisee"));
    }
    #region date convert
    public void Dateconvert()
    {
        string[] alldate = new string[3];
        alldate = txtdob.Text.Split("/".ToCharArray());
        if (alldate.ToString() != "" && alldate.ToString() != null)
        {
            newdate = alldate[1].Trim() + "/" + alldate[0].Trim() + "/" + alldate[2].Trim();
        }
    }
    #endregion
    #region bind all values
    public void bindteacher()
    {
        DataTable dtp = new DataTable();
        dtp = objsql.GetTable("select * from tblteacher where id='" + Request.QueryString["teach_id"] + "'");
        if (dtp.Rows.Count > 0)
        {
            string ndate = "";
            txtcode.Text = dtp.Rows[0]["teachercode"].ToString();
            txtname.Text = dtp.Rows[0]["teachername"].ToString();
            txtfather.Text = dtp.Rows[0]["fathername"].ToString();
            ndate = dtp.Rows[0]["dob"].ToString();
            string[] allval = new string[3];
            allval = ndate.Split("/".ToCharArray());
            txtdob.Text = allval[1].Trim() + "/" + allval[0].Trim() + "/" + allval[2].Trim();
            txtphone.Text = dtp.Rows[0]["phone"].ToString();
            txtemail.Text = dtp.Rows[0]["email"].ToString();
            txtaddress.Text = dtp.Rows[0]["address"].ToString();
            ddlcode.SelectedIndex = ddlcode.Items.IndexOf(ddlcode.Items.FindByValue(dtp.Rows[0]["centercode"].ToString()));
        }
    }
    #endregion
    #endregion
}