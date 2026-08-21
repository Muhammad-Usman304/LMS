using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Edumin.Services.Interfaces;

namespace Edumin.Services
{
    public class DepartmentService: IDepartmentService
    {
        
            private readonly IDepartmentRepository _repo;

            public DepartmentService(IDepartmentRepository repo)
            {
                _repo = repo;
            }

            public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
            {
                return await _repo.GetAllAsync();
            }

        public async Task<DepartmentModel> GetByIdAsync(int departmentId)
        {
            return await _repo.GetByIdAsync(departmentId);
        }

        public async Task<SpResult> SaveAsync(DepartmentModel model)
        {
            return await _repo.UpsertAsync(model);
        }

        public async Task<int> DeleteAsync(int departmentId)
        {
            return await _repo.DeleteAsync(departmentId);
        }
    }
}

