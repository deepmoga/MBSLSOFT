using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_Fill_Test : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public string passport, ackno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind();
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string id = Guid.NewGuid().GetHashCode().ToString();
        string fid = id.Substring(1, 4);
        if (Request.QueryString["id"] != null)
        {
            string ac = fackn != null ? objsql.uploadfile(fackn) : ackno;
            string pas = fpass != null ? objsql.uploadfile(fpass) : passport;
            objsql.ExecuteNonQuery("update tblfill set name='" + txtname.Text + "',date='" + txtdate.Text + "',dob='" + txtdob.Text + "',passport='" + txtpassport.Text + "',doe='" + txtdoe.Text + "',choice1='" + txtd1.Text + "',module='" + CheckBoxList2.SelectedItem.Text + "',v1='" + txtv1.Text + "',v2='',mode='" + txtmode.Text + "',instname='" + txtinst.Text + "',status='" + rdomode.SelectedItem.Text + "',uname='"+txtuname.Text+"',pass='"+txtpass.Text+"',mobile='"+txtmob.Text+"',city='"+txtcity.Text+"',passportimg='"+pas+"',ackno='"+ac+"' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblfill(name,date,dob,passport,doe,choice1,choice2,choice3,module,v1,v2,v3,mode,instname,status,fid,uname,pass,mobile,city,passportimg,ackno) values ('" + txtname.Text + "','"+txtdate.Text+"','" + txtdob.Text + "','" + txtpassport.Text + "','" + txtdoe.Text + "','" + txtd1.Text + "','','','" + CheckBoxList2.SelectedItem.Text + "','" + txtv1.Text + "','','','" + txtmode.Text + "','" + txtinst.Text + "','"+rdomode.SelectedItem.Text+"','"+fid+"','"+txtuname.Text+"','"+txtpass.Text+"','"+txtmob.Text+"','"+txtcity.Text+"','"+objsql.uploadfile(fpass)+"','"+objsql.uploadfile(fackn)+"')");
            Response.Write("<script>window.open('Print-fill.aspx?id="+fid+"','_blank');</script>");
        }
        Response.Redirect("view-fill.aspx");
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from tblfill where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtdate.Text = dt.Rows[0]["date"].ToString();
            txtdob.Text = dt.Rows[0]["dob"].ToString();
            txtpassport.Text = dt.Rows[0]["passport"].ToString();
            txtdoe.Text = dt.Rows[0]["doe"].ToString();
            txtd1.Text = dt.Rows[0]["choice1"].ToString();
          
            string module = dt.Rows[0]["module"].ToString();
            CheckBoxList2.Items.FindByText(module).Selected = true;
            txtv1.Text = dt.Rows[0]["v1"].ToString();
            txtuname.Text = dt.Rows[0]["uname"].ToString();
            txtpass.Text = dt.Rows[0]["pass"].ToString();
            txtmode.Text = dt.Rows[0]["mode"].ToString();
            txtinst.Text = dt.Rows[0]["instname"].ToString();
           string status = dt.Rows[0]["status"].ToString();
           rdomode.Items.FindByText(status).Selected = true;
            txtcity.Text= dt.Rows[0]["city"].ToString();
            txtmob.Text= dt.Rows[0]["mobile"].ToString();
            passport= dt.Rows[0]["passportimg"].ToString();
            ackno= dt.Rows[0]["ackno"].ToString();


        }
    }
    protected void CheckBoxList2_TextChanged(object sender, EventArgs e)
    {
        if (CheckBoxList2.SelectedItem.Text == "PTE")
        {
            txtuname.Enabled = true;
            txtpass.Enabled = true;
        }
        else
        {
            txtuname.Enabled = false;
            txtpass.Enabled = false;

        }
    }
    
}