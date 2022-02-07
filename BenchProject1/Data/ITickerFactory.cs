using BenchProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface ITickerFactory
    {
        Ticker Create(List<Tick> Ticks);
    }
}
