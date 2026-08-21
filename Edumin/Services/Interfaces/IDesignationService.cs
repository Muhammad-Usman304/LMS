using Edumin.Models;

namespace Edumin.Services.Interfaces
{
    public interface IDesignationService
    {
        Task<IEnumerable<DesignationModel>> GetAllAsync();
    }
}
