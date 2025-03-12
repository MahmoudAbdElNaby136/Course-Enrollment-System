
using CodeZone.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace n_tier.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public EnrollmentsController(
            IEnrollmentService enrollmentService,
            ICourseService courseService,
            IStudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _studentService = studentService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
            => View(await _enrollmentService.GetAllEnrollmentsAsync());

        // GET: Enrollments/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _studentService.GetAllStudentsAsync(), "Id", "FullName");
            ViewBag.Courses = new SelectList(await _courseService.GetAllCoursesAsync(), "Id", "Title");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int studentId, int courseId)
        {
            try
            {
                await _enrollmentService.EnrollStudentAsync(studentId, courseId);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Perform deletion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _enrollmentService.CancelEnrollmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<JsonResult> GetAvailableSlots(int courseId)
        {
            try
            {
                var slots = await _courseService.GetAvailableSlotsAsync(courseId);
                return Json(new { availableSlots = slots });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
