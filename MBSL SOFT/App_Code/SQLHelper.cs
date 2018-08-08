using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using System.Web;

public class SQLHelper
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;

        #region Constructor
        public SQLHelper()
        {
            string constr = System.Configuration.ConfigurationSettings.AppSettings ["ConnectionString"];
            con = new SqlConnection(constr);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }

        public SQLHelper(string ConStr)
        {
            con = new SqlConnection(ConStr);
            com = new SqlCommand();
            com.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = com;
        }
        #endregion

        #region GetDataset
        public DataSet GetDataset(string qry)
        {
            com.CommandText = qry;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet GetDataset(SqlCommand com)
        {
            com.Connection = this.con;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        #endregion
        
        #region GetTable
        public DataTable GetTable(string qry)
        {
           // try
          //  {
                com.CommandText = qry;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
          //  }
          //  catch(Exception ex)
          //  {
          //      System.Web.HttpContext.Current.Response.Write(qry);

         //       System.Web.HttpContext.Current.Response.End();
          //      return new DataTable ();

          //  }
        }
        public DataTable GetTable(SqlCommand com)
        {
            com.Connection = this.con;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region GetSingleValue
        public object GetSingleValue(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
            return obj;
        }
        public object GetSingleValue(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            object obj = com.ExecuteScalar();
            con.Close();
            return obj;
        }
        #endregion

        #region ExecuteNonQuery
        public void ExecuteNonQuery(string qry)
        {
            //try
            //{
            con.Close();
                com.CommandText = qry;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
           // }
           // catch (Exception ex)
           // {
            //    System.Web.HttpContext.Current.Response.Write(qry);
           //     System.Web.HttpContext.Current.Response.End();

          //  }
        }

        public int ExecuteNonQuery1(string qry)
        {
            con.Close();
            com.CommandText = qry;
            con.Open();
          return  com.ExecuteNonQuery();
           
           
        }
        public void ExecuteNonQuery(SqlCommand com)
        {
            com.Connection = this.con;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    #endregion
    public string SendSMS(string User, string sender, string to, string message, string type, string api)
    {
        string stringpost = "username=" + User + "&message=" + message + "&sendername=" + sender + "&smstype=" + type + "&numbers=" + to + "&apikey=" + api + "";
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

            objWebRequest = (HttpWebRequest)WebRequest.Create("http://sms.officialsms.in/sendSMS");
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
    public string uploadfile(FileUpload file)
    { 
        if (file.HasFile)
        {
            string fileName1 = file.FileName;
            string StdPic = "Student" + "_" + Common.GenerateClassCode() + "_" + fileName1;
            string filePath2 = HttpContext.Current.Server.MapPath("../uploadimage/" + StdPic);
            return StdPic;
        }
        else
        {
            return "NoImage";
        }
    }

}
