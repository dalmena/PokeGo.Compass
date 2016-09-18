using System;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Location
{
    public class RadarFactory : IRadarFactory
    {
        private readonly ILocationCalculator _locationCalculator;
        private readonly ILocationFactory _locationFactory;

        public RadarFactory(ILocationFactory locationFactory, ILocationCalculator locationCalculator)
        {
            _locationFactory = locationFactory;
            _locationCalculator = locationCalculator;
        }

        public IRadar Create(ILocation initialLocation)
        {
            return new Radar(initialLocation, _locationCalculator, _locationFactory);
        }
    }
}
