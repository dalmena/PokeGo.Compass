using PokeGo.Compass.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Providers
{
    public interface IPokemonFindProvider 
    {
        Task<IList<IPokemonFound>> Find(ILocation location);
        Task<IList<IPokemonFound>> FindExceptFor(ILocation location, IList<ulong> pokemonIds);
    }
}
