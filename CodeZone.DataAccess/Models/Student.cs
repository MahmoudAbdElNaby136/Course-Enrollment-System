using System.ComponentModel.DataAnnotations;

namespace CodeZone.DataAccess.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required, MaxLength(14)]
        public string NationalId { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

    }
}
