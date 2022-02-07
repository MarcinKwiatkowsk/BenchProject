﻿using BenchProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public class TickerFactory : ITickerFactory
    {
        public TickerFactory() { }

        public Ticker Create(List<Tick> Ticks)
        {
            var Ticker = new Ticker();
            Ticker.Ticks = Ticks;
            Ticker.IsOpen = DateTime.Now.Hour >= 16;
        }
   

        
    }
}
