using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class Auth_Result : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("Login.aspx");
        if (!IsPostBack)
        {
            if (Session["Franchisee"] != null)
            {
                lblcode.Text = Session["Franchisee"].ToString();
            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();
            }
            if (Session["Admin"] != null)
            {
                lblcode.Text = Session["Admin"].ToString();
            }
            bindresult();
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
            string path = "", course = "";
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Common.GenerateClassCode() + "_" + Path.GetFileName(FileUpload1.FileName);
                    path = "../excel/" + filename;
                    FileUpload1.SaveAs(Server.MapPath("~/excel/") + filename);
                    //StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            DataSet ds = new DataSet();

            OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();

          //  string excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(path) + ";Extended Properties=Excel 12.0;";
            string excelConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(path) + ";Extended Properties=Excel 12.0;";

            OleDbConnection excelConn = new OleDbConnection(excelConnStr);

            excelConn.Open();

            DataTable dtPatterns = new DataTable();
            excelCommand = new OleDbCommand("select * from [sheet1$]", excelConn);

            excelDataAdapter.SelectCommand = excelCommand;

            excelDataAdapter.Fill(dtPatterns);



            ds.Tables.Add(dtPatterns);
            //Grd.DataSource = dtPatterns;
            //Grd.DataBind();

            foreach (DataRow dr in dtPatterns.Rows)
            {

                objsql.ExecuteNonQuery("insert into Result values('" + dr[0] + "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" + dr[7].ToString().Trim().Replace("12:00:00 AM", "") + "','" + dr[8] + "','" + dr[9] + "','" + dr[10] + "','" + dr[11] + "','" + dr[12] + "')");
                if (course != dr[1].ToString())
                {

                    objsql.ExecuteNonQuery("insert into Student_Certificates(RollNo,CenterCode,Status,CourseId) values('" + dr[1] + "','" + dr[12] + "','1','" + dr[2] + "')");

                    objsql.ExecuteNonQuery("insert into Student_Certificates_fvDetail(RollNo,CenterCode,Status,CourseId) values('" + dr[1] + "','" + dr[12] + "','1','" + dr[2] + "')");
                }

                course = dr[1].ToString();
            }
            bindresult();
        }
    protected void bindresult()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("  select distinct c.RollNo,s.name,s.fname,c.CourseId,r.Place  from Student_Certificates c , tblstudentdetail s,Result r where c.RollNo=s.rollno");
        if (dt.Rows.Count > 0)
        {
            GrdDetail.DataSource = dt;
            GrdDetail.DataBind();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string filePath = "../excel/A0Q7T8Z6J8T6_demoresult.xlsx";
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
}
