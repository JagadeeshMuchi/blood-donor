using ASpNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace ASpNetCore.Controllers
{
    public class DonoteController : Controller
    {
        public IActionResult getBloodDonor()
        {
            DonoteView bloodDonarView = new DonoteView();
            return new JsonResult(bloodDonarView);
        }

        public IActionResult postBloodDonor([FromForm] string model)
        {
           
            var model1 = new DonoteModel();
            response response = new response();
            DonoteView obj = JsonConvert.DeserializeObject<DonoteView>(model);
            response.count = model1.postData(obj);
            return new JsonResult(response);
        }
    }
}
