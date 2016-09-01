using PokeGo.Compass.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Services
{
    public interface IPokemonService
    {
        Task<IList<IPokemon>> GetPokemonNearby(ILocation location);
        Task<IList<IPokemonFound>> FindPokemonAround(ILocation location);
        Task<IList<IPokemonFound>> FindPokemonAroundExceptFor(ILocation location, IList<ulong> pokemonIds);
    }
}
