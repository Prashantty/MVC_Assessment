using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;
using static MVC_Assessment.Models.User;

namespace MVC_Assessment.Controllers
{
    public class UserViewController : Controller
    {
        IUserInterface _inf;
        public UserViewController(IUserInterface inf)
        {
            _inf = inf;
        }
        public IActionResult Index()
        {
            
            return View(_inf.GetUser());
        }

        public IActionResult Create()
        {
            var roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
            ViewBag.Roles = new SelectList(roles);

            ViewData["ManagerId"] =
                   new SelectList(_inf.GetUser(),
                   "Id", "Name"

                   );
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {

            _inf.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
            ViewBag.Roles = new SelectList(roles);
            User obj = _inf.GetUserById(id);
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            User obj = _inf.GetUserById(id);
            if (obj != null)
            {
                _inf.Edit(id, user);
            }

            return RedirectToAction("Index");



        }

        public IActionResult Delete(int id)
        {

            User user = _inf.GetUserById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Deleted(int id)
        {
            User user = _inf.GetUserById(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _inf.Delete(user.Id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_inf.GetUserById(id));
        }
    }
}
