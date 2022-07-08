using BenchProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace BenchProject1.Data
{
    public class TickContext : DbContext
    {
        public TickContext(DbContextOptions<TickContext> options) : base(options)
        {

        }

        public DbSet<Tick> Ticks { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
