using PokeGo.Compass.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace PokeGo.Compass.WebApi.Models
{
    public class Location : ILocation
    {
        public double Altitude { get;set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}