using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Core.Providers;
using POGOProtos.Map.Pokemon;
using PokeGo.Compass.Api.Models;
using PokeGo.Compass.Core.Location;
using System.Linq;
using PokemonGo.RocketAPI;

namespace PokeGo.Compass.Api.Providers
{
    public class PokemonFindProvider : IPokemonFindProvider
    {
        private readonly ILocationFactory _locationFactory;
        private readonly IPokemonClientProvider _pokemonClientProvider;
        private readonly IRadarFactory _radarFactory;
        
        public PokemonFindProvider(IPokemonClientProvider pokemonClientProvider, ILocationFactory locationFactory, IRadarFactory radarFactory)
        {
            _pokemonClientProvider = pokemonClientProvider;
            _locationFactory = locationFactory;
            _radarFactory = radarFactory;
        }

        public async Task<IList<IPokemonFound>> Find(ILocation location)
        {
            var client = await _pokemonClientProvider.DoLogin(location);

            var radar = _radarFactory.Create(location);

            var foundPokemons = new List<IPokemonFound>();

            await radar.Scan(async nextLocation =>
            {
                var pokemons = await FindWildPokemonsAt(nextLocation, client);

                foundPokemons.AddRange(pokemons.Select(BuildPokemonWith));
            });

            return foundPokemons;
        }

        public async Task<IList<IPokemonFound>> FindExceptFor(ILocation location, IList<ulong> pokemonIds)
        {
            return (await Find(location)).Where(x => !pokemonIds.Contains(x.Pokemon.Id)).ToList();
        }

        private async Task<IEnumerable<WildPokemon>> FindWildPokemonsAt(ILocation nextLocation, IClient client)
        {
            await client.Player.UpdatePlayerLocation(nextLocation.Latitude, nextLocation.Longitude, nextLocation.Altitude);
            var objs = await client.Map.GetMapObjects();
            var pokemons = objs.Item1.MapCells.SelectMany(x => x.WildPokemons);
            return pokemons;
        }

        private IPokemonFound BuildPokemonWith(WildPokemon wildPokemon)
        {
            return new PokemonFound
            {
                Pokemon = new Pokemon
                {
                    Id = wildPokemon.EncounterId,
                    Number = (int)wildPokemon.PokemonData.PokemonId,
                    Name = wildPokemon.PokemonData.PokemonId.ToString()
                },
                Location = _locationFactory.Create(wildPokemon.Latitude, wildPokemon.Longitude)
            };
        }
    }
}
