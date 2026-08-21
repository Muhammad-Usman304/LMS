using Edumin.Models;

namespace Edumin.Services.Interfaces
{
    public interface IStudentService
    {
        Task<SpResult> SaveStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentAsync(int studentId);
        Task<int> DeleteStudentAsync(int studentId);


        Task<IEnumerable<ClassModel>> GetAllClassesAsync();
        Task<IEnumerable<GenderModel>> GetAllGendersAsync();
    }
}
