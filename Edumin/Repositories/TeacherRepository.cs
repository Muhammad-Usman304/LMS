using Dapper;
using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public TeacherRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllTeachersAsync()
        {
            return await _dapperRepository.QueryAsync<TeacherModel>("sp_GetAllTeachers");
        }

        public async Task<TeacherModel> GetTeacherByIdAsync(int teacherId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherId", teacherId);

            return await _dapperRepository.QueryFirstOrDefaultAsync<TeacherModel>("sp_GetTeacherById", parameters);
        }

        public async Task<SpResult> UpsertTeacherAsync(TeacherModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherId", model.TeacherId);
            parameters.Add("@FirstName", model.FirstName);
            parameters.Add("@LastName", model.LastName);
            parameters.Add("@Email", model.Email);
            parameters.Add("@JoiningDate", model.JoiningDate);
            parameters.Add("@Password", model.Password);
            parameters.Add("@MobileNumber", model.MobileNumber);
            parameters.Add("@GenderId", model.GenderId);
            parameters.Add("@DesignationId", model.DesignationId);
            parameters.Add("@DepartmentId", model.DepartmentId);
            parameters.Add("@DateOfBirth", model.DateOfBirth);
            parameters.Add("@Education", model.Education);
            parameters.Add("@ProfileImagePath", model.ProfileImagePath);

            return await _dapperRepository.QueryFirstOrDefaultAsync<SpResult>("sp_UpsertTeacher", parameters);
        }

        public async Task<int> DeleteTeacherAsync(int teacherId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherId", teacherId);

            return await _dapperRepository.ExecuteAsync("sp_DeleteTeacher", parameters);
        }
    }
}
