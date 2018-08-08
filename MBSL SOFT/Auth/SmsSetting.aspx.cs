using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_SmsSetting : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind();
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblsms set username='" + txtuser.Text + "',senderid='" + txtsender.Text + "',type='" + ddltype.SelectedItem.Text + "',api='" + txtapi.Text + "',alertno='" + txtmob.Text + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblsms(username,senderid,type,api,alertno,status) values ('" + txtuser.Text + "','" + txtsender.Text + "','" + ddltype.SelectedItem.Text + "','" + txtapi.Text + "','" + txtmob.Text + "','1')");
        }
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblsms where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            txtapi.Text = dt.Rows[0]["api"].ToString();
            txtmob.Text = dt.Rows[0]["mob"].ToString();
            txtsender.Text = dt.Rows[0]["senderid"].ToString();
            txtuser.Text = dt.Rows[0]["username"].ToString();
        }
    }
}