using System.ComponentModel.DataAnnotations;

namespace PopulationStats.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string? Name { get; set; }
    }
}
