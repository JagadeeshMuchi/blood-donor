using System.Data;
using ASpNetCore.Repository;
using System.Collections;
using Microsoft.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ASpNetCore.Models
{
    public class QuickActionModel
    {
        
    }
    [Serializable]
    public class FindDonarView
    {
        public FindDonarView() { }
        public int iDonarId { get; set; }
        public string sName { get; set; }
        public string iDonarType { get; set; }
        public string sDescription { get; set; }
        public string iBloodGroup { get; set; }
        public int  iUnits { get; set; }
        public string iLocation { get; set; }   
    }
    public class FindDonarModel
    {
        public FindDonarModel() 
        { 
            findDonarView= new FindDonarView();
        }
        public FindDonarView findDonarView { get; set; }
        string connection1 = "Server=DESKTOP-SN19IKL\\SQLEXPRESS;Database=BloodDonar;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;";
        public int postFindDonar(FindDonarView findDonarView)
        {
            int res = 0;
            SqlConnection con = new SqlConnection(connection1);
            try
            {
                string sql = string.Format(@"insert into FindDonor values ('{0}','{1}','{2}','{3}',{4},'{5}')",findDonarView.sName,
                    findDonarView.iDonarType,findDonarView.sDescription,findDonarView.iBloodGroup,findDonarView.iUnits,findDonarView.iLocation);
              
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                 res = cmd.ExecuteNonQuery();
                con.Close();
               

            }catch(Exception ex)
            {
                res = 0;
                con.Close();
                
            }
            return res;
        }
    }
    [Serializable]
    public class OrderBloodView
    {
        public OrderBloodView() { }
        public int iOrderBloodId { get; set; }
        public string sName { get; set; }
        public string  iLocation { get; set; }
        public string iBloodGroup { get; set; }
        public int iUnits { get; set; }
        public string sDescription { get; set; }
    }
    public class OrderBloodModel
    {
        public OrderBloodModel()
        {
            orderBloodView = new OrderBloodView();
        }
        string connection1 = "Server=DESKTOP-SN19IKL\\SQLEXPRESS;Database=BloodDonar;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;";
        public OrderBloodView orderBloodView { get; set; }
        public int postOrderBlood(OrderBloodView orderBlood)
        {
            int res = 0;
            SqlConnection con = new SqlConnection(connection1);
            try
            {
                string sql = string.Format(@"insert into orderBlood (spatientName,iBloodGroup,iUnits,iLocation,sDescription)values ('{0}','{1}',{2},'{3}','{4}')",
                    orderBlood.sName, orderBlood.iBloodGroup, orderBlood.iUnits, orderBlood.iLocation,
                     string.IsNullOrEmpty(orderBlood.sDescription) ? "Not Mentioned" : orderBlood.sDescription);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                res = cmd.ExecuteNonQuery();
                con.Close();

            }catch(Exception ex)
            {
                res = 0;
                con.Close();
            }
            return res;
        }
    }
}
