using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Net;
using System.Web.UI.HtmlControls;

public partial class Auth_student_Profile : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    const string passphrase = "password";

    public static string name = "", rn = "", a="",Orn = "", adm = "", dob = "", fn = "", mn = "", sex = "", ph = "", aph = "", email = "", refby = "", cat = "", type = "", min = "", max = "", adrs = "", Hp = "", StdPic = "", S_Pic="",img="",pass="";
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            help.BindDropDownList("select * from tblroom", "room", "id", ddlroom);
            
            if (Cache["id"] != null && Cache["id"] != "")
            {
                BindDescription();
            }
            
        }
      //  string activate = Common.Get(objsql.GetSingleValue("select Activate from tblstudentdata where id='" + Cache["id"] + "'"));
        //if (activate == "True")
        //{
        //    btndeactive.Visible = true;
        //    btnactive.Visible = false;
        //}
        //else
        //{
        //    btnactive.Visible = true;
        //    btndeactive.Visible = false;
        //}
    } 
    #endregion

    #region Bind Detail
    protected void BindDescription()
    {
        if (Cache["id"] != null && Cache["id"] != "")
        {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("Select * from tblstudentdata where id =" + Cache["id"].ToString());
            //   dt = objsql.GetTable("Select * from tblstudentdata where Id =" + s_id);
            if (dt.Rows.Count > 0)
            {
                txtRollNo.Text = dt.Rows[0]["rollno"].ToString().Replace("''", "'");
                rn = dt.Rows[0]["rollno"].ToString().Replace("''", "'");
                #region date conversion
                string[] alldatevalues = new string[3];
                if (dt.Rows[0]["date"].ToString() != "")
                {
                    alldatevalues = dt.Rows[0]["date"].ToString().Split("/".ToCharArray());
                    if (alldatevalues.Length >= 3)
                    {
                        //date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
                        adm = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

                    }
                }

                string[] alldatevalues1 = new string[3];
                if (dt.Rows[0]["dob"].ToString() != "")
                {
                    alldatevalues1 = dt.Rows[0]["dob"].ToString().Split("/".ToCharArray());
                    if (alldatevalues1.Length >= 3)
                    {
                        if (Convert.ToInt32(alldatevalues1[0]) > 12)
                        {
                            dob = alldatevalues1[0].Trim() + "/" + alldatevalues1[1].Trim() + "/" + alldatevalues1[2].Trim();
                        }
                        else
                        {
                            dob = alldatevalues1[1].Trim() + "/" + alldatevalues1[0].Trim() + "/" + alldatevalues1[2].Trim();

                        }


                    }

                }
               

                #endregion
                name = dt.Rows[0]["name"].ToString().Replace("''", "'");
                txtName.Text = dt.Rows[0]["name"].ToString().Replace("''", "'");
               
                if (dob != "")
                {
                    txtDOB.Text = dob;
                }
                fn = dt.Rows[0]["fathername"].ToString().Replace("''", "'");
                txtFthrName.Text = dt.Rows[0]["fathername"].ToString().Replace("''", "'");
               // mn = dt.Rows[0]["mname"].ToString().Replace("''", "'");
               // txtMothrName.Text = dt.Rows[0]["mname"].ToString().Replace("''", "'");
                adrs = dt.Rows[0]["address"].ToString().Replace("''", "'");
                txtaddress.Text = dt.Rows[0]["address"].ToString().Replace("''", "'");
                txtphn.Text=dt.Rows[0]["phone"].ToString().Replace("''", "'");
                txtfphn.Text = dt.Rows[0]["fatherphn"].ToString().Replace("''", "'");
                txtlang.Text = dt.Rows[0]["language"].ToString().Replace("''", "'");
                txtquali.Text = dt.Rows[0]["qualification"].ToString().Replace("''", "'");
                txtinst.Text = dt.Rows[0]["institutename"].ToString().Replace("''", "'");
                txtreff.Text = dt.Rows[0]["refferedby"].ToString().Replace("''", "'");
                img = dt.Rows[0]["image"].ToString().Replace("''", "'");
                ImgPrv.ImageUrl = "../uploadimage/" + img + "";
                txtuser.Text = dt.Rows[0]["username"].ToString().Replace("''", "'");
                pass = dt.Rows[0]["password"].ToString().Replace("''", "'");
                if ( pass != "")
                {
                    txtpassword.Text = DecryptData(dt.Rows[0]["password"].ToString().Replace("''", "'"));
                }
                
                //string room= Common.Get(objsql.GetSingleValue("select roomid from student_course where rollno='" + txtRollNo.Text + "'"));
                //if (room != null)
                //{
                //    ddlroom.Items.FindByValue(room).Selected = true;
                //}

                string Active= dt.Rows[0]["status"].ToString().Replace("''", "'");
                if (Active == "True")
                {
                    btnactive.Visible = false;
                    btndeactive.Visible = true;

                }
                else
                {
                    btnactive.Visible = true;
                    btndeactive.Visible = false;
                }
            }
        }
        //rn = objsql.GetSingleValue("Select RollNo from tblstudentdata where CenterCode='" + lblcode.Text + "' and Id =" + Cache["id"].ToString()).ToString();
        //RollNo = objsql.GetSingleValue("Select RollNo from tblstudentdata where CenterCode='" + lblcode.Text + "' and Id =" + Cache["id"].ToString()).ToString();

        //dt1 = objsql.GetTable("Select * from tblqualification where CenterCode='" + lblcode.Text + "' and RollNo='" + rn + "'");
        //if (dt1.Rows.Count > 0)
        //{
        //    txtMatricPercntage10.Text = dt1.Rows[0]["matric_per"].ToString().Replace("''", "'");
        //    txtBoarduni10.Text = dt1.Rows[0]["matric_board"].ToString().Replace("''", "'");
        //    txtBatch10.Text = dt1.Rows[0]["matric_batch"].ToString().Replace("''", "'");

        //    txtCourseUG.Text = dt1.Rows[0]["underg_course"].ToString().Replace("''", "'");
        //    txtPercntageUG.Text = dt1.Rows[0]["underg_per"].ToString().Replace("''", "'");
        //    txtBoarduniUG.Text = dt1.Rows[0]["underg_board"].ToString().Replace("''", "'");
        //    txtBatchUG.Text = dt1.Rows[0]["underg_batch"].ToString().Replace("''", "'");


        //    txtVocnlCourse.Text = dt1.Rows[0]["voc_course"].ToString().Replace("''", "'");
        //    txtVocParcentage.Text = dt1.Rows[0]["voc_per"].ToString().Replace("''", "'");
        //    txtVocBoardUni.Text = dt1.Rows[0]["voc_board"].ToString().Replace("''", "'");
        //    TxtVocBatch.Text = dt1.Rows[0]["voc_batch"].ToString().Replace("''", "'");

        //    txtGradPercntage.Text = dt1.Rows[0]["grad_course"].ToString().Replace("''", "'");
        //    txtGradCourse.Text = dt1.Rows[0]["grad_per"].ToString().Replace("''", "'");
        //    txtGradBoardUni.Text = dt1.Rows[0]["grad_board"].ToString().Replace("''", "'");
        //    txtGradBatch.Text = dt1.Rows[0]["grad_batch"].ToString().Replace("''", "'");

        //    txtPGPercntage.Text = dt1.Rows[0]["postgrad_course"].ToString().Replace("''", "'");
        //    txtPGCourse.Text = dt1.Rows[0]["postgrad_per"].ToString().Replace("''", "'");
        //    txtPGBoardUni.Text = dt1.Rows[0]["postgrad_board"].ToString().Replace("''", "'");
        //    txtPGBatch.Text = dt1.Rows[0]["postgrad_batch"].ToString().Replace("''", "'");


        //    doc10 = dt1.Rows[0]["matric_document"].ToString().Replace("''", "'");
        //    docUG = dt1.Rows[0]["underg_document"].ToString().Replace("''", "'");
        //    docVC = dt1.Rows[0]["voc_document"].ToString().Replace("''", "'");
        //    docG = dt1.Rows[0]["grad_document"].ToString().Replace("''", "'");
        //    docPG = dt1.Rows[0]["postgrad_document"].ToString().Replace("''", "'");
        //    if (doc10 == null || doc10 == "")
        //    {

        //        doc10 = "No Image.jpg";
        //    }
        //    if (docUG == null || docUG == "")
        //    {
        //        docUG = "No Image.jpg";
        //    }

        //    if (docVC == null || docVC == "")
        //    {
        //        docVC = "No Image.jpg";
        //    }

        //    if (docG == null || docG == "")
        //    {
        //        docG = "No Image.jpg";
        //    }

        //    if (docPG == null || docPG == "")
        //    {
        //        docPG = "No Image.jpg";
        //    }

        //}

    } 
    #endregion

    #region Save button code
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //string strpassword = EncryptData(txtPassword.Text);

        #region date conversion
        string date = "";
        string date1 = "";
        string[] alldatevalues = new string[3];
        string[] alldatevalues1 = new string[3];
        if (txtDOB.Text != null)
        {
            alldatevalues = txtDOB.Text.Split("/".ToCharArray());
            if (alldatevalues.Length >= 3)
            {
                date = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();

            }
        }
        

       
        #endregion
        //if (ddlCategory.SelectedIndex == 0)
        //{
        //    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Please Select Category')</script>");
        //}
        //else if (DdlSex.SelectedIndex == 0)
        //{
        //    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Please Select Sex')</script>");
        //}
        //else
        //{
        if (FileStudentPic.HasFile)
        {
            string fileName1 = FileStudentPic.FileName;
            StdPic = "Student" + "_" + Common.GenerateClassCode() + "_" + fileName1;
            string filePath2 = MapPath("../uploadimage/" + StdPic);
            Stream Buffer2 = FileStudentPic.PostedFile.InputStream;
            System.Drawing.Image Image = System.Drawing.Image.FromStream(Buffer2);
            Bitmap bmp2 = ResizeImage(Image, Image.Height, Image.Width);
            bmp2.Save(filePath2, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else
        {
            StdPic = S_Pic;
        }
        string message = "ThankYou For Registered. " + txtName.Text + " and Your Username is :" + txtuser.Text + " and Password is : " + txtpassword.Text + ". Login in http:/www.englishtreemoga.com";
        if (pass == "" || pass == null)
        {
           // SendSMS("", "ENGTRE", txtphn.Text, message);
        }
        string enpass = EncryptData(txtpassword.Text);
        objsql.ExecuteNonQuery1("update tblstudentdata SET Name='" + txtName.Text + "',fathername='" + txtFthrName.Text + "',dob='" + txtDOB.Text + "',Address='" + txtaddress.Text + "',phone='" + txtphn.Text + "',fatherphn='" + txtfphn.Text + "',language='" + txtlang.Text + "' ,qualification='" + txtquali.Text + "',institutename='" + txtinst.Text + "',refferedby='" + txtreff.Text + "',image='" + StdPic + "',username='"+txtuser.Text+"',password='"+enpass+"' where Id= " + Cache["id"].ToString());
        objsql.ExecuteNonQuery("update student_course set roomid='" + ddlroom.SelectedItem.Value + "' where rollno='" + txtRollNo.Text + "'");
        
        
        // }
        BindDescription();
        txtName.Enabled = false;
        txtDOB.Enabled = false;
        txtFthrName.Enabled = false;
        txtaddress.Enabled = false;
        txtphn.Enabled = false;
        txtfphn.Enabled = false;
        txtlang.Enabled = false;
        txtinst.Enabled = false;
        txtquali.Enabled = false;
        txtreff.Enabled = false;
        txtuser.Enabled = false;
        txtpassword.Enabled = false;
        btnSave.Visible = false;
        btnCancelProfile.Visible = false;
        btnEdit.Visible = true;
        FileStudentPic.Visible = false;
        ddlroom.Enabled = false;
    } 
    #endregion

    #region Resize Image
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
    #endregion

    #region Edit button code
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtName.Enabled = true;
        txtDOB.Enabled = true;
        txtFthrName.Enabled = true;
        txtaddress.Enabled = true;
        txtphn.Enabled = true;
        txtfphn.Enabled = true;
        txtlang.Enabled = true;
        ddlroom.Enabled = true;
        txtinst.Enabled = true;
        txtquali.Enabled = true;
        txtreff.Enabled = true;
        txtuser.Enabled = true;
        txtpassword.Enabled = true;
        btnSave.Visible = true;
        FileStudentPic.Visible = true;
        btnCancelProfile.Visible = true;
        FileStudentPic.Visible = true;
    } 
    #endregion

    #region Active button click
    protected void btnactive_Click(object sender, EventArgs e)
    {
        
        objsql.ExecuteNonQuery("update tblstudentdata set status='1' where Id= " + Cache["id"].ToString());
       
        (this.Master as Auth_profile).ShowMessage("Activate Student Sucessfully", Auth_profile.MessageType.Success);
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "5;url=view-student.aspx";
        this.Page.Controls.Add(meta);
      
        
    } 
    #endregion

    #region Deactive button click
    protected void btndeactive_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update tblstudentdata set status='0' where Id= " + Cache["id"].ToString());

        (this.Master as Auth_profile).ShowMessage("Deactivate Student Sucessfully", Auth_profile.MessageType.Success);
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "5;url=view-student.aspx";
        this.Page.Controls.Add(meta);
    } 
    #endregion

    #region Cancel button code
    protected void btnCancelProfile_Click(object sender, EventArgs e)
    {
        BindDescription();
        txtName.Enabled = false;
        txtDOB.Enabled = false;
        txtFthrName.Enabled = false;
        txtaddress.Enabled = false;
        txtphn.Enabled = false;
        txtfphn.Enabled = false;
        txtlang.Enabled = false;
        txtinst.Enabled = false;
        txtquali.Enabled = false;
        txtreff.Enabled = false;
        ddlroom.Enabled = false;

        btnSave.Visible = false;
        btnCancelProfile.Visible = false;
        btnEdit.Visible = true;
        FileStudentPic.Visible = false;
        
    }
    #endregion

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
    public static string DecryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return UTF8.GetString(Results);
    }
    public string SendSMS(string User, string sender, string to, string message)
    {
        string stringpost = "username=Englishtree&message=" + message + "&sendername=" + sender + "&smstype=TRANS&numbers=" + to + "&apikey=fdb71918-21d9-46bd-8013-b1f0b09b7a43";
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
}