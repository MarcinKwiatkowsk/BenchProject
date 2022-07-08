using BenchProject1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public class TickRepository : ITickRepository
    {

        private readonly TickContext _context;
        public TickRepository(TickContext context)
        {
            _context = context;
        }
        public async Task Add(List<Tick> ticks)
        {
            _context.Ticks.AddRange(ticks);
            await _context.SaveChangesAsync();
        }

        public async Task Add(Tick tick)
        {
            _context.Ticks.Add(tick);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tick>> Get(DateTime start, DateTime end, string companyCode)
        {
            return await _context.Ticks.Where(t => t.TickDateTime >= start &&
            t.TickDateTime <= end &&
            t.Company.Code == companyCode).ToListAsync();
        }

        public async Task<List<Tick>> Get()
        {
            return await _context.Ticks.OrderBy(x => x.TickDateTime).ToListAsync();
        }


    }
}
