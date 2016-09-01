
using PokeGo.Compass.Api.Models;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.Core.Models;
using PokeGo.Compass.WebApi.Attributes;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PokeGo.Compass.WebApi.Controllers
{
    [AuthKeyRequired]
    public class TestController : ApiController
    {
        private readonly IRadarFactory _radarFactory;

        public TestController(IRadarFactory radarFactory)
        {
            _radarFactory = radarFactory;
        }


        [HttpPost]
        [Route("pokemon/nearby2")]
        public async Task<IList<ILocation>> Test(Location initialLocation)
        {
            var locations = new List<ILocation>();

            var radar = _radarFactory.Create(initialLocation);

            await radar.Scan(async x =>
            {
                locations.Add(x);

                await Task.Delay(1);
            });

            return locations;
        }
    }
}