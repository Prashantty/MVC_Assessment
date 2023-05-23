using Microsoft.AspNetCore.Mvc;

namespace MVC_Assessment.Controllers
{
    public class RequestViewController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
