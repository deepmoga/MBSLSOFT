using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Expense : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string Code = "", id = "", Rep_Name = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtdate.Attributes.Add("readonly", "readonly");
            txtChequeDate.Attributes.Add("readonly", "readonly");
            //txtdate.Text = System.DateTime.Now.AddHours(11).AddMinutes(26).Date.ToString("MM/dd/yyyy");
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                BindDescription();
                // txtdate.Text = System.DateTime.Now.AddHours(11).AddMinutes(26).Date.ToString("MM/dd/yyyy");

            }
        }
        

     
    }

    protected void BindDescription()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * From Expenses_Details where id =" + Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            this.txtexpense.Value = dt.Rows[0]["Expense_Name"].ToString().Replace("''", "'");
            this.txtamount.Value = dt.Rows[0]["Amount"].ToString().Replace("''", "'");
           // txtdate.Text = Convert.ToDateTime(dt.Rows[0]["Date"].ToString().Replace("''", "'")).ToString("dd/MM/yyyy");
            // ddlpayment.SelectedItem.Text = dt.Rows[0]["PaymentType"].ToString().Replace("''", "'");
            ddlpayment.Items.FindByText(dt.Rows[0]["PaymentType"].ToString()).Selected = true;
            // txtChequeDate.Text = Convert.ToDateTime(dt.Rows[0]["ChaqueDate"].ToString().Replace("''", "'")).ToString("dd/MM/yyyy");
            txtChequeNo.Value = dt.Rows[0]["ChequeNo"].ToString().Replace("''", "'");
            txtBranchName.Value = dt.Rows[0]["BranchName"].ToString().Replace("''", "'");
            txtBankName.Value = dt.Rows[0]["BankName"].ToString().Replace("''", "'");
            //ddlStatus.SelectedItem.Text = dt.Rows[0]["Status"].ToString().Replace("''", "'");
            // ddlStatus.Items.FindByText(dt.Rows[0]["Status"].ToString()).Selected = true;
            txtDrftNo.Value = dt.Rows[0]["DraftNo"].ToString().Replace("''", "'");
            txtdate.Text = dt.Rows[0]["date"].ToString();
            if (ddlpayment.SelectedItem.Text == "Cheque")
            {
                pnlCheque.Visible = true;
            }
            if (ddlpayment.SelectedItem.Text == "Draft")
            {
                pnldrft.Visible = true;
            }
        }
    }



    protected void ddlpayment_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlpayment.SelectedItem.Text == "Cash")
        {
            pnlcash.Visible = true;
            pnlCheque.Visible = false;
            pnldrft.Visible = false;
        }
        else if (ddlpayment.SelectedItem.Text == "Cheque")
        {
            pnlCheque.Visible = true;
            pnlcash.Visible = true;
            pnldrft.Visible = false;
        }
        else if (ddlpayment.SelectedItem.Text == "Draft")
        {
            pnlCheque.Visible = false;
            pnlcash.Visible = true;
            pnldrft.Visible = true;
        }
        else
        {
            pnlCheque.Visible = false;

            pnldrft.Visible = false;
        }
    }



    protected void fvSubmit_Click(object sender, EventArgs e)
    {
        #region date conversion
        string date = "";
        string cdate = "";
        string[] alldatevalues = new string[3];
        if (txtdate.Text != "")
        {
            alldatevalues = txtdate.Text.Split("/".ToCharArray());
        }
        if (alldatevalues.Length >= 3)
        {
            date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

        }
        string[] alldatevalues1 = new string[3];
        if (txtChequeDate.Text != "")
        {
            alldatevalues = txtChequeDate.Text.Split("/".ToCharArray());
        }
        if (alldatevalues1.Length >= 3)
        {
            cdate = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

        }


        #endregion

        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {
            if (ddlpayment.SelectedItem.Text == "Cash")
            {
                objsql.ExecuteNonQuery("update Expenses_Details set Date='" + date + "', Expense_Name='" + txtexpense.Value.Replace("'", "''") + "',Amount='" + this.txtamount.Value + "' where  id=" + Request.QueryString["id"]);
            }
            else if (ddlpayment.SelectedItem.Text == "Cheque")
            {
                objsql.ExecuteNonQuery("update Expenses_Details set Date='" + date + "', Expense_Name='" + txtexpense.Value.Replace("'", "''") + "',Amount='" + this.txtamount.Value + "',PaymentType='" + ddlpayment.SelectedItem.Text + "',ChequeNo='" + cdate + "',BankName='" + txtBankName.Value + "',BranchName='" + txtBranchName.Value + "',ChaqueDate='" + cdate + "',Status='" + ddlStatus.SelectedItem.Text + "' where  id=" + Request.QueryString["id"]);
            }
            else if (ddlpayment.SelectedItem.Text == "Draft")
            {
                objsql.ExecuteNonQuery("update Expenses_Details set Date='" + date + "', Expense_Name='" + txtexpense.Value.Replace("'", "''") + "',Amount='" + this.txtamount.Value + "',DraftNo='" + txtDrftNo.Value + "' where  id=" + Request.QueryString["id"]);
            }

        }
        else
        {
            if (ddlpayment.SelectedItem.Text == "Cash")
            {
                int x = objsql.ExecuteNonQuery1("insert into Expenses_Details(Expense_Name,Date,Amount,CenterCode,PaymentType) values( '" + txtexpense.Value + "','" + date + "','" + txtamount.Value + "','" + Session["code"].ToString() + "','" + ddlpayment.SelectedItem.Text + "')");

            }
            else if (ddlpayment.SelectedItem.Text == "Cheque")
            {
                int x = objsql.ExecuteNonQuery1("insert into Expenses_Details(Expense_Name,Date,Amount,CenterCode,PaymentType,ChequeNo,BankName,BranchName,ChaqueDate,Status) values( '" + txtexpense.Value + "','" + date + "','" + txtamount.Value + "','" + Session["code"].ToString() + "','" + ddlpayment.SelectedItem.Text + "','" + txtChequeNo.Value + "','" + txtBankName.Value + "','" + txtBranchName.Value + "','" + cdate + "','" + ddlStatus.SelectedItem.Text + "')");

            }
            else if (ddlpayment.SelectedItem.Text == "Draft")
            {
                int x = objsql.ExecuteNonQuery1("insert into Expenses_Details(Expense_Name,Date,Amount,CenterCode,PaymentType,DraftNo) values( '" + txtexpense.Value + "','" + date + "','" + txtamount.Value + "','" + Session["code"].ToString() + "','" + ddlpayment.SelectedItem.Text + "','" + txtDrftNo.Value + "')");

            }


        }

        Response.Redirect("Expense-List.aspx");
    }
}