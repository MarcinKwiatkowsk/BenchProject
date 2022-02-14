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
        public void Add(List<Tick> ticks)
        {
             _context.Ticks.AddRange(ticks);
            // _context.Ticks.AddRange(ticks);
        }

        public void Add(Tick tick)
        {
             _context.Ticks.AddRange((IEnumerable<Tick>)tick);
        }

        public List<Tick> Get(DateTime start, DateTime end)
        {
            List<Tick> allTicks = _context.Ticks;
            //List<Tick> tickInDates = allTicks.Select(t => t.TickDateTime > start).Where(t => t.TickDateTime < end);
            List<Tick> tickInDates = allTicks.Where(t => t.TickDateTime > start && t.TickDateTime < end).ToList();
            return tickInDates;
        }

        public List<Tick> Get()
        {

            return (List<Tick>)_context.Ticks;
        }


    }
}
