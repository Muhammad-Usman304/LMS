using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
                return 0;

            _context.Students.Remove(student);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Gender)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<SpResult> UpsertStudentAsync(Student student)
        {
            string action;

            if (student.StudentId == 0)
            {
                _context.Students.Add(student);
                action = "Inserted";
            }
            else
            {
                var existingStudent = await _context.Students
                    .FirstOrDefaultAsync(s => s.StudentId == student.StudentId);

                if (existingStudent == null)
                {
                    return new SpResult
                    {
                        Action = "Not Found"
                    };
                }

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.RegistrationDate = student.RegistrationDate;
                existingStudent.RollNo = student.RollNo;
                existingStudent.ClassId = student.ClassId;
                existingStudent.GenderId = student.GenderId;
                existingStudent.MobileNumber = student.MobileNumber;
                existingStudent.ParentName = student.ParentName;
                existingStudent.ParentMobileNumber = student.ParentMobileNumber;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Address = student.Address;

                action = "Updated";
            }

            await _context.SaveChangesAsync();

            return new SpResult
            {
                Action = action
            };
        }
    }
}