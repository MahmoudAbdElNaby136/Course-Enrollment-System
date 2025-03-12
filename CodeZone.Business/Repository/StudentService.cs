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
    public class StudentService:IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context) => _context = context;

        public async Task<List<Student>> GetAllStudentsAsync()
            => await _context.Students.ToListAsync();

        public async Task<Student> GetStudentByIdAsync(int id)
            => await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

        public async Task AddStudentAsync(Student student)
        {
            if (await IsEmailUniqueAsync(student.Email))
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Email address already exists.");
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            var existingStudent = await GetStudentByIdAsync(student.Id);
            if (existingStudent == null)
                throw new KeyNotFoundException("Student not found");

            // Check if email is being changed
            if (existingStudent.Email != student.Email)
            {
                if (!await IsEmailUniqueAsync(student.Email))
                    throw new InvalidOperationException(" email address is already registered");
            }

            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student == null)
                throw new KeyNotFoundException("Student not found");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        //public async Task<bool> IsEmailUniqueAsync(string email)
        //    => !await _context.Students.AnyAsync(s => s.Email == email);
        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            string normalizedEmail = email.ToLowerInvariant();
            return !await _context.Students
                .AnyAsync(s => s.Email.ToLower() == normalizedEmail);
        }
    }
}
