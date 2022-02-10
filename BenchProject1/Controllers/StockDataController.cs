using BenchProject1.Data;
using BenchProject1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockDataController : Controller
    {
        private readonly IStockDataService _stockDataService;
        private readonly TickContext _context;

        public StockDataController(IStockDataService stockDataService, TickContext context)
        {
            _stockDataService = stockDataService;
            _context = context;
        }

        [HttpGet]
        //public async Task<IEnumerable<Tick>> Get()
        //{
        //    return await _context.Ticks.Find(p => true).ToListAsync();

        //}
        public List<Tick> Get()
        {
            List<Tick> entries = _stockDataService.ReadEntries();
            UpdateDatabase(entries);
            return entries;
        }
        
        public void UpdateDatabase(List<Tick> entries)
        {

        }
    }
}
