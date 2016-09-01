using PokeGo.Compass.Core.Services;
using System.Collections.Generic;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Core.Providers;
using System.Threading.Tasks;
using System;

namespace PokeGo.Compass.Api.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonNearbyProvider _pokemonNearbyProvider;
        private readonly IPokemonFindProvider _pokemonFindProvider;

        public PokemonService(IPokemonNearbyProvider pokemonNearbyProvider, IPokemonFindProvider pokemonFindProvider)
        {
            _pokemonNearbyProvider = pokemonNearbyProvider;
            _pokemonFindProvider = pokemonFindProvider;
        }

        public async Task<IList<IPokemon>> GetPokemonNearby(ILocation location)
        {
            return await _pokemonNearbyProvider.GetAll(location);
        }

        public async Task<IList<IPokemonFound>> FindPokemonAround(ILocation location)
        {
            return await _pokemonFindProvider.Find(location);
        }

        public async Task<IList<IPokemonFound>> FindPokemonAroundExceptFor(ILocation location, IList<ulong> pokemonIds)
        {
            return await _pokemonFindProvider.FindExceptFor(location, pokemonIds);
        }
    }
}
