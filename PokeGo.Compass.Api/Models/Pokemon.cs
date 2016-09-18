using System;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Models
{
    public class Pokemon : IPokemon
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public ulong Id { get; set; }
    }
}
