using PokeGo.Compass.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokeGo.Compass.WebApi.Models
{
    public class LocationWithIgnoreList
    {
        [Required]
        public Location Location { get; set; }

        [Required]
        public List<ulong> PokemonIds { get; set; }
    }
}