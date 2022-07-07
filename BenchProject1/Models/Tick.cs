using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchProject1.Models
{
    public class Tick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Company Company{ get; set; }
        public DateTime TickDateTime { get; set; }
        public double TickValue { get; set; }
    }
}