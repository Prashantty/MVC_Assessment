using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;
using static MVC_Assessment.Models.Course;
using static MVC_Assessment.Models.User;

namespace MVC_Assessment.Controllers
{
    public class BatchController : Controller
    {
        IBatchInterface _batch;
        ICourseInterface _course;

        public BatchController(IBatchInterface batch, ICourseInterface course)
        {
            _batch = batch;
            _course = course;   

        }
        public IActionResult Index()
        {
            return View(_batch.GetBatch());
        }

        public IActionResult Create()
        {
            ViewData["CourseId"] =
                   new SelectList(_course.GetCourse(),
                   "CourseId", "CourseName"

                   );
            return View();
        }

        [HttpPost]
        public IActionResult Create(Batch batch)
        {
            _batch.Create(batch);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Batch batch = _batch.GetBatchById(id);

            return View(batch);

        }
        [HttpPost]
        public IActionResult Edit(int id, Batch batch)
        {
            Batch obj = _batch.GetBatchById(id);
            if (obj != null)
            {
                _batch.Edit(id, batch);
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
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_course.GetCourseById(id));
        }
    }
}
