using PokeGo.Compass.Core.Repositories;
using System;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Api.DB;
using System.Linq;

namespace PokeGo.Compass.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUser GetByAuthKey(string authKey)
        {
            using (var db = new PokeGoDB())
            {
                return db.Users.Include("Device")
                    .Where(x => x.AuthKey == authKey)
                    .FirstOrDefault();
            }
        }

        public IUser GetByLogin(ILogin login)
        {
            using(var db = new PokeGoDB())
            {
                var user = db.Users
                    .Where(x => x.Username == login.Username && x.Password == x.Password)
                    .FirstOrDefault();

                if (user == null)
                    return user;

                return user;
            }
        }

        public void UpdatePokeGoAuthKey(int userId, string pokeGoAuthkey)
        {
            using (var db = new PokeGoDB())
            {
                var user = db.Users.Find(userId);

                if (user != null)
                {
                    user.LastPokeGoAuthKey = pokeGoAuthkey;

                    db.SaveChanges();
                }
            }
        }
    }
}
