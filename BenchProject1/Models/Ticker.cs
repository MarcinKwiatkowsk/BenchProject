using System;
using System.Collections.Generic;

namespace BenchProject1.Models
{
    public class Ticker
    {
        public List<Tick> Ticks { get; set;  }
        public bool IsOpen { get;  set; }
    }
}