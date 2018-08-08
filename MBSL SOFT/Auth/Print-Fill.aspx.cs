using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Print_Fill : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public string name = "", date = "", pass = "", dob = "", doe = "", c1 = "", c2 = "", c3 = "", module = "", v1 = "", v2 = "", v3 = "", mode = "", inst = "", status = "",mob="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from tblfill where fid='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            name = dt.Rows[0]["name"].ToString();
            date= dt.Rows[0]["date"].ToString();
            dob = dt.Rows[0]["dob"].ToString();
            pass = dt.Rows[0]["passport"].ToString();
            doe = dt.Rows[0]["doe"].ToString();
            c1 = dt.Rows[0]["choice1"].ToString();
            c2 = dt.Rows[0]["choice2"].ToString();
            c3 = dt.Rows[0]["choice3"].ToString();
            module = dt.Rows[0]["module"].ToString();
            mob = dt.Rows[0]["mobile"].ToString();
            v1 = dt.Rows[0]["v1"].ToString();
            v2 = dt.Rows[0]["v2"].ToString();
            v3 = dt.Rows[0]["v3"].ToString();
            mode = dt.Rows[0]["mode"].ToString();
            inst = dt.Rows[0]["instname"].ToString();
            status= dt.Rows[0]["status"].ToString();
            

        }
    }
   
}