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
        private readonly ICompanyRepository _companyRepository;


        public TickerController(ITickerFactory tickerFactory, IStockDataService stockDataService, ITickRepository tickRepository, ICompanyRepository companyRepository)
        {
            _tickerFactory = tickerFactory;
            _stockDataService = stockDataService;
            _tickRepository = tickRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, string companyCode)
        {
            var ticks = await _tickRepository.Get(startDate, endDate, companyCode);
            string error = "";

            try
            {
                if (DateTime.Compare(endDate, ticks.Last().TickDateTime) > 0
                 &&
                (DateTime.Compare(startDate, ticks.First().TickDateTime) < 0))
                {
                    {
                        ticks = await FetchData(startDate, endDate, companyCode, ticks);
                    }
                    error = "Successful";
                    return Ok(ticks);
                }
            }
            catch (Exception e)
            {
                ticks = await FetchData(startDate, endDate, companyCode, ticks);
                if (ticks.Count == 0) error = "No data";
                else if (DateTime.Compare(endDate, ticks.Last().TickDateTime) > 0
                  &&
                (DateTime.Compare(startDate, ticks.First().TickDateTime) < 0))
                {
                    error = "The given range is too big";
                }
            }
            return Ok(ticks);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tickRepository.Get());
        }

        [HttpPut]
        private async Task<List<Tick>> FetchData(DateTime startDate, DateTime endDate, string companyCode, List<Tick> ticks)
        {
            _stockDataService.UpdateEntry(companyCode, startDate, endDate);
            var dateEntries = _stockDataService.ReadEntries(startDate, endDate);
            var company = await _companyRepository.Get(companyCode);
            dateEntries.ForEach(t => t.Company = company);
            await _tickRepository.Add(dateEntries.Except(ticks).ToList());
            return dateEntries;
        }
    }
}
