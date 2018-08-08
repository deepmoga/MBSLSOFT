using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_print_bill : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string instname = "", phn, ad,rno,amt="",course,roll,date,name,father,address,phone,cfee,cname,rsword,dis="",pen,status="";
    DataTable dt = new DataTable();
    public int pay = 0;
    public double diso = 0.0;
   public static string[] ab = new string[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    detail();
                    ab = Request.QueryString["id"].ToString().Split(new char[] { ',' });

                    rno = ab[0].ToString();
                    amt = ab[1].ToString();
                    course = ab[2].ToString();
                    roll = ab[3].ToString();
                    date = ab[4].ToString();
                    dis = ab[5].ToString();
                    pen = ab[6].ToString();
                    cfee = Common.Get(objsql.GetSingleValue("select totalfees from fees_master where rollno='" + roll + "' and courseid='"+course+"'")).ToString();
                    cname = Common.Get(objsql.GetSingleValue("select coursename from course where courseid='" + course + "'")).ToString();
                    status = ab[7].ToString();
                    if (status == "reprint")
                    {
                        check();
                    }
                    string word = ConvertNumbertoWords(Convert.ToInt32(amt));
                    rsword= word.ToString();

                    //string pendo = (Convert.ToDouble(amt) + Convert.ToDouble(dis)).ToString();
                    //pen = (Convert.ToInt32(cfee) - Convert.ToInt32(pendo)).ToString();
                    
                    DataTable dtt = new DataTable();
                    dtt = objsql.GetTable("select * from tblstudentdata where rollno='" + roll + "'");
                    if (dtt.Rows.Count > 0)
                    {
                        name = dtt.Rows[0]["name"].ToString();
                        father = dtt.Rows[0]["fathername"].ToString();
                        address = dtt.Rows[0]["address"].ToString();
                        phone = dtt.Rows[0]["phone"].ToString();

                    }
                    DataTable dt2 = new DataTable();
                    dt2 = objsql.GetTable("select top(2) * from recipt_details where rollno='" + roll + "' and courseid='" + course + "' and reciptno<'"+rno+"' order by id desc");
                    if (dt2.Rows.Count > 0)
                    {
                        gvinst.DataSource = dt2;
                        gvinst.DataBind();
                        GridView1.DataSource = dt2;
                        GridView1.DataBind();
                    }
                    
                }
            }
        }
    }
    protected void detail()
    {
        dt = objsql.GetTable("select * from tbldetail");
        if (dt.Rows.Count > 0)
        {
            instname = dt.Rows[0]["name"].ToString();
            phn = dt.Rows[0]["phone"].ToString();
            ad = dt.Rows[0]["address"].ToString();
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
    protected void check()
    {
        amt = "0";
        string token = Common.Get(objsql.GetSingleValue("select Tokenno from Recipt_details where reciptno='" + rno + "'"));
        DataTable dt3 = new DataTable();
        dt3 = objsql.GetTable("select * from student_fee where token<='"+token+"' and courseid='"+course+"' and rollno='"+roll+"' order by id asc");
        if (dt3.Rows.Count >= 2)
        {
            foreach(DataRow dr in dt3.Rows)
            {
                pay += Convert.ToInt32(dr["todaypaidfee"]);
                
                diso += Convert.ToDouble(dr["discount"]);
            }
            amt = pay.ToString();
            dis = diso.ToString();
        }
        else
        {
            amt = dt3.Rows[0]["todaypaidfee"].ToString();
            dis = dt3.Rows[0]["discount"].ToString();
        }
    }

    protected void gvinst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label date = (Label)e.Row.FindControl("lbldate");
            date.Text = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label date1 = (Label)e.Row.FindControl("lbldate1");
            date1.Text = Convert.ToDateTime(date1.Text).ToString("dd/MM/yyyy");
        }
    }
}