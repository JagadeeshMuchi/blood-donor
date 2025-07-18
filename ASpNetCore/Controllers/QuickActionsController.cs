using Microsoft.AspNetCore.Mvc;
using ASpNetCore.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json;
namespace ASpNetCore.Controllers
{
    public class QuickActionsController : Controller
    {

    }
    public class FindDonarController : Controller
    {
        public IActionResult GetFindDonar()
        {
            FindDonarModel findDonarModel= new FindDonarModel();
            return new JsonResult(findDonarModel.findDonarView);
        }
        public IActionResult postFindDonor([FromBody] FindDonarView findDonarView)
        {
           var model=new FindDonarModel();
            response response = new response();
            response.count = model.postFindDonar(findDonarView);
            return new JsonResult(response);
        }
        public IActionResult getOrderBlood()
        {
            OrderBloodView orderBloodView=new OrderBloodView();
            return new JsonResult(orderBloodView);
        }
        public IActionResult postOrderBlood([FromBody] OrderBloodView orderBloodView)
        {
            OrderBloodModel model=new OrderBloodModel();
            response response = new response();
            response.count=model.postOrderBlood(orderBloodView);    
            return new JsonResult(response);
        }
    }
    public class BloodDonorController : Controller
    {

        public IActionResult getBloodDonor()
        {
            BloodDonarView bloodDonarView = new BloodDonarView();
            return new JsonResult(bloodDonarView);
        }
        public IActionResult postBloodDonor([FromBody]BloodDonarView bloodDonarView)
        {
            BloodDonorModel model = new BloodDonorModel();
            response response = new response();
            response.count=model.postData(bloodDonarView);
            return new JsonResult(response);
        }
    }
}
