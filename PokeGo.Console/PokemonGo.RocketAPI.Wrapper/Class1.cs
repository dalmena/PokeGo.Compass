using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Extensions;

namespace PokemonGo.RocketAPI.Wrapper
{
    public interface IPokemonClient
    {
        DoLogin();
        SetLocation
    }
    public class PokemonClient : Client
    {
        private readonly Client _client;

        public PokemonClient(ISettings settings, IApiFailureStrategy strategy)
        {
            _client = new Client(settings, strategy);
        }
    }
}
