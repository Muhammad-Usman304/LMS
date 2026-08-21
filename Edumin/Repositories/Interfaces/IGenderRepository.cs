using Edumin.Models;

namespace Edumin.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<GenderModel>> GetAllGendersAsync();
    }
}
