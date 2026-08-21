using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Edumin.Services.Interfaces;

namespace Edumin.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _repo;

        public DesignationService(IDesignationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DesignationModel>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
