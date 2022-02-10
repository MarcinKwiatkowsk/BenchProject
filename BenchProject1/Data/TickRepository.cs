using BenchProject1.Models;
using MongoDB.Driver;
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
            await _context.Ticks.InsertManyAsync(ticks);
        }

        public List<Tick> Get(DateTime start, DateTime end)
        {
            List<Tick> allTicks = (List<Tick>)_context.Ticks;
            //List<Tick> tickInDates = allTicks.Select(t => t.TickDateTime > start).Where(t => t.TickDateTime < end);
            List<Tick> tickInDates = (List<Tick>)allTicks.Where(t => t.TickDateTime > start && t.TickDateTime < end);
            return tickInDates;
        }

        public List<Tick> Get()
        {

            return (List<Tick>)_context.Ticks;
        }


    }
}
