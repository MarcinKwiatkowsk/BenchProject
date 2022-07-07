using BenchProject1.Models;
using System.Collections.Generic;

namespace BenchProject1.Data
{
    public interface ITickerFactory
    {
        Ticker Create(List<Tick> Ticks, string message);
    }
}
