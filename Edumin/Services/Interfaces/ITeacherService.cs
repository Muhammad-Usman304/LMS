using Edumin.Models;

namespace Edumin.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetAllTeachersAsync();
        Task<TeacherModel> GetTeacherAsync(int teacherId);
        Task<SpResult> SaveTeacherAsync(TeacherModel model);
        Task<int> DeleteTeacherAsync(int teacherId);

        Task<IEnumerable<GenderModel>> GetAllGendersAsync();
        Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync();
        Task<IEnumerable<DesignationModel>> GetAllDesignationsAsync();
    }
}
