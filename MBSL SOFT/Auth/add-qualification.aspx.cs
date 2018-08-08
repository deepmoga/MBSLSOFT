using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Security.Cryptography;

public partial class Auth_add_qualification : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string imagename = "", img = "", RollNo = "",qid="";
    const string passphrase = "password";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Franchisee"] == null && Session["Admin"] == null && Session["Receptionist"] == null && Session["Red Cross Franchisee"] == null && Session["Red Cross Receptionist"] == null)
        //     Response.Redirect("~/login.aspx");
        if (Session["Franchisee"] != null)
        {
            lblcode.Text = Session["Franchisee"].ToString();
        }
        if (Session["Receptionist"] != null)
        {
            lblcode.Text = Session["Receptionist"].ToString();
        }
        if (Session["Admin"] != null)
        {
            lblcode.Text = Session["Admin"].ToString();
        }
        if (Session["Red Cross Franchisee"] != null)
        {
            lblcode.Text = Session["Red Cross Franchisee"].ToString();
        }
        if (Session["Red Cross Receptionist"] != null)
        {
            lblcode.Text = Session["Red Cross Receptionist"].ToString();
        }
        if (!IsPostBack)
        {
            RollNo = objsql.GetSingleValue("Select rollno from tblstudentdetail where id =" + Cache["id"].ToString()).ToString();
            BindQualification();
        }
    }
    #region Submit button work
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (docimage.HasFile)
        {
            string sliderpic = docimage.FileName;
            imagename = Guid.NewGuid() + "_" + sliderpic;
            string filePath2 = MapPath("../uploadimage/" + imagename);
            Stream Buffer2 = docimage.PostedFile.InputStream;
            System.Drawing.Image Image2 = System.Drawing.Image.FromStream(Buffer2);
            Bitmap bmp2 = ResizeImage(Image2, Image2.Height, Image2.Width);
            bmp2.Save(filePath2, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else
        {
            imagename = img;
        }
        if (ddlCourseType.SelectedItem.Text == "Select Course")
        {
            Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Select the course')</script>");
        }
        else if (qid != "" && qid != null)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        else
        {
            try
            {
                DataSet dtc = new DataSet();
                dtc = objsql.GetDataset("select * from tblqualification where course_type='" + ddlCourseType.SelectedItem.Text + "' and Rollno='" + RollNo + "' and centercode='" + lblcode.Text + "'");
                if (dtc.Tables[0].Rows.Count > 0)
                {
                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Already inserted')</script>");
                }
                else
                {

                    objsql.ExecuteNonQuery("insert into tblqualification(course_type,matric_per,matric_board,matric_batch,matric_document,RollNo,CenterCode) values('" + ddlCourseType.SelectedItem.Text + "','" + txtmarks.Text + "','" + txtboard.Text + "','" + txtbatch.Text + "','" + imagename + "','" + RollNo + "','" + lblcode.Text + "')");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        ddlCourseType.SelectedIndex = 0;
        txtmarks.Text = "";
        txtbatch.Text = "";
        txtboard.Text = "";
        imagename = "";
        qid = "";
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
    public void BindQualification()
    {
        DataSet dtq = new DataSet();
        dtq = objsql.GetDataset("select * from tblqualification where Rollno='" + RollNo + "' and centercode='" + lblcode.Text + "'");
        if (dtq.Tables[0].Rows.Count > 0)
        {
            gridlist.DataSource = dtq;
            gridlist.DataBind();
        }
    }
   
    protected void gridlist_ItemCommand1(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            qid = e.CommandArgument.ToString();
            //EditQualification();
            DataTable dtv = new DataTable();
            dtv = objsql.GetTable("select * from tblqualification where Id='" + e.CommandArgument.ToString() + "'");
            if (dtv.Rows.Count > 0)
            {
                ddlCourseType.SelectedIndex = ddlCourseType.Items.IndexOf(ddlCourseType.Items.FindByText(dtv.Rows[0]["course_type"].ToString()));
                txtmarks.Text = dtv.Rows[0]["matric_per"].ToString();
                txtbatch.Text = dtv.Rows[0]["matric_batch"].ToString();
                txtboard.Text = dtv.Rows[0]["matric_board"].ToString();
                img = dtv.Rows[0]["matric_document"].ToString();
            }
        }
    }
    protected void gridlist_ItemEditing(object sender, ListViewEditEventArgs e)
    {

    }
    protected void btncheck_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblPassword where Password='" + EncryptData(txtname.Value) + "' and Page_name='Document' and Status='1'");
        if (dt.Rows.Count > 0)
        {
            try
            {
                objsql.ExecuteNonQuery("update tblqualification set course_type='" + ddlCourseType.SelectedItem.Text + "',matric_per='" + txtmarks.Text + "',matric_board='" + txtboard.Text + "',matric_batch='" + txtbatch + "',matric_document='" + imagename + "' where RollNo='" + RollNo + "' and CenterCode='" + lblcode.Text + "' ");
            }
            catch (Exception)
            {

                throw;
            }
            
            BindQualification();
        }
        else
        {
            Page.RegisterStartupScript("d", "<script>alert('Wrong Password Please Try Again')</script>");
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
}