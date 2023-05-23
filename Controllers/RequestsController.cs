using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Assessment.Context;
using MVC_Assessment.Interface;
using MVC_Assessment.Models;
using static MVC_Assessment.Models.Course;

namespace MVC_Assessment.Controllers
{
    public class RequestsController : Controller
    {
        private readonly TravelDbContext _context;
        ICourseInterface _course;

        public RequestsController(TravelDbContext context , ICourseInterface course)
        {
            _context = context;
            _course = course;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
              return _context.requests != null ? 
                          View(await _context.requests.ToListAsync()) :
                          Problem("Entity set 'TravelDbContext.requests'  is null.");
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] =
                  new SelectList(_course.GetCourse(),
                  "CourseId", "CourseName"

                  );
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,RequestDate,Comment,CouseId,BatchName,ManagerId,UserId")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,RequestDate,Comment,CouseId,BatchName,ManagerId,UserId")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.requests == null)
            {
                return Problem("Entity set 'TravelDbContext.requests'  is null.");
            }
            var request = await _context.requests.FindAsync(id);
            if (request != null)
            {
                _context.requests.Remove(request);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
          return (_context.requests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
        

        public IActionResult SendRequest(int id)
        {
            Request request = new Request();
            request.RequestDate = DateTime.Now;
            request.CouseId = id;

            request.UserId = 1;
            request.Comment = "com1";
            request.BatchName= string.Empty;
            _context.requests.Add(request);
            _context.SaveChanges();
            return RedirectToAction("Index" ,"RequestView");
        }
    }
}
