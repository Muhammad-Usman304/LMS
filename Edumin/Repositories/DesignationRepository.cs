using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly IDapperRepository _dapper;

        public DesignationRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<DesignationModel>> GetAllAsync()
        {
            return await _dapper.QueryAsync<DesignationModel>("sp_GetAllDesignations");
        }
    }
}
