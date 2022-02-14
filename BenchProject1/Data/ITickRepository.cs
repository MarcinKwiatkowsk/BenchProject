using BenchProject1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface ITickRepository
    {
        public void Add(List<Tick> ticks);
        public void Add(Tick tick);
        public List<Tick> Get(DateTime start, DateTime end);
        public List<Tick> Get();
    }
}