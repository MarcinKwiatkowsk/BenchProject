using BenchProject1.Models;
using System;
using System.Collections.Generic;

namespace BenchProject1.Data
{
    public interface IStockDataService
    {
        void CreateCredentials();
        string GetCurrentDateString();
        List<Tick> ReadEntries(DateTime startDate, DateTime endDate);
        List<string> CreateEntries(List<string> entries);
        void UpdateEntry(string companyCode, DateTime startDate, DateTime endDate);
        void DeleteEntry(string cellRow);
    }
}
