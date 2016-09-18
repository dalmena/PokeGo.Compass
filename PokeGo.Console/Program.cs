using PokeGo.Api.CSV;
using PokeGo.Api.Device;
using PokemonGo.RocketAPI;
using System.Threading.Tasks;

namespace PokeGo.Console
{
    public static class Programx
    {
        public static void Main(string[] args)
        {
            Test().Wait();
        }

        public async static Task Test()
        {/*
            var deviceProvider = new DeviceProvider(new CsvReader(), new DeviceUniqueIdGenerator());

            var device = deviceProvider.GetAny();*/

            var settings = new DefaultSettings
            {
               PtcUsername = "funfactsbr",
               PtcPassword ="jklop123",
               AuthType =0,
               DefaultLatitude =-22.97938,
               DefaultLongitude =-47.000703,
               GoogleRefreshToken = "",
               DefaultAltitude =0,
               GoogleUsername ="kenchikuroi@gmail.com",
               GooglePassword ="jolteon18",
               DeviceId = "23b395b2941b249f",
               AndroidBoardName = "MSM9175",
               AndroidBootloader = "unknown",
               DeviceBrand ="SONY",
               DeviceModel ="XPERIA TABLET S 3G",
               DeviceModelIdentifier ="SGPT131A1",
               DeviceModelBoot ="qcom",
               HardwareManufacturer ="SONY",
               HardwareModel ="SM-G925T",
               FirmwareBrand ="google",
               FirmwareTags = "release-keys",
               FirmwareType = "user",
               FirmwareFingerprint = "sony/google/msm9175_6.0.1/MMB29M3491021 =user/release-keys",
            };

            

            var client = new Client(settings, new DefaultErrorStrategy());

            await client.Login.DoLogin();

            //await client.Login.DoLoginByAuthToken("jeyJhbGciOiJSUzI1NiIsImtpZCI6IjBlNDVjNTZmNDFkODljNDkyYzA4NTljYmUwMTg0YTg2MDc1NTA5MTEifQ.eyJpc3MiOiJhY2NvdW50cy5nb29nbGUuY29tIiwiYXVkIjoiODQ4MjMyNTExMjQwLTdzbzQyMWpvdHIyNjA5cm1xYWtjZXV1MWx1dXEwcHRiLmFwcHMuZ29vZ2xldXNlcmNvbnRlbnQuY29tIiwic3ViIjoiMTE3ODI0NjU2MzgyNzUzMzUyMjgwIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImF6cCI6Ijg0ODIzMjUxMTI0MC0zdmRydHJmZG50bGpmMnU0bWxndG5ubGhuaWduMzVkNS5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsImVtYWlsIjoia2VuY2hpa3Vyb2lAZ21haWwuY29tIiwiaWF0IjoxNDcyNDAzODcwLCJleHAiOjE0NzI0MDc0NzB9.rP8gfFZW008hf-h6MCNifglMiWsIzg5_EhrNgY4LEVbSQHm_E1y9gceww6yZYk8oSMQg99bJW8-FY1sJqMgEI_SZeu-xwiQU3B9XGc0NVfITMXmnnuhDUrka9pMBHhet6kga6MSyfA48hK22tPAVl7qNgaHB6XhfpdVD-ejxM_fkdROhqJL4ILnHxv_nz3kglExSGM4jj-9u0U6-DDT7yaIgOFudGjtF5IBQZXM2VgXdr4qulqsTO4PP8TQZ59CP5CcxcRi0ID1ujbG_vRH5KOx_3YLliYhldns0sBKGacBFffq5KsV_FGIe3fbI2gwewxEu1rejxYR8Xsu9DnYYow");

            var profile = await client.Player.GetPlayer();
        }

    }
}
