using Newtonsoft.Json;
using System.Data;
using System.Collections;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using ASpNetCore.Repository;

namespace ASpNetCore.Models
{
    public class loginModel
    {
        public int iLoginId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public int getLogin(string userName, string password,string con =null)
        {
            int LogInEmpID = 0;
            var loginRepository = new LoginRepository();
             LogInEmpID=  loginRepository.getLogin(userName, password, con);

            return LogInEmpID;

        }
    }
    public class profileModel
    {
        public profileModel() 
        {
             ProfileView = new profileView();
        }
        public profileView ProfileView { get; set; }
    }
    public class profileView
    {
        public int iProfileId { get; set; }
        public string profileName { get; set; }
        public string profileUrl { get; set; }

        public string sEmial { get; set; }
        public Int64 phoneNumber { get; set; }
        public string bloodGroup { get; set; }
    }
}
