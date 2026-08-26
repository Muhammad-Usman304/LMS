using Edumin.Data;
using Edumin.Models;
using Edumin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edumin.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly AppDbContext _context;

        public GenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GenderModel>> GetAllGendersAsync()
        {
            return await _context.Genders
                .ToListAsync();
        }
    }
}