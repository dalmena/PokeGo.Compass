using System;
using PokeGo.Compass.Core.Providers;
using PokemonGo.RocketAPI;
using PokeGo.Compass.Core.Repositories;
using PokeGo.Compass.Api.PokemonApi;
using PokeGo.Compass.Core.Models;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Exceptions;

namespace PokeGo.Compass.Api.Providers
{
    public class PokemonClientProvider : IPokemonClientProvider
    {
        private readonly IAuthKeyProvider _authKeyProvider;
        private readonly IUserRepository _userRepository;

        public PokemonClientProvider(IAuthKeyProvider authKeyProvider, IUserRepository userRepository)
        {
            _authKeyProvider = authKeyProvider;
            _userRepository = userRepository;
        }

        public async Task<IClient> DoLogin(ILocation location)
        {
            var user = _userRepository.GetByAuthKey(_authKeyProvider.AuthKey);

            var settings = new PokemonApiSettings
            {
                AndroidBoardName = user.Device.AndroidBoardName,
                AndroidBootloader = user.Device.AndroidBootLoader,
                DeviceBrand = user.Device.DeviceBrand,
                DeviceModel = user.Device.DeviceModel,
                DeviceId = user.Device.DeviceId,
                DeviceModelBoot = user.Device.DeviceModelBoot,
                DeviceModelIdentifier = user.Device.DeviceModelIdentifier,
                FirmwareBrand = user.Device.FirmwareBrand,
                FirmwareFingerprint = user.Device.FirmwareFingerprint,
                FirmwareTags = user.Device.FirmwareTags,
                FirmwareType = user.Device.FirmwareType,
                HardwareManufacturer = user.Device.HardwareManufacturer,
                HardwareModel = user.Device.HardwareModel,
                AuthType = user.PokeGoAuthType,
                DefaultAltitude = location.Altitude,
                DefaultLatitude = location.Latitude,
                DefaultLongitude = location.Longitude,
                GoogleRefreshToken = "",
                PtcUsername = user.PokeGoUsername,
                PtcPassword = user.PokeGoPassword,
                GoogleUsername = user.PokeGoUsername,
                GooglePassword = user.PokeGoPassword
            };
            
            var client = new Client(settings, new PokemonApiFailureStrategy());

            await DoLogin(user, client);

            _userRepository.UpdatePokeGoAuthKey(user.Id, client.AuthToken);

            return client;
        }

        private async Task DoLogin(IUser user, IClient client)
        {
            if (!string.IsNullOrEmpty(user.LastPokeGoAuthKey))
            {
                await KeepLastClientLogin(user, client);
                return;
            }

            await client.Login.DoLogin();
        }

        private async Task KeepLastClientLogin(IUser user, IClient client)
        {
            try
            {
                await client.Login.DoLoginByAuthToken(user.LastPokeGoAuthKey);
            }
            catch(AccessTokenExpiredException)
            {
                await client.Login.DoLogin();
            }
        }
    }
}
