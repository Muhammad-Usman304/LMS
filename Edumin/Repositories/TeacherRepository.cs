using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeachersAsync()
        {
            return await (
                from teacher in _context.Teachers
                join gender in _context.Genders
                    on teacher.GenderId equals gender.GenderId
                join designation in _context.Designations
                    on teacher.DesignationId equals designation.DesignationId
                join department in _context.Departments
                    on teacher.DepartmentId equals department.DepartmentId
                select new TeacherModel
                {
                    TeacherId = teacher.TeacherId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    JoiningDate = teacher.JoiningDate,
                    Password = teacher.Password,
                    MobileNumber = teacher.MobileNumber,
                    GenderId = teacher.GenderId,
                    DesignationId = teacher.DesignationId,
                    DepartmentId = teacher.DepartmentId,
                    DateOfBirth = teacher.DateOfBirth,
                    Education = teacher.Education,
                    ProfileImagePath = teacher.ProfileImagePath,

                    GenderName = gender.GenderName,
                    DesignationName = designation.DesignationName,
                    DepartmentName = department.DepartmentName
                }
            ).ToListAsync();
        }

        public async Task<TeacherModel> GetTeacherByIdAsync(int teacherId)
        {
            return await (
                from teacher in _context.Teachers
                join gender in _context.Genders
                    on teacher.GenderId equals gender.GenderId
                join designation in _context.Designations
                    on teacher.DesignationId equals designation.DesignationId
                join department in _context.Departments
                    on teacher.DepartmentId equals department.DepartmentId
                where teacher.TeacherId == teacherId
                select new TeacherModel
                {
                    TeacherId = teacher.TeacherId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    JoiningDate = teacher.JoiningDate,
                    Password = teacher.Password,
                    MobileNumber = teacher.MobileNumber,
                    GenderId = teacher.GenderId,
                    DesignationId = teacher.DesignationId,
                    DepartmentId = teacher.DepartmentId,
                    DateOfBirth = teacher.DateOfBirth,
                    Education = teacher.Education,
                    ProfileImagePath = teacher.ProfileImagePath,

                    GenderName = gender.GenderName,
                    DesignationName = designation.DesignationName,
                    DepartmentName = department.DepartmentName
                }
            ).FirstOrDefaultAsync();
        }

        public async Task<SpResult> UpsertTeacherAsync(TeacherModel model)
        {
            string action;

            if (model.TeacherId == 0)
            {
                _context.Teachers.Add(model);

                action = "Inserted";
            }
            else
            {
                var existingTeacher = await _context.Teachers
                    .FirstOrDefaultAsync(t => t.TeacherId == model.TeacherId);

                if (existingTeacher == null)
                {
                    return new SpResult
                    {
                        Action = "Not Found"
                    };
                }

                existingTeacher.FirstName = model.FirstName;
                existingTeacher.LastName = model.LastName;
                existingTeacher.Email = model.Email;
                existingTeacher.JoiningDate = model.JoiningDate;
                existingTeacher.Password = model.Password;
                existingTeacher.MobileNumber = model.MobileNumber;
                existingTeacher.GenderId = model.GenderId;
                existingTeacher.DesignationId = model.DesignationId;
                existingTeacher.DepartmentId = model.DepartmentId;
                existingTeacher.DateOfBirth = model.DateOfBirth;
                existingTeacher.Education = model.Education;
                existingTeacher.ProfileImagePath = model.ProfileImagePath;

                action = "Updated";
            }

            await _context.SaveChangesAsync();

            return new SpResult
            {
                Action = action
            };
        }

        public async Task<int> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (teacher == null)
                return 0;

            _context.Teachers.Remove(teacher);

            return await _context.SaveChangesAsync();
        }
    }
}