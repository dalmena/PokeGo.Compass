using System;
using System.Threading.Tasks;
using POGOProtos.Networking.Envelopes;
using PokemonGo.RocketAPI.Extensions;

namespace PokeGo.Console
{
    public class DefaultErrorStrategy : IApiFailureStrategy
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
