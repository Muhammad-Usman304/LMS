using Edumin.Models;

namespace Edumin.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassModel>> GetAllClassesAsync();
        Task<ClassModel> GetClassAsync(int classId);
        Task<SpResult> SaveClassAsync(ClassModel model);
        Task<int> DeleteClassAsync(int classId);
    }
}
