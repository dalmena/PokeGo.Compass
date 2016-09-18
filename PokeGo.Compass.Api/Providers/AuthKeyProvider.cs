using PokeGo.Compass.Core.Providers;
using System;

namespace PokeGo.Compass.Api.Providers
{
    public class AuthKeyProvider : IAuthKeyProvider
    {
        public string AuthKey { get; set; }
    }
}
