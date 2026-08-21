using Edumin.Models;

namespace Edumin.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<DepartmentModel> GetByIdAsync(int departmentId);
        Task<SpResult> SaveAsync(DepartmentModel model);
        Task<int> DeleteAsync(int departmentId);
    }
}
