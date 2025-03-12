
using CodeZone.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.DataAccess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("CodeZoneDB");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FullName = "mahmoud abdelnaby",
                Email = "mahmoudabdelnaby@gmail.com",
                Birthdate = new DateTime(2001, 6, 10),
                NationalId = "12345678901234",
                PhoneNumber = "12345678901"
            },
        new Student
        {
            Id = 2,
            FullName = "ali ahmed",
            Email = "aliahmed@gmail.com",
            Birthdate = new DateTime(1999, 5, 15),
            NationalId = "98765432109876",
            PhoneNumber = "15223669520"

        },
    new Student
    {
        Id = 3,
        FullName = "Sara Mohamed",
        Email = "sara.mohamed@example.com",
        Birthdate = new DateTime(2002, 7, 15),
        NationalId = "34567890123456",
        PhoneNumber = "12345678903"
    },
    new Student
    {
        Id = 4,
        FullName = "Omar Hassan",
        Email = "omar.hassan@example.com",
        Birthdate = new DateTime(1999, 11, 30),
        NationalId = "45678901234567",
        PhoneNumber = "12345678904"
    },
    new Student
    {
        Id = 5,
        FullName = "Nour Salama",
        Email = "nour.salama@example.com",
        Birthdate = new DateTime(2001, 1, 20),
        NationalId = "56789012345678",
        PhoneNumber = "12345678905"
    },
    new Student
    {
        Id = 6,
        FullName = "Hassan Kamal",
        Email = "hassan.kamal@example.com",
        Birthdate = new DateTime(2003, 5, 5),
        NationalId = "67890123456789",
        PhoneNumber = "12345678906"
    },
    new Student
    {
        Id = 7,
        FullName = "Yasmin Hossam",
        Email = "yasmin.hossam@example.com",
        Birthdate = new DateTime(2002, 8, 8),
        NationalId = "78901234567890",
        PhoneNumber = "12345678907"
    },
    new Student
    {
        Id = 8,
        FullName = "Karim Adel",
        Email = "karim.adel@example.com",
        Birthdate = new DateTime(2000, 12, 12),
        NationalId = "89012345678901",
        PhoneNumber = "12345678908"
    },
    new Student
    {
        Id = 9,
        FullName = "Mona Saeed",
        Email = "mona.saeed@example.com",
        Birthdate = new DateTime(1998, 9, 9),
        NationalId = "90123456789012",
        PhoneNumber = "12345678909"
    },
    new Student
    {
        Id = 10,
        FullName = "Mostafa Ahmed",
        Email = "mostafa.ahmed@example.com",
        Birthdate = new DateTime(2001, 4, 18),
        NationalId = "01234567890123",
        PhoneNumber = "12345678910"
    },
    new Student
    {
        Id = 11,
        FullName = "Layla Tarek",
        Email = "layla.tarek@example.com",
        Birthdate = new DateTime(2003, 6, 22),
        NationalId = "11234567890123",
        PhoneNumber = "12345678911"
    },
    new Student
    {
        Id = 12,
        FullName = "Amr Galal",
        Email = "amr.galal@example.com",
        Birthdate = new DateTime(1999, 10, 10),
        NationalId = "21234567890123",
        PhoneNumber = "12345678912"
    },
    new Student
    {
        Id = 13,
        FullName = "Rania Magdy",
        Email = "rania.magdy@example.com",
        Birthdate = new DateTime(2000, 2, 28),
        NationalId = "31234567890123",
        PhoneNumber = "12345678913"
    },
    new Student
    {
        Id = 14,
        FullName = "Tamer Shawky",
        Email = "tamer.shawky@example.com",
        Birthdate = new DateTime(2002, 11, 5),
        NationalId = "41234567890123",
        PhoneNumber = "12345678914"
    },
    new Student
    {
        Id = 15,
        FullName = "Dina Fawzy",
        Email = "dina.fawzy@example.com",
        Birthdate = new DateTime(2001, 7, 19),
        NationalId = "51234567890123",
        PhoneNumber = "12345678915"
    }
        );
            modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Title = "Mathematics",
                Description = "Introduction to Algebra and Calculus",
                MaxCapacity = 10
            },
            new Course
            {
                Id = 2,
                Title = "Physics 101",
                Description = "Introduction to Physics",
                MaxCapacity = 8
            },
            new Course
            {
                Id = 3,
                Title = "Chemistry Basics",
                Description = "Fundamentals of Chemistry and Chemical Reactions",
                MaxCapacity = 12
            },
            new Course
            {
                Id = 4,
                Title = "Biology",
                Description = "Human Anatomy and Physiology",
                MaxCapacity = 15
            },
            new Course
            {
                Id = 5,
                Title = "Computer Science",
                Description = "Fundamentals of Programming and Data Structures",
                MaxCapacity = 20
            },
            new Course
            {
                Id = 6,
                Title = "History",
                Description = "World History from Ancient to Modern Times",
                MaxCapacity = 25
            },
            new Course
            {
                Id = 7,
                Title = "English Literature",
                Description = "Exploration of Classic and Modern Literature",
                MaxCapacity = 18
            },
            new Course
            {
                Id = 8,
                Title = "Business Administration",
                Description = "Principles of Business Management and Economics",
                MaxCapacity = 30
            },
            new Course
            {
                Id = 9,
                Title = "Marketing Strategies",
                Description = "Modern Marketing Techniques and Consumer Behavior",
                MaxCapacity = 22
            },
            new Course
            {
                Id = 10,
                Title = "Psychology",
                Description = "Introduction to Human Behavior and Mental Processes",
                MaxCapacity = 16
            },
            new Course
            {
                Id = 11,
                Title = "Graphic Design",
                Description = "Basics of Photoshop, Illustrator, and UI/UX Design",
                MaxCapacity = 12
            },
            new Course
            {
                Id = 12,
                Title = "Artificial Intelligence",
                Description = "Machine Learning, Neural Networks, and Deep Learning",
                MaxCapacity = 10
            },
            new Course
            {
                Id = 13,
                Title = "Cyber Security",
                Description = "Fundamentals of Cyber Threats and Ethical Hacking",
                MaxCapacity = 14
            },
            new Course
            {
                Id = 14,
                Title = "Web Development",
                Description = "Full-Stack Development with HTML, CSS, JS, and .NET",
                MaxCapacity = 20
            },
            new Course
            {
                Id = 15,
                Title = "Data Science",
                Description = "Data Analysis, Visualization, and Big Data Processing",
                MaxCapacity = 10
            }
            );

            modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.StudentId, e.CourseId })
            .IsUnique();


        }
    }
}
