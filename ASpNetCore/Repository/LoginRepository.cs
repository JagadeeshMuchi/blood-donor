using System.Web;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ASpNetCore.Repository
{
    public class LoginRepository 
    {
        public LoginRepository() { }
        //private IConfiguration _configuration;
        //public LoginRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public int getLogin(string username, string password ,string connection = null)
        {
            int logId = 0;
            string connection1 = "Server=DESKTOP-SN19IKL\\SQLEXPRESS;Database=BloodDonar;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;";
            using (var con =new SqlConnection(connection1))
            {
                con.Open();
                string sql = string.Format(@"select iLogId from Login where sUserEmail='{0}' and Password='{1}'",username, password);
                //con.Open();
               
                SqlCommand cmd=new SqlCommand(sql,con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        logId = Convert.ToInt16(dr[0]);
                    }
                }
                con.Close();
            }
            return logId;
        }
    }
}
