using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Data;
using System.Collections;

public class Common
{
    #region [ Get DB Values ]

    // Get String Value

    #region [ Get(object obj) & Get(object obj,int maxchars) ]
    public static string Get(object obj)
    {
        if (obj == System.DBNull.Value || obj == null)
            return "";
        else
            return obj.ToString();
    }
    public static string Get(object obj, int maxchars)
    {
        if (obj == System.DBNull.Value || obj == null)
            return "";
        else
        {
            string str = obj.ToString();
            str = str.Substring(0, (str.Length > maxchars ? maxchars : str.Length));
            return str;
        }
    }
    #endregion

    // Get int value

    #region [ GetInt(object obj) ]
    public static int GetInt(object obj)
    {
        
            try
            {
                return Convert.ToInt16(obj);
            }
            catch 
            {
                return 0;
            }
       
    }
    #endregion

    // Get Boolean value

    #region [ GetBool(object obj) ]
    public static bool GetBool(object obj)
    {
        if (obj == System.DBNull.Value || obj == null || obj.ToString()=="")
            return false;
        else
            return Convert.ToBoolean(obj);
    }
    #endregion

    // Get Date Value

    #region [ GetDate(object obj) ]
    public static DateTime GetDate(object obj)
    {
        if (obj == System.DBNull.Value || obj == null)
            return DateTime.Now;
        else
            return Convert.ToDateTime(obj);
    }
    #endregion

    // Get Decimal Value

    #region [ GetDecimal(object obj) ]
    public static decimal GetDecimal(object obj)
    {
        if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            return 0;
        else
            return Convert.ToDecimal(obj);
    }
    #endregion

    #endregion

    #region [ CheckUniqueId(string email) ]
    public bool CheckUniqueId(string email)
    {
        SQLHelper objSQL = new SQLHelper();
        int res = Convert.ToInt32(objSQL.GetSingleValue("sp_CheckUniqueId '" + email.Trim() + "'"));
        if (res > 0)
            return false;
        else
            return true;
    }
    #endregion

    #region [ GetCount(string Tablename) ]
    public int GetCount(string Tablename)
    {
        SQLHelper objSQL = new SQLHelper();
        int count = 0;
        if (Tablename == "orders")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from orders join customers on customer_id = order_customer_id"));
        else if (Tablename == "testimonials")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from testimonials join customers on customer_id = testimonial_customer_id"));
        else if (Tablename == "pages")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/StaticPages"));
            FileInfo[] files = dirInfo.GetFiles();
            count = files.Length;
        }
        else if (Tablename == "quotes")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from custom_quote join customers on customer_id = custom_quote_customer_id AND IsProcessed='0'"));
        else if (Tablename == "tblMessages")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from tblMessages where Status = 'saved'"));
        else
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from " + Tablename));
        return count;
    }
    #endregion

    #region [ GetDistinct(DataTable dt, string ColumnName) ]
    public static DataTable GetDistinct(DataTable dt, string ColumnName)
    {
        DataTable result = dt.Copy();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bool flag = false;
            for (int j = 0; j < result.Rows.Count; j++)
            {
                if (flag && result.Rows[j][ColumnName] == dt.Rows[i][ColumnName])
                {
                    result.Rows[j].Delete();
                    j--;
                }
                else if (result.Rows[j][ColumnName].ToString().Trim() == dt.Rows[i][ColumnName].ToString().Trim())
                    flag = true;
            }
        }
        return result;
    }
    #endregion


    #region [ GetDistinct(ArrayList obj) ]
    public static ArrayList GetDistinct(ArrayList obj)
    {
        for (int i = 0; i < obj.Count - 1; i++)
        {
            for (int j = i + 1; j < obj.Count; j++)
            {
                if (obj[i].Equals(obj[j]))
                {
                    obj.RemoveAt(j);
                    j = j - 1;
                }
            }
        }
        return obj;
    }
    #endregion


    #region [ IsExist(DataTable dt, string[] Values ]
    public static bool IsExist(DataTable dt, string[] Values) // sequence of columns in datatable and values in array must be same.
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bool flag = true;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (Values[j] != dt.Rows[i][j].ToString())
                    flag = false;
            }
            if (flag)
                return true;
        }
        return false;
    }
    #endregion

    #region [ ArrayList getSortedSize(ArrayList arr) ]
    public static ArrayList getSortedSize(ArrayList arr)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("objvalue");
        dt.Columns.Add("objunit");
        for (int i = 0; i < arr.Count; i++)
        {
            DataRow dr = dt.NewRow();

            dr["objvalue"] = arr[i].ToString().Split(" ".ToCharArray())[0];
            dr["objunit"] = arr[i].ToString().Split(" ".ToCharArray())[1];
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);

        dv.Sort = "objunit,objvalue asc";
        dt = dv.ToTable();
        arr.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            arr.Add(dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString());
        }
        return arr;
    }
    #endregion


    #region [ Filter(string obj) ]
    public static string Filter(string obj)
    {
        // coding to do 
        string[] badChars = { "select", "drop", "--", "insert", "delete", "xp_", "update", "exec" };
        for (int i = 0; i < 8; i++)
        {
            obj = obj.Replace(badChars[i], "");
        }
        obj= obj.Replace("'","''");
        return obj;
    }
    #endregion

    public static string GenerateClassCode()
    {
        StringBuilder classCode = new StringBuilder();
        Random r = new Random();

        string alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "01234567890123456789012345";

        for (int i = 0; i <= 5; i++)
        {
            classCode.Append(alphabets[r.Next(alphabets.Length)].ToString().ToUpper());
            classCode.Append(numbers[r.Next(numbers.Length)]);
        }


        return classCode.ToString();



    }

}