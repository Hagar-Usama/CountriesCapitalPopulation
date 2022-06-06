using Microsoft.EntityFrameworkCore;

namespace PopulationStats.Models
{
    public class PopuContext: DbContext
    {
        public PopuContext(DbContextOptions<PopuContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Population>().HasKey(table => new {
                table.CityId,
                table.Year
            });
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Population> Populations { get; set; }
    }
}
