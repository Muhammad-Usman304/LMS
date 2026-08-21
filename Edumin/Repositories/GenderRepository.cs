using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public GenderRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }
        public async Task<IEnumerable<GenderModel>> GetAllGendersAsync()
        {
            return await _dapperRepository.QueryAsync<GenderModel>("sp_GetAllGenders");
        }
    }
}
