using Dapper;
using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDapperRepository _dapper;

        public DepartmentRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            return await _dapper.QueryAsync<DepartmentModel>("sp_GetAllDepartments");
        }

        public async Task<DepartmentModel> GetByIdAsync(int departmentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);

            return await _dapper.QueryFirstOrDefaultAsync<DepartmentModel>("sp_GetDepartmentById", parameters);
        }

        public async Task<SpResult> UpsertAsync(DepartmentModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", model.DepartmentId);
            parameters.Add("@DepartmentName", model.DepartmentName);

            return await _dapper.QueryFirstOrDefaultAsync<SpResult>("sp_UpsertDepartment", parameters);
        }

        public async Task<int> DeleteAsync(int departmentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);

            return await _dapper.ExecuteAsync("sp_DeleteDepartment", parameters);
        }
    }
}
