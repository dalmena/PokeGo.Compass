using PokeGo.Compass.Core.Models;
using System.Threading.Tasks;

namespace PokeGo.Compass.Core.Repositories
{
    public interface IUserRepository
    {
        IUser GetByLogin(ILogin login);
        IUser GetByAuthKey(string authKey);
        void UpdatePokeGoAuthKey(int userId, string pokeGoAuthkey);
    }
}
