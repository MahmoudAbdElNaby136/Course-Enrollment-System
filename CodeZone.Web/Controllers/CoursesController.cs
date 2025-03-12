
using CodeZone.Business.Interfaces;
using CodeZone.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace n_tier.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
            => _courseService = courseService;

        // GET: Courses
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; // Number of courses per page
            int pageNumber = page ?? 1; // Default to page 1 if no page is provided

            var courses = await _courseService.GetAllCoursesAsync();

            var pagedCourses = courses
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Page = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(courses.Count / (double)pageSize);

            return View(pagedCourses);
        }

        
        public IActionResult Create()
            => View();

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _courseService.AddCourseAsync(course);
                    return RedirectToAction(nameof(Index));

                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
               
            }
            // If validation fails, redisplay the form with errors
            return View(course);
        }

public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return course == null ? NotFound() : View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id != course.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _courseService.UpdateCourseAsync(course);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
            return View(course);
        }

        public async Task<IActionResult> Information(int id)
        {
            var course = await _courseService.GetCourseWithEnrollmentsAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }
        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return course == null ? NotFound() : View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
