using System;
using PokeGo.Compass.Api.Exceptions;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.Core.Repositories;
using PokeGo.Compass.Core.Services;
using PokeGo.Compass.Core.Providers;

namespace PokeGo.Compass.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthKeyProvider _authKeyProvider;
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository, IAuthKeyProvider authKeyProvider)
        {
            _userRepository = userRepository;
            _authKeyProvider = authKeyProvider;
        }

        public string DoLogin(ILogin login)
        {
            var user = _userRepository.GetByLogin(login);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user.AuthKey;
        }

        public void DoLoginByAuthKey(string authKey)
        {
            var user = _userRepository.GetByAuthKey(authKey);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _authKeyProvider.AuthKey = user.AuthKey;
        }
    }
}
