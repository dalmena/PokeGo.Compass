using PokemonGo.RocketAPI.Enums;

namespace PokeGo.Compass.Core.Models
{
    public interface IUser
    {
        int Id { get; }
        string Username { get; }
        string Password { get; }
        string AuthKey { get; }
        string LastPokeGoAuthKey { get; }
        string PokeGoUsername { get; }
        string PokeGoPassword { get; }
        AuthType PokeGoAuthType { get; }
        IDevice Device { get; }
    }
}
