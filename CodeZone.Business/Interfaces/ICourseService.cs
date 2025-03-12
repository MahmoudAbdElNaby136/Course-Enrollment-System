using CodeZone.DataAccess.Models;


namespace CodeZone.Business.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        Task<int> GetAvailableSlotsAsync(int courseId);
        Task<Course> GetCourseWithEnrollmentsAsync(int id);
    }
}
