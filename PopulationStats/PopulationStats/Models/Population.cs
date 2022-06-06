using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopulationStats.Models
{
    public class Population
    {
        [Key]
        public int PopulationId {get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
    }
}
