using System;
using PokeGo.Compass.Core.Location;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Location
{
    public class LocationCalculator : ILocationCalculator
    {
        private const double R = 6371000; // meters , earth Radius approx
        private const double PI = 3.1415926535;
        private const double RADIANS = PI / 180;
        private const double DEGREES = 180 / PI;

        private readonly ILocationFactory _locationFactory;

        public LocationCalculator(ILocationFactory locationFactory)
        {
            _locationFactory = locationFactory;
        }

        public double GetDistanceInMeters(ILocation start, ILocation end)
        {
            double R = 6371e3;
            Func<double, float> toRad = x => (float)(x * (Math.PI / 180));
            float lat1 = toRad(start.Latitude);
            float lat2 = toRad(end.Latitude);
            float dLat = toRad(end.Latitude - start.Latitude);
            float dLng = toRad(end.Longitude - start.Longitude);
            double h = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(h), Math.Sqrt(1 - h));
            return R * c;
        }

        public ILocation AddMetersToLocation(ILocation location, double distance, double bearing)
        {
            
            double latA = location.Latitude * RADIANS;
            double lonA = location.Longitude * RADIANS;
            double angularDistance = distance / R;
            double trueCourse = bearing * RADIANS;

            double lat = Math.Asin(
                Math.Sin(latA) * Math.Cos(angularDistance) +
                Math.Cos(latA) * Math.Sin(angularDistance) * Math.Cos(trueCourse));

            double dlon = Math.Atan2(
                Math.Sin(trueCourse) * Math.Sin(angularDistance) * Math.Cos(latA),
                Math.Cos(angularDistance) - Math.Sin(latA) * Math.Sin(lat));

            double lon = ((lonA + dlon + Math.PI) % (Math.PI * 2)) - Math.PI;

            return _locationFactory.Create(lat / RADIANS, lon / RADIANS);
        }
        
    }
}
