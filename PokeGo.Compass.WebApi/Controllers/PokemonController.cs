using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Core.Providers;
using PokeGo.Compass.Core.Services;
using PokeGo.Compass.WebApi.Attributes;
using PokeGo.Compass.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PokeGo.Compass.WebApi.Controllers
{
    [AuthKeyRequired]
    public class PokemonController : ApiController
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpPost]
        [Route("pokemon/nearby")]
        public async Task<IList<IPokemon>> GetPokemonNearby(Location location)
        {
            return (await _pokemonService.GetPokemonNearby(location));
        }

        [HttpPost]
        [Route("pokemon/find")]
        public async Task<IList<IPokemonFound>> FindPokemonAround(Location location)
        {
            return (await _pokemonService.FindPokemonAround(location));
        }

        [HttpPost]
        [Route("pokemon/find/ignore")]
        public async Task<IList<IPokemonFound>> FindPokemonAroundExceptFor(LocationWithIgnoreList locationWithIgnoreList)
        {
            return (await _pokemonService.FindPokemonAroundExceptFor(locationWithIgnoreList.Location, locationWithIgnoreList.PokemonIds));
        }

    }
}