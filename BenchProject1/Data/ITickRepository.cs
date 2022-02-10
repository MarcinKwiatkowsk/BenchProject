using BenchProject1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface ITickRepository
    {
        Task Add(List<Tick> ticks);
    }
}