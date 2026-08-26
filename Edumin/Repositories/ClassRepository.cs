using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteClassAsync(int classId)
        {
            var classModel = await _context.Classes
                .FirstOrDefaultAsync(x => x.ClassId == classId);

            if (classModel == null)
                return 0;

            _context.Classes.Remove(classModel);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<ClassModel> GetClassByIdAsync(int classId)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == classId);
        }

        public async Task<SpResult> UpsertClassAsync(ClassModel model)
        {
            if (model.ClassId == 0)
            {
                _context.Classes.Add(model);

                await _context.SaveChangesAsync();

                return new SpResult
                {
                    Id = model.ClassId,
                    Action = "Inserted"
                };
            }

            var existingClass = await _context.Classes
                .FirstOrDefaultAsync(x => x.ClassId == model.ClassId);

            if (existingClass == null)
            {
                return new SpResult
                {
                    Id = model.ClassId,
                    Action = "Not Found"
                };
            }

            existingClass.ClassName = model.ClassName;

            await _context.SaveChangesAsync();

            return new SpResult
            {
                Id = existingClass.ClassId,
                Action = "Updated"
            };
        }
    }
}