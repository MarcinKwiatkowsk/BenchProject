using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace BenchProject1.Models
{
    public class Tick
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime TickDateTime { get; set; }
        public double TickValue { get; set; }
    }
}