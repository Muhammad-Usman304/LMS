using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> GetAllTeachersAsync();
        Task<TeacherModel> GetTeacherByIdAsync(int teacherId);
        Task<SpResult> UpsertTeacherAsync(TeacherModel model);
        Task<int> DeleteTeacherAsync(int teacherId);
    }
}
