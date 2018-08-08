using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SQLHelper objsql=new SQLHelper ();
    protected void Page_Load(object sender, EventArgs e)
    {
    Response.Redirect("Auth/login.aspx");
        if (!IsPostBack)
        {
       
        }
    }

}