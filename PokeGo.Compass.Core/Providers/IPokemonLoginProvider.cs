using PokeGo.Compass.Core.Models;
using PokemonGo.RocketAPI;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Providers
{
    public interface IPokemonClientProvider
    {
        Task<IClient> DoLogin(ILocation location);
    }
}
