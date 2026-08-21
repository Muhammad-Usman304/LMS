using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<SpResult> UpsertStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<int> DeleteStudentAsync(int studentId);
    }
}
