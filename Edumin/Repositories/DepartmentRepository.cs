using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            return await _context.Departments
                .ToListAsync();
        }

        public async Task<DepartmentModel> GetByIdAsync(int departmentId)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
        }

        public async Task<SpResult> UpsertAsync(DepartmentModel model)
        {
            if (model.DepartmentId == 0)
            {
                // INSERT
                _context.Departments.Add(model);

                await _context.SaveChangesAsync();

                return new SpResult
                {
                    Id = model.DepartmentId,
                    Action = "Inserted"
                };
            }

            // UPDATE
            var existingDepartment = await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == model.DepartmentId);

            if (existingDepartment == null)
            {
                return new SpResult
                {
                    Id = model.DepartmentId,
                    Action = "Not Found"
                };
            }

            existingDepartment.DepartmentName = model.DepartmentName;

            await _context.SaveChangesAsync();

            return new SpResult
            {
                Id = existingDepartment.DepartmentId,
                Action = "Updated"
            };
        }

        public async Task<int> DeleteAsync(int departmentId)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == departmentId);

            if (department == null)
                return 0;

            _context.Departments.Remove(department);

            return await _context.SaveChangesAsync();
        }
    }
}