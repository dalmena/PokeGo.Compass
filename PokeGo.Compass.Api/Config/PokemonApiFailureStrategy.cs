using System.Threading.Tasks;
using POGOProtos.Networking.Envelopes;
using PokemonGo.RocketAPI.Extensions;

namespace PokeGo.Compass.Api.PokemonApi
{
    public class PokemonApiFailureStrategy : IApiFailureStrategy
    {
        public async Task<ApiOperation> HandleApiFailure(RequestEnvelope request, ResponseEnvelope response)
        {
            return ApiOperation.Retry;
        }

        public void HandleApiSuccess(RequestEnvelope request, ResponseEnvelope response)
        {
        }
    }
}
