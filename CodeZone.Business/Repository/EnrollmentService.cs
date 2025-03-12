using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeZone.Business.Interfaces;
using CodeZone.DataAccess.Models;
using CodeZone.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Business.Repository
{
    public class EnrollmentService:IEnrollmentService
    {
        private readonly AppDbContext _context;
        public EnrollmentService(AppDbContext context) => _context = context;

        // Get all enrollments
        public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
            => await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();


        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        // Check if enrollment is allowed
        public async Task<bool> IsEnrollmentPossibleAsync(int studentId, int courseId)
        {
            // Check if student exists
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) return false;

            // Check if course exists
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return false;

            // Check course capacity
            bool isCourseFull = course.Enrollments.Count >= course.MaxCapacity;

            // Check duplicate enrollment
            bool isAlreadyEnrolled = await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            return !isCourseFull && !isAlreadyEnrolled;
        }
        // Enroll a student in a course
        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            if (!await IsEnrollmentPossibleAsync(studentId, courseId))
                throw new InvalidOperationException("Enrollment failed: Course full or student already enrolled");

            _context.Enrollments.Add(new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            });
            await _context.SaveChangesAsync();
        }



        // Cancel an enrollment
        public async Task CancelEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
                throw new KeyNotFoundException("Enrollment not found");

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
