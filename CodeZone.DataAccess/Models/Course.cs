using System.ComponentModel.DataAnnotations;

namespace CodeZone.DataAccess.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Max capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Max capacity must be at least 1")]
        public int MaxCapacity { get; set; }
        public List<Enrollment>? Enrollments { get; set; }
    }
}
