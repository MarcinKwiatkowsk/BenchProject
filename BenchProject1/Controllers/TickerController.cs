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
        private readonly StockDataService _stockDataService;
        private readonly TickRepository _tickRepository;


        public TickerController(ITickerFactory tickerFactory, StockDataService stockDataService, TickRepository tickRepository)
        {
            _tickerFactory = tickerFactory;
            _stockDataService = stockDataService;
            _tickRepository = tickRepository;
        }

        [HttpPost]
        public Ticker CreateTicker(DateTime startDate, DateTime endDate)
        {
            var ticks = _tickRepository.Get(startDate, endDate);
            string error = "";

            try
            {
                if (DatesInDatabase(startDate, endDate, ticks))
                {
                    ticks = FetchData(startDate, endDate, ticks);
                }
                error = "Successful";
                return _tickerFactory.Create(ticks, error);
            }
            catch (Exception e)
            {
                ticks = FetchData(startDate, endDate, ticks);
                if (ticks.Count == 0) error = "No data";
                else if (DatesInDatabase(startDate, endDate, ticks)) error = "The given range is too big";

                return _tickerFactory.Create(ticks, error);
             }
        }

        public List<Tick> FetchData(DateTime startDate, DateTime endDate, List<Tick> ticks)
        {
            var entries = _stockDataService.ReadEntries();
            var dateEntries = _stockDataService.ReadEntries(startDate, endDate);
            _tickRepository.Add(dateEntries.Except(ticks).ToList());
            return dateEntries;
        }

        public bool DatesInDatabase(DateTime startDate, DateTime endDate, List<Tick> ticks)
        {
            if (DateTime.Compare(endDate, ticks.Last().TickDateTime) > 0
                &&
              (DateTime.Compare(startDate, ticks.First().TickDateTime) < 0))
            {
                return true;
            }
            else return false;
        }
    }
}
