using Dapper;
using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;

namespace Edumin.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDapperRepository _dapperRespository;

        public StudentRepository(IDapperRepository dapperRespository)
        {
            _dapperRespository = dapperRespository;
        }
        public async Task<int> DeleteStudentAsync(int studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StudentId", studentId);

            return await _dapperRespository.ExecuteAsync("sp_DeleteStudent", parameters);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _dapperRespository.QueryAsync<Student>("sp_GetAllStudents");
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StudentId", studentId);

            return await _dapperRespository.QueryFirstOrDefaultAsync<Student>("sp_GetStudentById", parameters);
        }

        public async Task<SpResult> UpsertStudentAsync(Student student)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StudentId", student.StudentId);
            parameters.Add("@FirstName", student.FirstName);
            parameters.Add("@LastName", student.LastName);
            parameters.Add("@Email", student.Email);
            parameters.Add("@RegistrationDate", student.RegistrationDate);
            parameters.Add("@RollNo", student.RollNo);
            parameters.Add("@ClassId", student.ClassId);
            parameters.Add("@GenderId", student.GenderId);
            parameters.Add("@MobileNumber", student.MobileNumber);
            parameters.Add("@ParentName", student.ParentName);
            parameters.Add("@ParentMobileNumber", student.ParentMobileNumber);
            parameters.Add("@DateOfBirth", student.DateOfBirth);
            parameters.Add("@Address", student.Address);


            return await _dapperRespository.QueryFirstOrDefaultAsync<SpResult>("sp_UpsertStudent", parameters);
        }
    }
}
