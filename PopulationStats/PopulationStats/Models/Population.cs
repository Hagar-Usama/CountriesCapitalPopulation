using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopulationStats.Models
{
    public class Population
    {
        //[Key, Column(Order = 0)]
        [ForeignKey("City")]
        public int CityId {get; set; }

        //[Key, Column(Order = 1)]
        public int Year { get; set; }
        public double Value { get; set; }
        public string? Sex { get; set; }
        public string? Reliability { get; set; }
    }
}
