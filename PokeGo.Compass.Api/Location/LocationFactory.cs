using System;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Location
{
    public class LocationFactory : ILocationFactory
    {
        public ILocation Create(double latitude, double longitude)
        {
            return Create(latitude, longitude, 0);
        }

        public ILocation Create(double latitude, double longitude, double altitude)
        {
            return new Models.Location
            {
                Latitude = latitude,
                Longitude = longitude,
                Altitude = altitude
            };
        }
    }
}
