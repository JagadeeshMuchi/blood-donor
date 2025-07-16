using ASpNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Data;
using System.Collections;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web;

namespace ASpNetCore.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult getUserProfile(int iProfileId=0)
        {
            if (iProfileId > 0)
            {
                profileView profileView = new profileView()
                {
                    bloodGroup = "A+",
                    phoneNumber = 6300141957,
                    profileName = "Jagadeesh Muchi"
                 ,
                    profileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhFmMyAf8ab-FSqxhQGCiSEAHym4aZqV8CxsM09l1gLK-J_ic&s",
                    iProfileId = 1,
                    sEmial = "Jagadeesh0899@gmail.com"
                };


                return new JsonResult(profileView);
            }
            else
            {
                profileView profileViews = new profileView();
                return new JsonResult(profileViews);
            }
            
        }
    }
}
