using System.ComponentModel.DataAnnotations.Schema;

namespace BenchProject1.Models
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code{ get; set; } 
        public string Description { get; set; }
    }
}
