using Microsoft.EntityFrameworkCore;
using CodeZone.Business.Interfaces;
using CodeZone.DataAccess.Models;
using System;
using CodeZone.DataAccess;
namespace CodeZone.Business.Repository
{
    public class CourseService:ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context) => _context = context;

        // Get all courses
        public async Task<List<Course>> GetAllCoursesAsync()
            => await _context.Courses.ToListAsync();

        // Get a course by ID
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses
                        .Include(c => c.Enrollments)
                        .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Add a new course
        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        // Update a course
        public async Task UpdateCourseAsync(Course course)
        {
            var existingCourse = await GetCourseByIdAsync(course.Id);
            if (existingCourse == null)
                throw new KeyNotFoundException("Course not found");
            //existingCourse will tracked by EF Core automatically but course no so if we use update method it will throw exception so we use SetValues method with Entry(existingCourse).CurrentValues
            _context.Entry(existingCourse).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();
        }

        // Delete a course (and its enrollments)
        public async Task DeleteCourseAsync(int id)
        {
            var course = await GetCourseByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException("Course not found");

            // Remove all enrollments for this course
            _context.Enrollments.RemoveRange(course.Enrollments);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        // Get available slots for a course
        public async Task<int> GetAvailableSlotsAsync(int courseId)
        {
            var course = await GetCourseByIdAsync(courseId);
            return course.MaxCapacity - course.Enrollments.Count;
        }
        public async Task<Course> GetCourseWithEnrollmentsAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student) // Assuming Enrollment has a Student property
                .FirstOrDefaultAsync(c => c.Id == id);

        }
    }
}
