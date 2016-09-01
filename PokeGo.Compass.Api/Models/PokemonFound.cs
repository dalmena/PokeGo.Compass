using System;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Models
{
    public class PokemonFound : IPokemonFound
    {
        public ILocation Location { get; set; }
        public IPokemon Pokemon { get; set; }
    }
}
