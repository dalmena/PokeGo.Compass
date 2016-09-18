using System;
using System.Threading.Tasks;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Location
{
    public class Radar : IRadar
    {
        private const int RADAR_SCAN_LEVEL = 5;
        private const double DISTANCE_PER_SCAN_IN_METERS = 50;

        private readonly ILocation _initialLocation;
        private ILocationCalculator _locationCalculator;
        private readonly ILocationFactory _locationFactory;

        public Radar(ILocation initialLocation, ILocationCalculator locationCalculator, ILocationFactory locationFactory)
        {
            _initialLocation = initialLocation;
            _locationCalculator = locationCalculator;
            _locationFactory = locationFactory;
        }

        public async Task Scan(Func<ILocation, Task> nextScan)
        {
            var linearDistance = DISTANCE_PER_SCAN_IN_METERS * Math.Sqrt(2);
            var latitudeDistance = _locationCalculator.AddMetersToLocation(_initialLocation, linearDistance, 0).Latitude - _initialLocation.Latitude;
            var longitudeDistance = _locationCalculator.AddMetersToLocation(_initialLocation, linearDistance, 90).Longitude - _initialLocation.Longitude;
                        
            var size = CalculateLayerLevel();
            var startIndex = -size / 2;
            var endIndex = size / 2;
            
            for (int x = 0; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                {
                    //magica
                    double lat = _initialLocation.Latitude + (endIndex - x) * latitudeDistance;
                    double lon = _initialLocation.Longitude + (startIndex + y) * longitudeDistance;
                    await nextScan(_locationFactory.Create(lat, lon));
                }
            }
        }


        private int CalculateLayerLevel()
        {
            return RADAR_SCAN_LEVEL * 2 - 1;
        }
    }
}
