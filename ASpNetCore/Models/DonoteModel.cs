using System;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace ASpNetCore.Models
{

    [Serializable]
    public class DonoteView
    {
        public DonoteView() { }
        public int iDonateId { get; set; }
        public string sName { get; set; }

        public int iPayFrequncy { get; set; }
        public string iBloodGroup { get; set; }
        public string iLocation { get; set; }
        public long iDOB { get; set; }
    }
    public class DonoteModel
    {
        public DonoteModel()
        {
            bloodDonarView = new DonoteView();
        }
        public DonoteView bloodDonarView { get; set; }
        string connection = "Server=DESKTOP-SN19IKL\\SQLEXPRESS;Database=BloodDonar;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;";

        public int postData(DonoteView   bloodDonar)
        {
            int res = 0;
            SqlConnection sqlConnection = new SqlConnection(connection);

            try
            {

                sqlConnection.Open();
                string sql = string.Format(@"insert into DonoteBlood (sDonorName,iBloodGroup,iLocation,iFrequency,DoB)values ('{0}','{1}','{2}','{3}',{4})
                     ", bloodDonar.sName, bloodDonar.iBloodGroup, bloodDonar.iLocation, bloodDonar.iPayFrequncy, bloodDonar.iDOB);
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                res = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                res = 0;
                sqlConnection.Close();
            }
            sqlConnection.Close();
            return res;
        }

        public List<DonoteView> getserchResult(string searchKey)
        {
            var searchList = new List<DonoteView>();
            SqlConnection sqlconnection = new SqlConnection(connection);

            try
            {
               
                string sql = string.Format(@"select * from DonoteBlood where sDonorName like '%{0}%'", searchKey);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlconnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                      DonoteView donoteView=new DonoteView();
                        donoteView.sName = Convert.ToString(dr["sDonorName"]);
                        donoteView.iBloodGroup = Convert.ToString(dr["iBloodGroup"]);
                        donoteView.iDonateId = Convert.ToInt32(dr["iDonateId"]);
                        donoteView.iLocation = Convert.ToString(dr["iLocation"]);
                        searchList.Add(donoteView);
                    }
                }
                sqlconnection.Close();

            }
            catch(Exception ex)
            {
               sqlconnection.Close();
                return searchList;
            }
            return searchList;
        }
    }
}
