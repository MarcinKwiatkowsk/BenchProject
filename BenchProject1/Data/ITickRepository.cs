using BenchProject1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface ITickRepository
    {
        public Task Add(List<Tick> ticks);
        public Task Add(Tick tick);
        public Task<List<Tick>> Get(DateTime start, DateTime end);
        public Task<List<Tick>> Get();
    }
}