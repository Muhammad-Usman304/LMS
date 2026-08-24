using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Edumin.Services.Interfaces;

namespace Edumin.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IGenderRepository _genderRepository;

        public StudentService(IStudentRepository studentRepository, IClassRepository classRepository, IGenderRepository genderRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _genderRepository = genderRepository;
        }

        public async Task<SpResult> SaveStudentAsync(Student student)
        {
            return await _studentRepository.UpsertStudentAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            await _studentRepository.DeleteStudentAsync(studentId);
            return studentId;
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassesAsync()
        {
            return await _classRepository.GetAllClassesAsync();
        }

        public async Task<IEnumerable<GenderModel>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllGendersAsync();
        }
    }
}