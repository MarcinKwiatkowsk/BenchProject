using BenchProject1.Data;
using BenchProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TickerController : ControllerBase
    {
        private readonly ITickerFactory _tickerFactory;
        public TickerController(ITickerFactory tickerFactory)
        {
            _tickerFactory = tickerFactory;

        }

        [HttpPost]
        public Ticker CreateTicker(DateTime startDate, DateTime endDate)
        {
            /* var ticks = new List<Tick>);
            * var tick = new Tick();
            * try
            * {
            * ticks = tickRepository.Get(start, end)
            * }
            * catch(Exception e)
            * {
                tick = tickRepository.Update()
            * if(tick. Date < end)
            * {
                return Http
              } 

           return _tickerFactory.Create(ticks)

            */
        }
    }
