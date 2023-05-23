using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;
using static MVC_Assessment.Models.Course;
using static MVC_Assessment.Models.User;

namespace MVC_Assessment.Controllers
{
    public class CourseController : Controller
    {
        ICourseInterface _course;
        public CourseController(ICourseInterface course)
        {
            _course = course;
        }
        public IActionResult Index()
        {

            return View(_course.GetCourse());
        }


        public IActionResult Create()
        {
            var course = Enum.GetValues(typeof(Courses)).Cast<Courses>().ToList();
            ViewBag.Courses = new SelectList(course);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {

            _course.Create(course);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var course = Enum.GetValues(typeof(Courses)).Cast<Courses>().ToList();
            ViewBag.Courses = new SelectList(course);
            Course obj = _course.GetCourseById(id);
            return View(obj);

        }
        [HttpPost]
        public IActionResult Edit(int id, Course course)
        {
           Course obj = _course.GetCourseById(id);
            if (obj != null)
            {
                _course.Edit(id, course);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {

            Course obj = _course.GetCourseById(id);
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Deleted(int id)
        {
            Course obj = _course.GetCourseById(id);
            if (obj == null)
            {

                return RedirectToAction("Index");
            }
            else
            {
                _course.Delete(obj.CourseId);
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Details(int id)
        {
            return View(_course.GetCourseById(id));
        }

    }
}
