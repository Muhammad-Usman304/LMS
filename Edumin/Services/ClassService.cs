using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Edumin.Services.Interfaces;

namespace Edumin.Services
{
    public class ClassService: IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassesAsync()
        {
            return await _classRepository.GetAllClassesAsync();
        }

        public async Task<ClassModel> GetClassAsync(int classId)
        {
            return await _classRepository.GetClassByIdAsync(classId);
        }

        public async Task<SpResult> SaveClassAsync(ClassModel model)
        {
            return await _classRepository.UpsertClassAsync(model);
        }

        public async Task<int> DeleteClassAsync(int classId)
        {
            return await _classRepository.DeleteClassAsync(classId);
        }
    }
}
