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
        private readonly IStockDataService _stockDataService;
        private readonly ITickRepository _tickRepository;


        public TickerController(ITickerFactory tickerFactory, IStockDataService stockDataService, ITickRepository tickRepository)
        {
            _tickerFactory = tickerFactory;
            _stockDataService = stockDataService;
            _tickRepository = tickRepository;
        }

        [HttpPost]
        public async Task<Ticker> CreateTicker([FromForm] DateTime startDate, [FromForm] DateTime endDate)
        {
            var ticks = _tickRepository.Get(startDate, endDate);
            string error = "";

            try
            {
                if (DateTime.Compare(endDate, ticks.Last().TickDateTime) > 0
                 &&
               (DateTime.Compare(startDate, ticks.First().TickDateTime) < 0))
                {
                    {
                        ticks = await FetchData(startDate, endDate, ticks);

                    }
                    error = "Successful";
                    return _tickerFactory.Create(ticks, error);
                }
            }
            catch (Exception e)
            {
                ticks = await FetchData(startDate, endDate, ticks);
                if (ticks.Count == 0) error = "No data";
               else if (DateTime.Compare(endDate, ticks.Last().TickDateTime) > 0
                 &&
               (DateTime.Compare(startDate, ticks.First().TickDateTime) < 0))
                {
                    error = "The given range is too big";
                }
            }
            return _tickerFactory.Create(ticks, error);
        }

        [HttpGet]
        public async Task<List<Tick>> FetchData([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, List<Tick> ticks)
        {
            var entries = _stockDataService.ReadEntries();
            var dateEntries = _stockDataService.ReadEntries(startDate, endDate);
             _tickRepository.Add(dateEntries.Except(ticks).ToList());
            return dateEntries;
        }
    }
}
