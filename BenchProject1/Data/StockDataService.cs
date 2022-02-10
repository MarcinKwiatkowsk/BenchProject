using BenchProject1.Data;
using BenchProject1.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BenchProject1
{
    public class StockDataService : IStockDataService
    {

        readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        readonly string ApplicationName = "StockShares";
        readonly string SpreadsheetId = "1Mmq4Ez8RWsnu4mHy0LZpy7400Q5yKlFawt5FnvuAqio";
        readonly string sheet = "stocks";
        SheetsService service;

        public void CreateCredentials()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }
            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public string GetCurrentDateString()
        {
            var date = DateTime.Now;
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
            return date.ToString();
        }

        public List<Tick> ReadEntries()
        {
            CreateCredentials();
            var entries = new List<Tick>();
            var range = $"{sheet}!A2:B";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count == 0) break;
                    entries.Add(new Tick
                    {
                        Id = generateID(),
                        TickDateTime = DateTime.Parse(row[0].ToString()),
                        TickValue = double.Parse(row[1].ToString())
                    });
                }
            }
            return entries;
        }

        public string TrimDateToDay(DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public List<Tick> ReadEntries(DateTime startDate, DateTime endDate)
        {
            CreateCredentials();
            

            var entries = new List<Tick>();
            var range = $"{sheet}!A2:B";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count == 0) break;
                    entries.Add(new Tick
                    {
                        Id = generateID(),
                        TickDateTime = DateTime.Parse(row[0].ToString()),
                        TickValue = double.Parse(row[1].ToString())
                    });
                }
            }

            var inDateEntries = new List<Tick>();

            for (int i=0; i<entries.Count; i++)
            {
                var date = entries.ElementAt(i).TickDateTime;
                if (DateTime.Compare(endDate, date) < 0
                    &&
                   (DateTime.Compare(startDate, date) > 0))
                {
                    inDateEntries.Add(entries.ElementAt(i));
                }
            }

            return inDateEntries;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public List<string> CreateEntries(List<string> entries)
        {
            var range = $"{sheet}!A:B";
            var valueRange = new ValueRange();

            var objectList = new List<object>() { "2.02.2022 11:30", "1000" };
            List<string> stringList = objectList.Select(s => (string)s).ToList();
            entries.AddRange(stringList);

            valueRange.Values = new List<IList<object>> { objectList };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();

            return entries;
        }

        public void UpdateEntry(string cellRow, string stockDate, string cellValue)
        {
            var range = $"{sheet}!A" + cellRow + ":B" + cellRow;
            var valueRange = new ValueRange();

            var objectList = new List<object>() { stockDate, cellValue };
            valueRange.Values = new List<IList<object>> { objectList };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var updateResponse = updateRequest.Execute();
        }

        public void DeleteEntry(string cellRow)
        {
            var range = $"{sheet}!A" + cellRow + ":B";
            var requestBody = new ClearValuesRequest();

            var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetId, range);
            var deleteResponse = deleteRequest.Execute();
        }

    }
}
