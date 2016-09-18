using PokeGo.Compass.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Providers
{
    public interface IPokemonNearbyProvider
    {
        Task<IList<IPokemon>> GetAll(ILocation location);
    }
}
