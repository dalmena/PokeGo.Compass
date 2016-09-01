using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Core.Services
{
    public interface ILoginService
    {
        string DoLogin(ILogin login);
        void DoLoginByAuthKey(string authKey);
    }
}
