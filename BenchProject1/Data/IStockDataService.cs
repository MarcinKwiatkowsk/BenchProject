using BenchProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public interface IStockDataService
    {
        void CreateCredentials();
        string GetCurrentDateString();
        List<Tick> ReadEntries();
        List<Tick> ReadEntries(DateTime startDate, DateTime endDate);
        List<string> CreateEntries(List<string> entries);
        void UpdateEntry(string cellRow, string stockDate, string cellValue);
        void DeleteEntry(string cellRow);
    }
}
