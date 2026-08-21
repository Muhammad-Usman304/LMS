using Dapper;
using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public ClassRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public Task<int> DeleteClassAsync(int classId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", classId);

            return _dapperRepository.ExecuteAsync("sp_DeleteClass", parameters);
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassesAsync()
        {
            return await _dapperRepository.QueryAsync<ClassModel>("sp_GetAllClasses");
        }

        public Task<ClassModel> GetClassByIdAsync(int classId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", classId);

            return _dapperRepository.QueryFirstOrDefaultAsync<ClassModel>("sp_GetClassById", parameters);
        }

        public Task<SpResult> UpsertClassAsync(ClassModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", model.ClassId);
            parameters.Add("@ClassName", model.ClassName);

            return _dapperRepository.QueryFirstOrDefaultAsync<SpResult>("sp_UpsertClass", parameters);
        }
    }
}
