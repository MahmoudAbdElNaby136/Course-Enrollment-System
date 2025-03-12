using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeZone.DataAccess.Models;

namespace CodeZone.Business.Interfaces
{
    public interface IEnrollmentService
    {
        Task<List<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment?> GetEnrollmentByIdAsync(int id);
        Task EnrollStudentAsync(int studentId, int courseId);
        Task<bool> IsEnrollmentPossibleAsync(int studentId, int courseId);
        Task CancelEnrollmentAsync(int enrollmentId);
    }
}
