using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly AppDbContext _context;

        public DesignationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DesignationModel>> GetAllAsync()
        {
            return await _context.Designations
                .ToListAsync();
        }
    }
}