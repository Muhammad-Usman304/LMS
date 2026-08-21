using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Edumin.Services.Interfaces;

namespace Edumin.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;

        public TeacherService(
            ITeacherRepository teacherRepository,
            IGenderRepository genderRepository,
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository)
        {
            _teacherRepository = teacherRepository;
            _genderRepository = genderRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllTeachersAsync();
        }

        public async Task<TeacherModel> GetTeacherAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherByIdAsync(teacherId);
        }

        public async Task<SpResult> SaveTeacherAsync(TeacherModel model)
        {
            return await _teacherRepository.UpsertTeacherAsync(model);
        }

        public async Task<int> DeleteTeacherAsync(int teacherId)
        {
            return await _teacherRepository.DeleteTeacherAsync(teacherId);
        }

        public async Task<IEnumerable<GenderModel>> GetAllGendersAsync()
        {
            return await _genderRepository.GetAllGendersAsync();
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<DesignationModel>> GetAllDesignationsAsync()
        {
            return await _designationRepository.GetAllAsync();
        }
    }
}
