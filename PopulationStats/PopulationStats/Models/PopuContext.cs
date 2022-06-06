using Microsoft.EntityFrameworkCore;

namespace PopulationStats.Models
{
    public class PopuContext: DbContext
    {
        public PopuContext(DbContextOptions<PopuContext> options)
           : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Population> Populations { get; set; }
    }
}
