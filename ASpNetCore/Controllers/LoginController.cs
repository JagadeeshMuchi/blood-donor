using ASpNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Data;
using System.Collections;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
namespace ASpNetCore.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IConfiguration _configuration;

        public LoginController(IWebHostEnvironment env, IHostEnvironment hostEnvironment,IConfiguration configuration)
        {
            _env = env;
            _hostEnvironment = hostEnvironment;
            _configuration = configuration;
        }
        [Route("Movie")]
        public IActionResult Create()
        {
            var actorModel = new Actor() { aId = 1, ActorName = "PowerStar PawanKalyan", movieName = "HaraHaraVeeraMallu" };
            return View(actorModel);
        }
        [Route("SignIN/{id?}")]
        public IActionResult Error(int id)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "App_Data", "findingher.txt");

            string[] lines = System.IO.File.ReadAllLines(filePath);
            ViewBag.UserData = lines;

            return View();
        }
        [Route("Index/{id?}")]
        public IActionResult Index(int? id)
        {
            var contenr = string.Empty;
          var b=  _hostEnvironment.IsDevelopment();
            if (id > 0)
            {
              contenr=  string.Format(@"<label>Enter Code is </label>  <input value={0} />", id);

            }
            else
            {
               contenr= string.Format("<p class=\"text-danger\">User does not provide employee id</p> ");
            }
            return Content(contenr,"text/html");
        }
        //[Route("SongDetails")]
        public IActionResult SongDetails()
        {
            var songModel=new SongModel();
            var jObject = new JsonSerializer();
            string filePath = Path.Combine(_env.ContentRootPath, "App_Data", "findingher.txt");
            var jOb = new JObject();

            string[] lines = System.IO.File.ReadAllLines(filePath);
            songModel.AlbumName = "FindingHer";
            songModel.ActorDetils=new Actor() {ActorName="Hritik",aId=1};
            foreach(var line in lines)
            {
                songModel.Song += " /t "+ line;
            }
            //songModel.Song = lines.ToString();
            var sB = new StringBuilder();
            using(var sW=new StringWriter(sB))
                using (var jTW=new JsonTextWriter(sW))
            jObject.Serialize(jTW, songModel);
            var jsonObject = sB.ToString();
            return Content(jsonObject, "application/json");
        }
        [Route("getLogin")]
        public IActionResult getLogin(string userName="",string passWord="")
        {
            var loginModel = new loginModel();
             response response=new  response();
           string connection = _configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(userName))
            {
                response.Id=loginModel.getLogin(userName, passWord, connection);
                response.count= 1;
            }
            return new  JsonResult(response);
        }
    }
}
