using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_StudentReport : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
     public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void BtnLoadReport_Click(object sender, EventArgs e)
    {
        string fromdate = "";
        string todate = "";
        string[] alldatevalues = new string[3];

        if (txtFromDate.Text != "")
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

        dt = objsql.GetTable("select r.date,r.rollno,s.name,r.particular,r.reciptno,r.amount  from Recipt_details r , tblstudentdata s where r.rollno=s.rollno and convert(datetime, r.[Date], 120) >= " +
                                  "convert(datetime, '" + fromdate + "', 120) and convert(datetime, r.[Date], 120) <= " +
                                  "convert(datetime, '" + todate + "', 120)");
        if (dt.Rows.Count > 0)
        {
            gridPaymentinfo.DataSource = dt;
            gridPaymentinfo.DataBind();
        }
    }

}