using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProjectFinal.ConnectToDB
{
    public class LoginDao
    {
        // Property error to show error for user
        private string errorMessage;

        // Property error to show error for user
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public bool Login(UserAdmin userAdmin)
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();

                //Query string to query data
                //string queryString = "select * from Admin where TenDangNhap = @tenDangNhap and MatKhau=@matKhau";
                string queryString = string.Format("select * from Admin where TenDangNhap = '{0}' and MatKhau='{1}'",
                    userAdmin.TenDangNhap,GetMD5(userAdmin.MatKhau));
                //Declare dataset, excute query and assign result to dataset
                DataSet dsResult = connectToDB.ExecuteQueryDataSet(queryString, System.Data.CommandType.Text, ref errorMessage);

                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                //Assin error and return result
                errorMessage = exception.Message;
            }
            return false;
        }
        public bool Register(RegisterAdmin registerAdmin)
        {
            try
            {
                //Inital class connecto to DB
                ConnectToDB connectToDB = new ConnectToDB();

                //Query string to query data
                string queryString = string.Format("insert into Admin(TenDangNhap,MatKhau,TenCongTy) Values('{0}','{1}','{2}')",
                    registerAdmin.TenDangNhap, GetMD5(registerAdmin.MatKhau), registerAdmin.TenCongTy);
                //Declare dataset, excute query and assign result to dataset
                return connectToDB.ExecuteNonQuery(queryString, System.Data.CommandType.Text, ref errorMessage);
            }
            catch (Exception exception)
            {
                //Assin error and return result
                errorMessage = exception.Message;
            }
            return false;
        }
        public static string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }

            return sbHash.ToString();

        }
    }
}