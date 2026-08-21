using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<DesignationModel>> GetAllAsync();
    }
}
