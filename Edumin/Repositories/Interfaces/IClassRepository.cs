using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassModel>> GetAllClassesAsync();

        Task<ClassModel> GetClassByIdAsync(int classId);
        Task<SpResult> UpsertClassAsync(ClassModel model);
        Task<int> DeleteClassAsync(int classId);
    }
}
