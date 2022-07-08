using BenchProject1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TickContext _context;

        public CompanyRepository(TickContext context)
        {
            _context = context;
        }

        public async Task<Company> Get(string code)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Code == code);
        }
        public async Task<List<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }
    }
}
