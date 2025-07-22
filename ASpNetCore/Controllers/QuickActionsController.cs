using Microsoft.AspNetCore.Mvc;
using ASpNetCore.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ASpNetCore.Controllers
{
    
    public class QuickActionsController : Controller
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
        public IActionResult getSearchResults(string searchKey = null)
        {
            var obj=new DonoteModel();

            List<DonoteView> lstDonoteVie = obj.getserchResult(searchKey);
            return new JsonResult(lstDonoteVie);
        }


    }
}
