using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Transactions;
public partial class Auth_view_student : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string Code = "", i_d = "";
    public static string rollno = "", course = "", time = "",id,b;
    public string listFilter = null;
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
            Response.Redirect("~/Auth/Login.aspx");
        if (!Page.IsPostBack)
        {
         

            if (Session["Franchisee"] != null)
            {
                lblcode.Text = Session["Franchisee"].ToString();
            }
            if (Session["Receptionist"] != null)
            {
                lblcode.Text = Session["Receptionist"].ToString();
            }
            if (Session["Red Cross Franchisee"] != null)
            {
                lblcode.Text = Session["Red Cross Franchisee"].ToString();


            }
            if (Session["Red Cross Receptionist"] != null)
            {
                lblcode.Text = Session["Red Cross Receptionist"].ToString();


            }


            if (Session["Admin"] != null)
            {
               // ddlfranchisee.Visible = true;
                //lblcode.Text = ddlfranchisee.SelectedItem.Value;

            }
            BindData();
   


            
        }
    }
    protected void BindData()
    {

        dt = objsql.GetTable("select * from tblstudentdata where status='1' order by id desc");
        if (dt.Rows.Count > 0)
        {
            //GrdDetail.DataSource = dt;
            //GrdDetail.DataBind();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ListView2.DataSource = dt;
            ListView2.DataBind();
        }
        
        
    }
    protected void GrdDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDetail.PageIndex = e.NewPageIndex;
        BindData();
        GrdDetail.DataBind();
        //listFilter = BindName();
    }
    protected void GrdDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            //string rn = "";
            //DataTable dt1 = new DataTable();
            //dt1 = objsql.GetTable("Select RollNo from StudentDetails where id =" + e.CommandArgument);
            //if (dt1.Rows.Count > 0)
            //{
            //    rn = dt1.Rows[0]["RollNo"].ToString().Replace("''", "'");
            //}
            //int j = objsql.ExecuteNonQuery1("delete from StudentEducationalDetails where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Fees_Master where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Old_Students where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Old_Students where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Result where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Certificates where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Course where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Course_Master where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Fee where RollNo='" + rn + "'");
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

            id = e.CommandArgument.ToString();
           

        }

        if (e.CommandName == "edit")
        {
            //if (Session["Admin"] != null)
            //{
            //    Response.Redirect("Student-Profile.aspx?id=" + e.CommandArgument + "&type=" + ddlfranchisee.SelectedItem.Value);
            //}
            //Response.Redirect("View-Edit-Students.aspx?Id=" + e.CommandArgument);
            Cache.Remove("id");
            Cache["id"] = e.CommandArgument.ToString();
            Response.Redirect("Assign-Course.aspx");
        }
        if (e.CommandArgument == "deactive")
        {
            objsql.ExecuteNonQuery("update tblstudentdata set status='0' where id=" + e.CommandArgument);
        }
        BindData();
    }




    protected void GrdDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldob = (Label)e.Row.FindControl("lbldob");
            #region date conversion
            string date = "";
            string date1 = "";
            string[] alldatevalues = new string[3];
            if (lbldob.Text != "")
            {
                alldatevalues = lbldob.Text.Split("/".ToCharArray());
            }
            if (alldatevalues.Length >= 3)
            {
                //date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
                lbldob.Text = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }
            #endregion
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        using (TransactionScope ts2 = new TransactionScope())
        {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from tblPassword where Password='" + EncryptData(txtname.Value) + "' and Page_name='Student'");
            if (dt.Rows.Count > 0)
            {
                int i, j;
                i = objsql.ExecuteNonQuery1("delete from tblstudentdata where RollNo='" + id + "' and CenterCode='" + lblcode.Text + "'");
               
                if (i > 0)
                {
                    Page.RegisterStartupScript("d", "<script>alert('Record Deleted Successfully!!')</script>");
                }
                else
                {
                    Page.RegisterStartupScript("d", "<script>alert('Record Not Deleted!!')</script>");

                }
               // BindStudentCourse();
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
    protected void GrdDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        
        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            TableHeaderCell cell = new TableHeaderCell();
            TextBox txtSearch = new TextBox();
            txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
            txtSearch.CssClass = "search_textbox";
            cell.Controls.Add(txtSearch);
            row.Controls.Add(cell);
        }
        GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            //string rn = "";
            //DataTable dt1 = new DataTable();
            //dt1 = objsql.GetTable("Select RollNo from StudentDetails where id =" + e.CommandArgument);
            //if (dt1.Rows.Count > 0)
            //{
            //    rn = dt1.Rows[0]["RollNo"].ToString().Replace("''", "'");
            //}
            //int j = objsql.ExecuteNonQuery1("delete from StudentEducationalDetails where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Fees_Master where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Old_Students where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Old_Students where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Result where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Certificates where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Course where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Course_Master where RollNo='" + rn + "'");
            //objsql.ExecuteNonQuery("delete from Student_Fee where RollNo='" + rn + "'");
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);

            id = e.CommandArgument.ToString();


        }

        if (e.CommandName == "edit")
        {
            int n;
            //if (Session["Admin"] != null)
            //{
            //    Response.Redirect("Student-Profile.aspx?id=" + e.CommandArgument + "&type=" + ddlfranchisee.SelectedItem.Value);
            //}
            //Response.Redirect("View-Edit-Students.aspx?Id=" + e.CommandArgument);
            string a = e.CommandArgument.ToString();
            if (a == "")
            {
                b = Common.Get(objsql.GetSingleValue("select max(id) from tblstudentdata where status='1'"));
            }
            else
            {
                b = Common.Get(objsql.GetSingleValue("select max(id) from tblstudentdata where status='1' and id < '" + a + "'"));
            }
        
            n =Convert.ToInt32(b);
            //if (a == "")
            //{
            //    string id = Common.Get(objsql.GetSingleValue("select id from tblstudentdata order by id desc"));
            //    n = Convert.ToInt32(id);
            //}
            //else if (Convert.ToInt32(a) == 1)
            //{
            //    n = 1;
            //}
            //else
            //{
            //    n = Convert.ToInt32(a) - 1;
            //}

            Cache.Remove("id");
            Cache["id"] = n;
            Cache.Remove("roll");
            Cache.Remove("payid");
            Response.Redirect("Assign-Course.aspx");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }
    protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            string a = e.CommandArgument.ToString();
            Cache.Remove("id");
            Cache["id"] = a;
            Cache.Remove("roll");
            Cache.Remove("payid");
            Response.Redirect("Assign-Course.aspx");
        }
        if (e.CommandName == "deactive")
        {
            objsql.ExecuteNonQuery("update tblstudentdata set status='0' where id=" + e.CommandArgument);
        }
        BindData();
    }


    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        int id = int.Parse((sender as LinkButton).CommandArgument);
        objsql.ExecuteNonQuery("delete from tblstudentdata where rollno='" + id + "'");
        objsql.ExecuteNonQuery("delete from student_course where rollno='" + id + "'");
        objsql.ExecuteNonQuery("delete from student_fee where rollno='" + id + "'");
        objsql.ExecuteNonQuery("delete from fees_master where rollno='" + id + "'");
        objsql.ExecuteNonQuery("delete from tblpendingfee where rollno='" + id + "'");
        BindData();

    }
}