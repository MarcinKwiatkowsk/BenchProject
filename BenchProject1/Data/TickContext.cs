using BenchProject1.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchProject1.Data
{
    public class TickContext
    {
        public TickContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

             Ticks = database.GetCollection<Tick>(configuration["DatabaseSettings:CollectionName"]);
        }

        public IMongoCollection<Tick> Ticks { get; }
    }
}
