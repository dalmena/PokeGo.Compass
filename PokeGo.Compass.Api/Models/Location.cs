using System;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Models
{
    public class Location : ILocation
    {
        public double Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return String.Format("[{0},{1}]", Latitude, Longitude);
        }
    }
}
