using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;


namespace BenchProject1
{
    public class StockDataService
    {

        readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        readonly string ApplicationName = "StockShares";
        readonly string SpreadsheetId = "1Mmq4Ez8RWsnu4mHy0LZpy7400Q5yKlFawt5FnvuAqio";
        readonly string sheet = "stocks"; 
        SheetsService service;

        public List<string> CreateCredentials()
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

            return ReadEntries(new List<string>() );

        }

        public List<string> ReadEntries(List<string> entries)
        {
            var range = $"{sheet}!A2:B252";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    foreach (var item in row)
                    {
                        entries.Add(item.ToString());
                    }
                }
            }
            else Console.WriteLine("no data was found");
            return entries;
        }
        
    }
}
