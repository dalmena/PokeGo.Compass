using System;
using System.Collections.Generic;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Core.Providers;
using PokemonGo.RocketAPI;
using System.Threading.Tasks;
using System.Linq;
using POGOProtos.Map.Pokemon;
using PokeGo.Compass.Api.Models;

namespace PokeGo.Compass.Api.Providers
{
    public class PokemonNearbyProvider : IPokemonNearbyProvider
    {
        private readonly IPokemonClientProvider _pokemonClientProvider;

        public PokemonNearbyProvider(IPokemonClientProvider pokemonClientProvider)
        {
            _pokemonClientProvider = pokemonClientProvider;
        }

        public async Task<IList<IPokemon>> GetAll(ILocation location)
        {
            var client = await _pokemonClientProvider.DoLogin(location);            
            var objs = await client.Map.GetMapObjects();
            var pokemons = objs.Item1.MapCells.SelectMany(x => x.NearbyPokemons);

            return pokemons.Select(BuildPokemonWith).ToList();
        }

        private IPokemon BuildPokemonWith(NearbyPokemon nearbyPokemon)
        {
            return new Pokemon
            {
                Id = nearbyPokemon.EncounterId,
                Number = (int)nearbyPokemon.PokemonId,
                Name = nearbyPokemon.PokemonId.ToString()
            };
        }
    }
}
