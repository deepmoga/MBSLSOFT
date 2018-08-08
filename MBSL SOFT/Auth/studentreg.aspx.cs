using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data;
using System.Web.Services;
using System.Transactions;
using System.Globalization;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net;
public partial class Auth_studentreg : System.Web.UI.Page
{
    public static string img = "";
    public static string sex = "", sid = "", doj="",centercode = "", fuid = "", RN = "",type="", Reciptnumber = "", Token = "", formatdate="", dob="", board="", strname="",uid="",alertdate="";
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Session["code"] != null)
            {


                txtrollno.Text= GenerateLeadNo();
                txtdate.Attributes.Add("readonly", "readonly");
                txtdob.Attributes.Add("readonly", "readonly");


                txtdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                binddata();
                uid = Session["code"].ToString();
            }
            else { Response.Redirect("login.aspx"); }
        }

        
    }
    protected string GenerateLeadNo()
    {
        string LeadNo = "0";
        string id = objsql.GetSingleValue("select max(id) from tblstudentdata").ToString();
        if (id == "")
        {
            return "1";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select rollno from tblstudentdata where id=" + id).ToString();

            LeadNo = (Convert.ToInt32(LeadNo) + Convert.ToInt32(1)).ToString();

            return LeadNo.ToString();
        }



    }

    private static Bitmap ResizeImage(System.Drawing.Image imgPhoto, int Height, int Width)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)Math.Ceiling(sourceWidth * nPercent);
        int destHeight = (int)Math.Ceiling(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, imgPhoto.PixelFormat);

        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);

        grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        grPhoto.SmoothingMode = SmoothingMode.HighQuality;
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        grPhoto.DrawImage(imgPhoto, rect, new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);


        grPhoto.Dispose();
        return bmPhoto;
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
       
            try
            {
                strname = "";
                changedate();
                if (fileupload.HasFile)
                {
                    strname = fileupload.FileName.ToString();

                    fileupload.PostedFile.SaveAs(Server.MapPath("~/uploadimage/") + strname);
                }
                if (txtother.Text != "")
                {
                    board = txtother.Text;
                }
                if (CheckBoxList1.SelectedIndex >= 0)
                {
                    board = CheckBoxList1.SelectedItem.Text;
                }
                if (CheckBoxList2.SelectedIndex > 0)
                {
                    type = CheckBoxList2.SelectedItem.Text;
                }

                string commom = Common.Get(objsql.GetSingleValue("select rollno from tblstudentdata where rollno='"+txtrollno.Text+"'"));
                if (commom == "")
                {
                    string enpass = EncryptData(txtpass.Text);
                    help.ExecuteNonQuery("insert into tblstudentdata (date,rollno,name,dob,fathername,address,phone,fatherphn,language,board,qualification,coaching,institutename,type,refferedby,image,uid,status,username,password,gender,remarks,email,discount) values ('" + formatdate + "','" + txtrollno.Text + "','" + txtname.Text + "','" + dob + "','" + txtfather.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "','" + txtfphn.Text + "','" + txttounge.Text + "','" + board + "','" + txtquali.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtinst.Text + "','" + type + "','" + txtrefer.Text + "','" + strname + "','" + uid + "','1','" + txtusername.Text + "','" + enpass + "','"+rdogender.SelectedItem.Text+"','"+txtremarks.Text+"','"+txtemail.Text+"','"+txtdiscount.Text+"')");
                    objsql.ExecuteNonQuery("insert into tblpendingfee (rollno,courseid,tokenno,fees,alertdate,status,fromdate,todate) values ('" + txtrollno.Text + "','" + ddlcourse.SelectedItem.Value + "','" + Token + "','" + txtFee.Text + "','" + doj + "','1','" + doj + "','" + datechange(txtenddate.Text) + "')");


                string message = "ThankYou For Registered. " + txtname.Text + " and Your Username is :" + txtusername.Text + " and Password is : " + txtpass.Text + ". Login in http:/www.englishtreemoga.com";
                //   SendSMS("", "ENGTRE", txtphone.Text, message);

                #region check course assign
                using (TransactionScope ts2 = new TransactionScope())
                {
                    if (ddlcourse.SelectedIndex != 0)
                    {
                        if (txtdoj.Text != "")
                        {
                            //  alertdate = Convert.ToDateTime(txtdoj.Text).AddDays(30).ToString();
                            help.ExecuteNonQuery("insert into Fees_Master(RollNo,CourseId,TotalFees,PaidFees,Date,AlertDate,CenterCode,pending_Fees,noofinstalment,instalmentamount,discount,Status,discountstatus) values('" + txtrollno.Text + "','" + ddlcourse.SelectedItem.Value + "','" + txtFee.Text + "',0,'" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + doj + "','" + Session["code"] + "','" + txtFee.Text + "','','','0','1','0')");

                            help.ExecuteNonQuery("insert into Student_Fee(RollNo,CourseId,CenterCode,TotalFees,TotalPaidFees,FromDate,ToDate,Date,TodayPaidFee,Pending_Fees,noofinstalment,instalmentamount,discount) values('" + txtrollno.Text + "','" + ddlcourse.SelectedItem.Value + "','" + Session["code"] + "','" + txtFee.Text + "',0,'" + doj + "','" + doj + "','" + DateTime.Now.ToShortDateString() + "',0,0,'','','0')");

                            SqlParameter[] Param2 =
                                {
                    new SqlParameter("@RollNo",txtrollno.Text),
                    new SqlParameter("@CourseId",ddlcourse.SelectedItem.Value),
                    new SqlParameter("@CourseName",ddlcourse.SelectedItem.Text),
                    new SqlParameter("@Time",ddltime.SelectedItem.Value),
                    new SqlParameter("@Status","1"),
                    new SqlParameter("@Admitdate",doj),
                    new SqlParameter("@Startdate","."),
                    new SqlParameter("@Fees",txtFee.Text),
                    new SqlParameter("@Uid",Session["code"].ToString()),
                    new SqlParameter("@roomid",ddlroom.SelectedItem.Value),
                    new SqlParameter("@enddate",datechange(txtenddate.Text))
                                 };
                            help.ExecuteNonQueryByProc("InsertStudentCourse", Param2);

                        }
                    }
                    ts2.Complete();
                }
                #endregion
                Page.RegisterStartupScript("a", "<script>alert('Sucessfully Register')</script>");
                    string id = Common.Get(objsql.GetSingleValue("select id from tblstudentdata where rollno='" + txtrollno.Text + "'"));
                    Cache.Remove("id");
                    Cache["id"] = id.ToString();

                    Response.Redirect("deposit-fee.aspx");
                }
                else
                {
                    Page.RegisterStartupScript("a", "<script>alert('RollNo Already Assigned To Other Student')</script>");
                }


            }
               
            catch (Exception ss)
            {
              //  ts2.Dispose();
                string msz = ss.Message.ToString();
                Page.RegisterStartupScript("a", "<script>alert('Error Occur " + msz + "')</script>");

            }

       // }
            
            clear();
           
           
        
  }
  

    protected void btn2_Click(object sender, EventArgs e)
    {

        clear();

    }

    protected void clear()
    {
        txtrollno.Text = "";
        txtoldrollno.Text = "";
        txtname.Text = "";
        txtdob.Text = "";
        txtfather.Text = "";
       
        txtaddress.Text = "";
   
        //txtoldrollno.Text = txtrollno.Text = GenerateLeadNo();
    }

    

    

    protected void changedate()
    {
        #region change date format
        DateTime date = new DateTime();
        DateTime date2 = new DateTime();
        date = DateTime.ParseExact(txtdate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        formatdate = date.ToString("MM/dd/yyyy");
        if (txtdob.Text != "")
        {
            
            date2 = DateTime.ParseExact(txtdob.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dob = date2.ToString("MM/dd/yyyy");
        }

        if (txtdoj.Text != "")
        {
            date2 = DateTime.ParseExact(txtdoj.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            doj = date2.ToString("MM/dd/yyyy");
        }
        #endregion
    }
    protected void binddata()
    {
        help.BindDropDownList("select * from course", "CourseName", "CourseId", ddlcourse);
        help.BindDropDownList("select * from Batch_Timming", "Time", "Id", ddltime);
        help.BindDropDownList("select * from tblroom", "room", "id", ddlroom);
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFee.Text = objsql.GetSingleValue("select Fees from course where CourseId='" + ddlcourse.SelectedItem.Value + "'").ToString();
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
    public string SendSMS(string User, string sender, string to, string message)
    {
        string stringpost = "username=Englishtree&message="+message+"&sendername="+sender+"&smstype=TRANS&numbers="+to+"&apikey=fdb71918-21d9-46bd-8013-b1f0b09b7a43";
        //Response.Write(stringpost)
        string functionReturnValue = null;
        functionReturnValue = "";

        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;

        try
        {
            string stringResult = null;

            objWebRequest = (HttpWebRequest)WebRequest.Create("http://sms.officialsolutions.in/sendSMS");
            //domain name: Domain name Replace With Your Domain  
            objWebRequest.Method = "Post";

            // Response.Write(objWebRequest)

            // Use below code if you want to SETUP PROXY.
            //Parameters to pass: 1. ProxyAddress 2. Port
            //You can find both the parameters in Connection settings of your internet explorer.


            // If You are In the proxy Then You Uncomment the below lines and Enter IP And Port Number


            //System.Net.WebProxy myProxy = new System.Net.WebProxy("192.168.1.108", 6666);
            //myProxy.BypassProxyOnLocal = true;
            //objWebRequest.Proxy = myProxy;

            objWebRequest.ContentType = "application/x-www-form-urlencoded";

            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();

            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();


            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.ToString());

        }
        finally
        {
            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;

        }
    }
    public string datechange(string date)
    {
        string newdate= "";
        if (date != "")
        {
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);
             newdate = myDateTime.ToString("MM/dd/yyyy"); // add myString_new to oracle
           
        }
        return newdate;

    }

}