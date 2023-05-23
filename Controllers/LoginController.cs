using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Assessment.Controllers
{
    public class LoginController : Controller
    {

    public string UserName;

    public string Password;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Login() 
        { 
          return RedirectToAction("Index", "User");
        
        }

        
    }
}
