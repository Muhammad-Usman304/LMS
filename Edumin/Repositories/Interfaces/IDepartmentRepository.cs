using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<DepartmentModel> GetByIdAsync(int departmentId);
        Task<SpResult> UpsertAsync(DepartmentModel model);
        Task<int> DeleteAsync(int departmentId);
    }
}
