using BenchProject1.Models;
using System.Collections.Generic;

namespace BenchProject1.Data
{
    public class TickerFactory : ITickerFactory
    {
        public TickerFactory() { }

        public Ticker Create(List<Tick> Ticks, string message)
        {
            var Ticker = new Ticker();
            Ticker.Ticks = Ticks;
            return Ticker;
        }
    }
}
